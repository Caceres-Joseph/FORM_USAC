using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.GUI.Preguntas;

namespace _COMPI_Proyecto1.Analizador.Nodos.Multimedia
{
    class _AUDIO : nodoModelo
    /*
     * AUDIO.Rule = tImagen + sAbreParent + E + sComa + E + sCierraParent;
     */
    {
        public _AUDIO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(0);

            if (hayErrores())
                return retorno;


            if (hijos.Count != 2)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando dos parametros, ruta de audio, y valor booleano", lstAtributos.getToken(0));
                return retorno;
            }


            _E nodo1 = (_E)hijos[0];
            _E nodo2 = (_E)hijos[1];

            itemValor itRuta = nodo1.getValor(tablaEntornos);
            itemValor itBoolean = nodo2.getValor(tablaEntornos);

            Object objRuta = itRuta.getValorParseado("cadena");
            Object objBool = itBoolean.getValorParseado("booleano");

            if (objRuta == null || objBool == null)
            {

                tablaSimbolos.tablaErrores.insertErrorSemantic("Uno de los parámetros no fue cadena y/o booleano", lstAtributos.getToken(0));
                return retorno; 
            }
            else
            {

                string ruta = (string)objRuta;

                ruta=tablaSimbolos.getRutaProyecto()+"\\"+ruta;

                Boolean booleano = (Boolean)objBool;

                frmAudio fdecimal = new frmAudio(tablaEntornos,ruta, booleano);
                fdecimal.ShowDialog();
                return retorno;
                
            }
             
        }
    }
}
