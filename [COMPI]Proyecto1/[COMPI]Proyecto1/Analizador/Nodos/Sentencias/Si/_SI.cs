using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.Si
{
    class _SI : nodoModelo
    /*
        SI.Rule = tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
            | tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SINO_SI
            | tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SINO;
     */
    {
        public _SI(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno elementoEntor)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;

            _E nodoE = (_E)getNodo("E");
            itemValor valE = nodoE.getValor(elementoEntor);
            Object objetoValor = valE.getValorParseado("booleano");
            Boolean condicion = false;

            if (objetoValor != null)
            {
                condicion = (Boolean)objetoValor;

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La condición devulelta no es de tipo booleano,es de tipo:" + valE.getTipo(), lstAtributos.getToken(0));
                return retorno;
            }


            if (hijos.Count == 2)
            /*
            |---------------------------- 
            |  tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
            */
            {

                if (condicion)
                {
                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");


                    elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Si", elementoEntor.este);
                    return nodoCuerpo.ejecutar(entornoIf);

                }

            }
            else if (hijos.Count == 3)
            {
                string caso = hijos[2].nombre;

                if (caso.Equals("SINO_SI"))

                /*
                |---------------------------- 
                | tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SINO_SI
                */

                {
                    if (condicion)
                    {
                        _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");


                        elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Si", elementoEntor.este);
                        return nodoCuerpo.ejecutar(entornoIf);

                    }
                    else 
                    {
                        _SINO_SI sino_si = (_SINO_SI)getNodo("SINO_SI");
                        return sino_si.ejecutar(elementoEntor);
                    }
                }
                else if (caso.Equals("SINO"))
                /*
                |---------------------------- 
                | tSi + sAbreParent + E + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave + SINO;
                */
                {

                    if (condicion)
                    {

                        _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                        elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Si", elementoEntor.este);
                        return nodoCuerpo.ejecutar(entornoIf);
                    }
                    else
                    {
                        _SINO nodoSINO = (_SINO)getNodo("SINO");
                        elementoEntorno entornoSino = new elementoEntorno(elementoEntor, tablaSimbolos, "Sino", elementoEntor.este);
                        return nodoSINO.ejecutar(entornoSino);
                    }

                }
            }



            return retorno;
        }


    }
}
