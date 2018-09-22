using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencia_Control
{
    class _RETORNO : nodoModelo


    /* 
            RETORNO.Rule = tRetorno + sPuntoComa
                | tRetorno + VALOR + sPuntoComa;
    */

    {
        public _RETORNO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            itemRetorno retorno = new itemRetorno(1);
            if (hayErrores())
                return retorno;


            if (hijos.Count > 0)
            /*
            |---------------------------- 
            | tRetorno + VALOR + sPuntoComa;
            */
            {
                nodoModelo nodoTemp = getNodo("VALOR");
                if (nodoTemp != null)
                {
                    _VALOR val = (_VALOR)nodoTemp;
                    itemValor tempValor = val.getValor(tablaEntornos,new token(""));

                    retorno.setValueRetorno(tempValor);
                    return retorno;

                }
                else
                {
                    return retorno;
                }
            }
            else
            /*
            |---------------------------- 
            |  RETORNO.Rule = tRetorno + sPuntoComa
            |------------------------------
            | Desde aquí ya no sigue la ejecución.
             */
            {

                return retorno;
            }


        }

    }
}
