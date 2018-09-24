using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_matematica
{
    class _POTENCIA : nodoModelo
    /*
    ------------------------------------------
    * POTENCIA.Rule = tPow + sAbreParent + E + sComa + E + sCierraParent;
    ------------------------------------------
    * Retorno:decimal
    */

    {
        public _POTENCIA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (hijos.Count != 2)
                return retorno;

             
            String tipo2 = "entero";

             
            _E nodoE2 = (_E)hijos[0];
            _E nodoE3 = (_E)hijos[1];

            if (hayErrores())
                return retorno;
             
            int inicioVal = 0;
            int finalVal = 0;
             


            itemValor itemInicio = nodoE2.getValor(elem);
            Object inicioTemp = itemInicio.getValorParseado(tipo2);


            itemValor itemFinal = nodoE3.getValor(elem);
            Object finalTemp = itemFinal.getValorParseado(tipo2);


 
            if (inicioTemp != null)
            {
                inicioVal = (int)inicioTemp;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a entero el valor", lstAtributos.getToken(0));
                return retorno;
            }

            if (finalTemp != null)
            {
                finalVal = (int)finalTemp;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a entero el valor", lstAtributos.getToken(0));
                return retorno;
            }

            if (inicioVal==0 || finalVal == 0)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("Potencia con base 0 elevado a 0 es indeterminado", lstAtributos.getToken(0));
                return retorno;
            }

            retorno.setValue(Math.Pow(inicioVal, finalVal));


            return retorno;

        }

    }
}
