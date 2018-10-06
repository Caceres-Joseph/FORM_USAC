using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Pregunta
{
    class _CUERPO_PREGUNTA : nodoModelo
    /*
        CUERPO_PREGUNTA.Rule = DECLARAR_VARIABLE_GLOBAL + sPuntoComa
            | METODO
            | VISIBILIDAD + tRespuesta + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
            | VISIBILIDAD + tMostrar + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
            | VISIBILIDAD + tCalcular + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
     */
    {
        public _CUERPO_PREGUNTA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;

            if (hijos.Count == 3)
            {
                String nombreToken = lstAtributos.getToken(0).valLower;
                if (nombreToken.Equals("respuesta"))
                {
                    ejecutarRespuesta(simbolo);
                }
                else if (nombreToken.Equals("mostrar"))
                {
                    ejecutarOtros(simbolo);
                }
                else if (nombreToken.Equals("calcular"))
                {
                    ejecutarOtros(simbolo);

                }
            }
            else
            {
                ejecutarHijos(simbolo);
            }

        }


        public void ejecutarRespuesta(elementoClase simbolo)
        /*
        |---------------------------- 
        | VISIBILIDAD + tRespuesta + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
        */
        {

            if (hayErrores())
                return;

            token tipo = new token("vacio");
            token nombre = lstAtributos.getToken(0);


            nombre.val = "_respuesta";
            nombre.valLower = "_respuesta";



            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad = getVisibilidad(simbolo);
            int dimension = 0;

            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstMetodo_funcion.insertarElemento(element);


        }

        public void ejecutarOtros(elementoClase simbolo)
        {
            if (hayErrores())
                return;

            token tipo = new token("vacio");
            token nombre = lstAtributos.getToken(0);

            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad = getVisibilidad(simbolo);
            int dimension = 0;

            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstMetodo_funcion.insertarElemento(element);
        }

        public token getVisibilidad(elementoClase elem)
        {

            nodoModelo tempNodo = getNodo("VISIBILIDAD");
            if (tempNodo != null)
            {
                _VISIBILIDAD visi = (_VISIBILIDAD)tempNodo;
                return visi.getVisibilidad();
            }
            else
                //Si no tiene visibilidad retorno la visibilidad de la clase, jake mate ateo! 
                return elem.visibilidad;

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
