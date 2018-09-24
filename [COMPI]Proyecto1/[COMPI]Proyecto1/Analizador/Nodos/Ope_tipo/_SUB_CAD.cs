using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _SUB_CAD : nodoModelo
    /*
            SUB_CAD.Rule = tSubCad + sAbreParent + E + sComa + E + sComa + E + sCierraParent;
     */
    {
        public _SUB_CAD(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (hijos.Count != 3)
                return retorno;


            String tipo1 = "cadena";
            String tipo2 = "entero";


            _E nodoE1 = (_E)hijos[0];
            _E nodoE2 = (_E)hijos[1];
            _E nodoE3 = (_E)hijos[2];

            if (hayErrores())
                return retorno;

            String cadenaVal = "";
            int inicioVal = 0;
            int finalVal = 0;

            itemValor itemCadena = nodoE1.getValor(elem);
            Object cadenaTemp = itemCadena.getValorParseado(tipo1);


            itemValor itemInicio = nodoE2.getValor(elem);
            Object inicioTemp = itemInicio.getValorParseado(tipo2);


            itemValor itemFinal = nodoE3.getValor(elem);
            Object finalTemp = itemFinal.getValorParseado(tipo2);



            if (cadenaTemp != null)
            {
                cadenaVal = (String)cadenaTemp;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a cadena el valor", lstAtributos.getToken(0));
                return retorno;
            }

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

            if ((finalVal - inicioVal) > cadenaVal.Length || (finalVal - inicioVal) < 0)
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("El indice superior supera la longitud de la cadena", lstAtributos.getToken(0));
                return retorno;
            }

            String salida = cadenaVal.Substring(inicioVal, finalVal - inicioVal);
            retorno.setValue(salida);

            return retorno;

        }
    }
}
