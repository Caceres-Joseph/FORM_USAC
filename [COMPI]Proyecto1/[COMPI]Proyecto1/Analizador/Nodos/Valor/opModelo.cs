using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor
{

    class opModelo
    {
        public _E hijo1;
        public _E hijo2;
        public token signo;
        public tablaSimbolos tabla;
        private nodoModelo hijo11;
        private nodoModelo hijo21;

        public opModelo(nodoModelo hijo11, nodoModelo hijo21, tablaSimbolos tabla)
        {
            this.hijo11 = hijo11;
            this.hijo21 = hijo21;
            this.tabla = tabla;
        }

        public opModelo(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo)
        {
            this.hijo1 = (_E)hijo1;
            this.hijo2 = (_E)hijo2;
            this.tabla = tabla;
            this.signo = signo;
        }

         

         

    }
}
