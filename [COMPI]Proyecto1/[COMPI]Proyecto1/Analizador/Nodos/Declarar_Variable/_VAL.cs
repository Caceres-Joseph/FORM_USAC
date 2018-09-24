using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VAL : nodoModelo
    /*
     * VAL.Rule = sIgual + VALOR
     */
    {


        public _VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }

         

        public itemValor getValor(elementoEntorno elemento, token tipo)
        {


            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            if (hayErrores())
                return retorno;

            if (hijos.Count > 0)
            {
                nodoModelo hijo = hijos[0];
                _VALOR ope = (_VALOR)hijo;
                return ope.getValor(elemento, tipo);
            }

            return retorno;
        }

        public token getTokenIgual()
        {
            return lstAtributos.getToken(0);
        }

    }
}
