using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _USAR_VARIABLE : nodoModelo
    {
        public _USAR_VARIABLE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
