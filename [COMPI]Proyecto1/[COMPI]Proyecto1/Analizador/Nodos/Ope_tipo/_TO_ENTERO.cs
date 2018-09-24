using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _TO_ENTERO : nodoModelo
    /*
    ------------------------------------------
    * TO_ENTERO.Rule = tEntero + sAbreParent + E + sCierraParent;
    ------------------------------------------
    */
    {
        public _TO_ENTERO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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


            _E nodoE1 = (_E)hijos[0];


            if (hayErrores())
                return retorno;

            int intVal = 0;

            

            itemValor itemInicio = nodoE1.getValor(elem);
            Object intObject = itemInicio.getValorParseado(tipo2);



            if (intObject != null)
            {
                intVal = (int)intObject;
                retorno.setValue(intVal);
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
