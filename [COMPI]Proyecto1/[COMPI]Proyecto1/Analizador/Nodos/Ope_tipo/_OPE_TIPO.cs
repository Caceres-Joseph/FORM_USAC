using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _OPE_TIPO : nodoModelo
    /*

            OPE_TIPO.Rule = TO_CADENA
                    | SUB_CAD
                    | POS_CAD
                    | TO_BOOLEAN
                    | TO_ENTERO
                    | HOY
                    | AHORA
                    | TO_FECHA
                    | TO_HORA
                    | TO_FECHAHORA
                    | TAM
                    | RANDOM
                    | MIN
                    | MAX;
     */
    {
        public _OPE_TIPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones ope Tipo
        |-------------------------------------------------------------------------------------------------------------------
        |  
        */



        public override itemValor ope_tipo(elementoEntorno elem)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            if (hijos.Count > 0)
            {
                return hijos[0].ope_tipo(elem);
            }

            return retorno;

        }
    }
}
