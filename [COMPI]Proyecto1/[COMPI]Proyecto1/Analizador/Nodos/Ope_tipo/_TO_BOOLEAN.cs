using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _TO_BOOLEAN : nodoModelo
    /*
    ------------------------------------------
    * TO_BOOLEAN.Rule = tBooleano + sAbreParent + E + sCierraParent;
    ------------------------------------------
    */
    {
        public _TO_BOOLEAN(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            String tipo1 = "booleano"; 


            _E nodoE1 = (_E)hijos[0]; 


            if (hayErrores())
                return retorno;

            Boolean boolVal = false;



            itemValor itemBool = nodoE1.getValor(elem);
            Object boolObject = itemBool.getValorParseado(tipo1);

             
            if (boolObject != null)
            {
                boolVal = (Boolean)boolObject;
                retorno.setValue(boolVal);
                return retorno;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a booleano el valor", lstAtributos.getToken(0));
                return retorno;
            }
             
             

        }
    }
}
