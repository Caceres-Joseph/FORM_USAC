using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Asignar_Valor;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.For
{
    class _FOR : nodoModelo
    /*
       FOR.Rule = tPara + sAbreParent + DECLARAR_VARIABLE_SINVISIBI + sPuntoComa + E + sPuntoComa + ASIG_VALOR+ sCierraParent+ sAbreLlave+ LST_CUERPO + sCierraLlave
            | tPara + sAbreParent + ASIG_VALOR + sPuntoComa + E + sPuntoComa + ASIG_VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;

     */

    {
        public _FOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            if (hijos[0].nombre.Equals("DECLARAR_VARIABLE_SINVISIBI"))

            /*
            |---------------------------- 
            |   tPara + sAbreParent + DECLARAR_VARIABLE_SINVISIBI + sPuntoComa + E + sPuntoComa + ASIG_VALOR+ sCierraParent+ sAbreLlave+ LST_CUERPO + sCierraLlave
            */
            {


                
                nodoModelo nodotemp = getNodo("DECLARAR_VARIABLE_SINVISIBI");

                if (nodotemp == null)
                    return retorno;


                _DECLARAR_VARIABLE_SINVISIBI decla = (_DECLARAR_VARIABLE_SINVISIBI)nodotemp;
                decla.ejecutar(elementoEntor);

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


                while (condicion)
                {

                    elementoEntorno entornoFor = new elementoEntorno(elementoEntor, tablaSimbolos, "para", elementoEntor.este);
                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");

                    retorno = nodoCuerpo.ejecutar(entornoFor);

                    //analizando el continue, el break, y el return



                    if (retorno.isRomper())
                    //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
                    {
                        return new itemRetorno(0);
                    }
                    else if (retorno.isRetorno())
                    {
                        return retorno;
                    }
                    else if (retorno.isContinuar())
                    {
                        return new itemRetorno(0);
                        //retorno = new itemRetorno(0);
                    }
                    else if (hayErrores())
                    {
                        return retorno;
                    }


                    //i++
                    _ASIG_VALOR asig = (_ASIG_VALOR)getNodo("ASIG_VALOR");
                    asig.ejecutar(entornoFor);


                    //volviendo analizar el while
                    nodoE = (_E)getNodo("E");
                    valE = nodoE.getValor(entornoFor);
                    objetoValor = valE.getValorParseado("booleano");
                    condicion = (Boolean)objetoValor;

                }

                if (retorno.isContinuar())
                {
                    return new itemRetorno(0);
                }


            }
            else if (hijos[0].nombre.Equals("ASIG_VALOR"))

            /*
            |---------------------------- 
            | tPara + sAbreParent + ASIG_VALOR + sPuntoComa + E + sPuntoComa + ASIG_VALOR + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
            */
            {

                
                nodoModelo nodotemp = getNodo("ASIG_VALOR");

                if (nodotemp == null)
                    return retorno;


                _ASIG_VALOR decla = (_ASIG_VALOR)hijos[0];
                decla.ejecutar(elementoEntor);

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


                while (condicion)
                {
                    elementoEntorno entornoFor = new elementoEntorno(elementoEntor, tablaSimbolos, "para", elementoEntor.este);

                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");

                    retorno = nodoCuerpo.ejecutar(entornoFor);

                    //analizando el continue, el break, y el return



                    if (retorno.isRomper())
                    //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
                    {
                        return new itemRetorno(0);
                    }
                    else if (retorno.isRetorno())
                    {
                        return retorno;
                    }
                    else if (retorno.isContinuar())
                    {
                        return new itemRetorno(0);
                        //retorno = new itemRetorno(0);
                    }
                    else if (hayErrores())
                    {
                        return retorno;
                    }


                    //i++
                    _ASIG_VALOR asig = (_ASIG_VALOR)hijos[2];
                    asig.ejecutar(entornoFor);


                    //volviendo analizar el while
                    nodoE = (_E)getNodo("E");
                    valE = nodoE.getValor(entornoFor);
                    objetoValor = valE.getValorParseado("booleano");
                    condicion = (Boolean)objetoValor;

                }

                if (retorno.isContinuar())
                {
                    return new itemRetorno(0);
                }
            }




            return retorno;
        }


    }
}
