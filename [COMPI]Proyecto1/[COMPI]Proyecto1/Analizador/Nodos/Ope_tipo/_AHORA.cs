using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _AHORA : nodoModelo
    /*
    ------------------------------------------
    * AHORA.Rule = tAhora + sAbreParent + sCierraParent;
    ------------------------------------------
    * Retorno: fechaHora
    */
     
    {
        public _AHORA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

             
            String temP = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            retorno.convertirCadena(temP);
            println(temP);

            return retorno;

        }
    }
}
