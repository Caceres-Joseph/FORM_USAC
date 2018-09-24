using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.While
{
    class _WHILE : nodoModelo
    /*
            WHILE.Rule = tMientras + sAbreParent + E + sCierraParent +  sAbreLlave + LST_CUERPO + sCierraLlave;
     */
    {
        public _WHILE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

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


            while (condicion)
            {

                _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");

                elementoEntorno entornoWhile = new elementoEntorno(elementoEntor, tablaSimbolos, "While", elementoEntor.este);
                retorno = nodoCuerpo.ejecutar(entornoWhile);

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


                //volviendo analizar el while
                nodoE = (_E)getNodo("E");
                valE = nodoE.getValor(elementoEntor);
                objetoValor = valE.getValorParseado("booleano");
                condicion = (Boolean)objetoValor;

            }

            if (retorno.isContinuar())
            {
                return new itemRetorno(0);
            }
            return retorno;
        }

    }
}
