using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.IdVar_func
{
    class _ID_VAR_FUNC : nodoModelo
    {
        itemValor retorno = new itemValor();
      

        /*
        
            ID_VAR_FUNC.Rule = ID_VAR_FUNC + LST_PUNTOSP
                             | tEste + sPunto + valId
                             | valId
                             | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                             | valId + sAbreParent + LST_VAL + sCierraParent;
        */

        elementoEntorno elementoEntorno;

        public _ID_VAR_FUNC(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override void ejecutar(elementoEntorno tablaEntornos)
        {

            this.elementoEntorno = tablaEntornos;
        }


        public itemValor getValor(elementoEntorno tablaEntornos)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeVacio();

            this.retorno.setTypeVacio(); //no puede retornar nada, es un metodo mahe
            this.elementoEntorno = tablaEntornos;




            if (lstAtributos.listaAtributos.Count == 0)
            /*
            |---------------------------- 
            |  ID_VAR_FUNC + LST_PUNTOSP 
            */
            {

            }



            if (lstAtributos.listaAtributos.Count == 1)
            /*
            |---------------------------- 
            | valId 
            */
            {
                String item1 = lstAtributos.listaAtributos[0].nombretoken;

                if (item1.Equals("valId"))

                {
                    return getValId(lstAtributos.listaAtributos[0].tok, elementoEntorno);
                }

            }

            if (lstAtributos.listaAtributos.Count == 3)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                String item3 = lstAtributos.listaAtributos[2].nombretoken;

                if (item1.Equals("este") && item2.Equals(".") && item3.Equals("valId"))
                /*
                |---------------------------- 
                |  tEste + sPunto + valId
                */
                {




                }
                if (item1.Equals("valId") && item2.Equals("(") && item3.Equals(")"))
                /*
                |---------------------------- 
                |  valId + sAbreParent + LST_VAL + sCierraParent;
                */
                {




                }

            }

            if (lstAtributos.listaAtributos.Count == 5)
            /*
            |---------------------------- 
            | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
            */
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                String item3 = lstAtributos.listaAtributos[2].nombretoken;

                if (item1.Equals("este") && item2.Equals(".") && item2.Equals("valId"))
                {

                }

            }


            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FUnciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemValor getValId(token idVal, elementoEntorno elem)
        // aquí hay que buscar dentro de la tabla de simbolos y devoler el valor, e ir buscando
        // hacia atraás para encontral el id
        {
            println("getValId_Buscando  en la tabla de simbolos el idVal" + idVal);
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            itemEntorno et = elem.getItemValor(idVal.valLower);
            if (et!=null)
            {
                return et.valor;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha declarado la variable : " + idVal.val+ " o no tiene permisos para acceder a ella", idVal);
            }

            return retorno;

        }
    }
}
