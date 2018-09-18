using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _FUNCIONES_NATIVAS : nodoModelo
    {
        public _FUNCIONES_NATIVAS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
