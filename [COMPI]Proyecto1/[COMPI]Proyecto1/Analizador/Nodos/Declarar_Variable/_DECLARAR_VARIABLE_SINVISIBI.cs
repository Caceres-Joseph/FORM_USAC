using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _DECLARAR_VARIABLE_SINVISIBI : nodoModelo
    {
        public _DECLARAR_VARIABLE_SINVISIBI(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
