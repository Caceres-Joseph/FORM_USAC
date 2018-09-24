using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_matematica
{
    class _OPE_ARITME : nodoModelo
    /*
        OPE_ARITME.Rule = POTENCIA
                | LOGARITMO
                | LOGARITMO10
                | ABSOLUTO
                | SENO
                | COSENO
                | TANGENTE
                | RAIZ
                | PI;
     */
    {
        public _OPE_ARITME(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            if (hijos.Count > 0)
            {
                return hijos[0].ope_tipo(elem);
            }

            return retorno;

        }
    }
}
