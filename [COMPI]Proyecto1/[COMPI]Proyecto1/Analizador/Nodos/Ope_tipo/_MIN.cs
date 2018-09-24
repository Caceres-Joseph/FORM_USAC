using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _MIN : nodoModelo
    /*
    ------------------------------------------
    * MIN.Rule = tMin + sAbreParent + LST_VAL + sCierraParent;
    ------------------------------------------
    *retorno:entero/decimal
    */
    {
        public _MIN(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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



            _LST_VAL nodoVals = (_LST_VAL)getNodo("LST_VAL");
            if (nodoVals == null)
                return retorno;


            _TAM taman = new _TAM("TAM", tablaSimbolos);




            lstValores listaValroes = nodoVals.getLstValores(elem);




            if (listaValroes.listaValores.Count > 0)
            {
                int minimo = 0;

                int i = 0;
                foreach (itemValor itemVal in listaValroes.listaValores)
                {

                    if (i == 0)
                    {

                        itemValor  minimoItem = taman.calcularTamanio(itemVal, elem);
                        if (hayErrores())
                            return retorno;

                        minimo = (int)minimoItem.getValorParseado("entero");
                    }
                    else
                    {
                        itemValor minimoItem = taman.calcularTamanio(itemVal, elem);
                        if (hayErrores())
                            return retorno;

                        int enteroAnterio= (int)minimoItem.getValorParseado("entero");
                        if (enteroAnterio<minimo)
                        {
                            minimo = enteroAnterio;
                        }

                    }

                    i++;
                }

                retorno.setValue(minimo);
                return retorno;

            }
            else
            {

                retorno.setValue(0);
                return retorno;

            }
             

        }
    }
}
