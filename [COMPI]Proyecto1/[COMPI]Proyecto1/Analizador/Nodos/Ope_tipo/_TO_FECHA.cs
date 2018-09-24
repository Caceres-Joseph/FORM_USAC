using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _TO_FECHA : nodoModelo
    /*
   ------------------------------------------
   *  TO_FECHA.Rule = tFecha + sAbreParent + E + sCierraParent;
   ------------------------------------------
   * Retorno: fecha
   */
    {
        public _TO_FECHA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (hijos.Count != 1)
                return retorno;





            _E nodoE2 = (_E)hijos[0];

            if (hayErrores())
                return retorno;


            itemValor itemInicio = nodoE2.getValor(elem);



            if (itemInicio.isTypeFecha())
            {
                return itemInicio;
            }
            else if (itemInicio.isTypeCadena())
            {
                itemValor tel = new itemValor();
                tel.convertirCadena(itemInicio.getCadena());

                if (tel.isTypeFecha())
                {
                    retorno = tel;
                    return retorno;
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear a fecha", lstAtributos.getToken(0));
                    return retorno;
                }

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se pueden parsear a fecha expresiones que no sean cadenas", lstAtributos.getToken(0));
                return retorno;
            }
        }
    }
}
