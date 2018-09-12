using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CONSTRUCTOR : nodoModelo
    {
        public _CONSTRUCTOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }

        public override void ejecutar(elementoClase simbolo)
        {
            // println("llego al contructor");

            token tipo = new token("vacio");
            token nombre = getIdentificador();
            nodoModelo LST_CUERPO= getLST_CUERPO();

            elementoPolimorfo element = new elementoPolimorfo(tablaSimbolos, tipo, nombre, LST_CUERPO);

            cargarPolimorfismoHijos(element);
            simbolo.lstConstructores.insertarElemento(element);
        }



        public token getIdentificador()
        {
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 0) 
                retorno = lstAtributos.getToken(0);

            return retorno;
        }


        public nodoModelo getLST_CUERPO()
        { 
            nodoModelo tempNodo = getNodo("LST_CUERPO");
            if (tempNodo != null)
                return tempNodo;
            else
                return new nodoModelo("---", tablaSimbolos);

             
        }


    }
}
