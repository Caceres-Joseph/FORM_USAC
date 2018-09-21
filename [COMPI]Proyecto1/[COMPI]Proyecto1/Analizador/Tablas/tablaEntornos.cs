using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas
{
    class tablaEntornos
    {
        public elementoEntorno raiz;
        public tablaSimbolos tabla;
        public tablaEntornos(tablaSimbolos tabla, objetoClase este)
        {
            raiz = new elementoEntorno(null, tabla,"global", este);
        }


        public void imprimir()
        {

            raiz.imprimir();
            return;
            elementoEntorno actual = raiz;

            do
            {

                actual.imprimir();
                actual = actual.anterior;
            } while (actual.anterior != null);
        }

    }
}
