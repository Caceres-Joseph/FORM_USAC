using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Cuerpo;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Pregunta
{
    class _PREGUNTA : nodoModelo
    /*
     * PREGUNTA.Rule = tPregunta + valId + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO_PREGUNTA + sCierraLlave;
     */
    {
        public _PREGUNTA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar(elementoClase simbolo)
        {
            if (hayErrores())
                return;

            token nombreClase = lstAtributos.getToken(1);
            token extender = new token("libform");
            token visibilidad = new token("privado");



            elementoClase nuevaClase = new elementoClase(nombreClase, visibilidad, extender, hijos, tablaSimbolos);

            ejecutarHijos(nuevaClase); 
            //cargarVariablesGlobales(nuevaClase);
            cargarConstructor(nuevaClase); 
            tablaSimbolos.lstPreguntas.Add(nuevaClase);

        }


        public void cargarVariablesGlobales(elementoClase simbolo)
        /*
        |---------------------------- 
        | Cargando las variables globales
        |----------------------------
        | Son las variables que voy a enviar en el constructor que tengo
        | que crear manualmente.
        | Aquí cargo los parametros como variables globales, jejejej
       */
        {
            if (hayErrores())
                return;


            _LST_PARAMETROS parametros= (_LST_PARAMETROS)getNodo("LST_PARAMETROS");

            foreach (elementoPolimorfo tempPolimorfo in parametros.getParametros())
            {
                simbolo.lstVariablesGlobales.insertarElemento(tempPolimorfo);
            }

             

        }

        public void cargarConstructor(elementoClase simbolo)
        /*
        |---------------------------- 
        | Constructor
        |----------------------------
        | Este constructor también lo voy a crear manualmente
        | y me va servir para pasar los parametros que vienen en la pregunta.
        */
        {

            if (hayErrores())
                return;

            token nombreClase = lstAtributos.getToken(1);
            token tipo = new token("vacio");
              

            elementoPolimorfo element = new elementoPolimorfo(new token("publico"), tablaSimbolos, tipo, nombreClase, new _LST_CUERPO2("LST_CUERPO2", tablaSimbolos), 0);

            _LST_PARAMETROS parametros = (_LST_PARAMETROS)getNodo("LST_PARAMETROS");

            foreach (elementoPolimorfo tempPolimorfo in parametros.getParametros())
            {
                element.insertarParametro(tempPolimorfo.nombre, tempPolimorfo.tipo, tempPolimorfo.dimension);
            } 

            simbolo.lstConstructores.insertarElemento(element); 
        }

    }
}
