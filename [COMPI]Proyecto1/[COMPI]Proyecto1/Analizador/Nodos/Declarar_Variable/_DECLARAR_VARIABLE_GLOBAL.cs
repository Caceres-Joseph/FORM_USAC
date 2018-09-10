using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _DECLARAR_VARIABLE_GLOBAL : nodoModelo
    {
        public _DECLARAR_VARIABLE_GLOBAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
