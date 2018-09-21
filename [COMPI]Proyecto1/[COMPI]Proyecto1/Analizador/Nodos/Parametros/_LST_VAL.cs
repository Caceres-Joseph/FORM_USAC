using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _LST_VAL : nodoModelo
    {
        public _LST_VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public lstValores getLstValores(elementoEntorno elemento)
        {
            println("getlstValores");
            lstValores retorno = new lstValores();

            foreach (nodoModelo hijo in hijos)
            {
                _VALOR temp = (_VALOR)hijo;

                itemValor temporal1 = temp.getValor(elemento, new token());
        

                retorno.insertar(temporal1);
            } 
            return retorno;

        }
    }
}
