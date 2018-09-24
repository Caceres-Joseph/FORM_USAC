using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_matematica
{
    class _COSENO : nodoModelo

    /*
    ------------------------------------------
    * COSENO.Rule = tCoseno + sAbreParent + E + sCierraParent;
    ------------------------------------------
    * Retorno:decimal
    */
    {
        public _COSENO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            String tipo2 = "entero";


            _E nodoE2 = (_E)hijos[0];

            if (hayErrores())
                return retorno;

            int inicioVal = 0;



            itemValor itemInicio = nodoE2.getValor(elem);
            Object inicioTemp = itemInicio.getValorParseado(tipo2);


            if (itemInicio.isTypeDecimal())
            {
                retorno.setValue(Math.Cos(itemInicio.getDecimal()));
                return retorno;
            }
            else if (inicioTemp != null)
            {
                inicioVal = (int)inicioTemp;
                retorno.setValue(Math.Cos(inicioVal));
                return retorno;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a entero el valor", lstAtributos.getToken(0));
                return retorno;
            }

        }
    }
}
