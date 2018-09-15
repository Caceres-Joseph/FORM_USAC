using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor
{
    class opAritmetica
    {
        _E hijo1;
        _E hijo2;
        public opAritmetica(nodoModelo hijo1, nodoModelo hijo2)
        {
            _E e1 = (_E)hijo1;
            _E e2 = (_E)hijo2;
            
        }


        public itemValor opSuma()
        {
            itemValor ob = null;

            itemValor val1 = hijo1.getValor();
            itemValor val2 = hijo2.getValor();

            //aquí hay que parsear los objetos


            return ob;
        }


    }
}
