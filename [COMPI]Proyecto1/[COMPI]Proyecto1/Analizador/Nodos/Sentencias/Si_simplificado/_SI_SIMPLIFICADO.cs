using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.Si_simplificado
{
    class _SI_SIMPLIFICADO : nodoModelo
    /*
        E + sCierraInterrogante + LST_CUERPO + sDosPuntos + LST_CUERPO + sPuntoComa;
     */
    {
        public _SI_SIMPLIFICADO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            /*
            |---------------------------- 
            | E + sCierraInterrogante + LST_CUERPO + sDosPuntos + LST_CUERPO + sPuntoComa;
            */
            {
                condicion = (Boolean)objetoValor;

                if (condicion)
                {
                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)hijos[1];
                    elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Si", elementoEntor.este);
                    return nodoCuerpo.ejecutar(entornoIf);

                }
                else
                {
                    _LST_CUERPO nodoCuerpo = (_LST_CUERPO)hijos[2];
                    elementoEntorno entornoIf = new elementoEntorno(elementoEntor, tablaSimbolos, "Sino", elementoEntor.este);
                    return nodoCuerpo.ejecutar(entornoIf);
                }
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La condición devulelta no es de tipo booleano,es de tipo:" + valE.getTipo(), lstAtributos.getToken(0));
                return retorno;
            }
             

        }


    }
}
