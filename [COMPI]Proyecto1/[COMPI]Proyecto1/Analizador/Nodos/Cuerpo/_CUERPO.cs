using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.IdVar_func;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CUERPO : nodoModelo
    {
        public _CUERPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

         
    }
}
