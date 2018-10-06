using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _LEN : nodoModelo

    /*
        SI_SIMPLIFICADO.Rule = VALOR + sCierraInterrogante + E + sDosPuntos + E + sPuntoComa;
        LEN.Rule = tLen + sAbreParent + E + sCierraParent;
     */
    {
        public _LEN(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
         
        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones ope Tipo
        |-------------------------------------------------------------------------------------------------------------------
        |  
        */

        public itemValor getValor(elementoEntorno elem)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            if (hijos.Count != 1)
                return retorno;

             

            _E nodoE2 = (_E)hijos[0]; 

            if (hayErrores())
                return retorno;


            itemValor itVal = nodoE2.getValor(elem);

            if (itVal.dimensiones.Count <= 0)
            {
                retorno.setValue(0);
            }
            else
            {
                retorno.setValue(itVal.dimensiones[0]);
            }
            return retorno;
        }
    }
}
