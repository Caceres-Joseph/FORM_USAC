using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Formulario
{
    class _FORMULARIO : nodoModelo

    /*
     *FORMULARIO.Rule = tFormulario + valId  + sAbreLlave + LST_CUERPO + sCierraLlave;
     */

    {
        public _FORMULARIO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Primer analisis
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;
            // println("llego al contructor");

            token tipo = new token("vacio");
            token nombre = lstAtributos.getToken(1);
            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad = new token("publico");
            int dimension = 0;

            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstFormularios.insertarElemento(element);
             
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
