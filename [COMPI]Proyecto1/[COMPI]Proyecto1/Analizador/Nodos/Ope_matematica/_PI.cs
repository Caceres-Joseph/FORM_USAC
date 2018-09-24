using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_matematica
{
    class _PI : nodoModelo
    /*
    ------------------------------------------
    * RAIZ.Rule = tSqrt + sAbreParent + E + sCierraParent;
    ------------------------------------------
    * Retorno:decimal
    */

    {
        public _PI(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

 

            Double pi = Math.PI;
            retorno.setValue(pi);
             
            return retorno;

        }
    }
}
