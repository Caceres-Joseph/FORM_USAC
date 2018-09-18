using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos.Asignar_Valor
{
    class _ASIG_VALOR : nodoModelo
    {
        public _ASIG_VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
