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
    class _RANDOM : nodoModelo
    /*
    ------------------------------------------
    * RANDOM.Rule = tRandom + sAbreParent + LST_VAL + sCierraParent ;
    ------------------------------------------
    *retorno:entero/decimal/cadena
    */
    {
        public _RANDOM(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            lstValores listaValroes = nodoVals.getLstValores(elem);

            Random rnd = new Random();

            if (listaValroes.listaValores.Count>0)
            {


                int month = rnd.Next(0, listaValroes.listaValores.Count);
                itemValor item = listaValroes.getItemValor(month);

                if (item.isTypeNulo())
                {
                    retorno.setValue(0);
                    return retorno;
                }
                else
                {
                    return item;
                }
                

            }
            else
            {
                int dice = rnd.Next(0,2);
                retorno.setValue(dice);
                return retorno;

            }

             
        }


    }
}
