using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.Caso
{
    class _CASO : nodoModelo
    /*
       CASO.Rule = tCaso + sAbreParent + E + sCierraParent + tDe + sAbreLlave + CUERPO_CASE + sCierraLlave;
     */
    {
        public _CASO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            /*
            |---------------------------- 
            |  tCaso + sAbreParent + E + sCierraParent + tDe + sAbreLlave + CUERPO_CASE + sCierraLlave;
            */
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;

            _E nodoE = (_E)getNodo("E");
            itemValor valE = nodoE.getValor(elementoEntor);

            _CUERPO_CASE nodoCuerpo = (_CUERPO_CASE)hijos[1];
            elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "case", elementoEntor.este);
            itemRetorno cuerpoCase = nodoCuerpo.ejecutar(entornoIf, valE);


            if (cuerpoCase.isRomper())
                //este codigo sirve para eliminar el romper en los nodos, más arriba, y solo se quede en el case
            { 
                return new itemRetorno(0);
            }
            else
            {
                return retorno;
            }
            
        }
    }
}
