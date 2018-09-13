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

            if (hayErrores())
                return;

            token tipo = new token("vacio");
            token nombre = getIdentificador(simbolo.nombreClase);
            nodoModelo LST_CUERPO= getLST_CUERPO();

            elementoPolimorfo element = new elementoPolimorfo(new token("publico"),tablaSimbolos, tipo, nombre, LST_CUERPO,0);

            cargarPolimorfismoHijos(element);
            simbolo.lstConstructores.insertarElemento(element);
        }



        public token getIdentificador(token nombreClase)
        {
            //hay que validar si tiene el mismo nombre que la clase;
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 0)
            {

                token temp = lstAtributos.getToken(0);
                if (temp.valLower.Equals(nombreClase.valLower))
                {

                    return temp;
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("El constructor no tiene el mismo nombre que la clase:"+temp.val, temp);
                }

                
            }
            else
            {
                tablaSimbolos.println("No se encontró el identificador");
            }
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
