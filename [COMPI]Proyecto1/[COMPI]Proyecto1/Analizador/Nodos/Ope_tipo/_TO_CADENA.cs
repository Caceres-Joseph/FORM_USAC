using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _TO_CADENA : nodoModelo
    /*
            TO_CADENA.Rule = tCadena + sAbreParent + E + sCierraParent;
     */
    {
        public _TO_CADENA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            _E nodoE = (_E)getNodo("E");
            itemValor valE = nodoE.getValor(elem);

            String tipo = "cadena";

            Object resul = valE.getValorParseado(tipo);
            if (resul != null)
            {

                String cadena = (String)resul;
                retorno.setValue(cadena);
                return retorno;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a " + tipo + " el valor", lstAtributos.getToken(0));
                return retorno;
            }
             
        }
    }
}
