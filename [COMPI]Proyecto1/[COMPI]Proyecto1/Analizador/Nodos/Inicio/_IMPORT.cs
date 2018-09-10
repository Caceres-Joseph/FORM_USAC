using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _IMPORT : nodoModelo
    {
        public _IMPORT(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar()
        {
            if (hayErrores())
                return;

            tablaSimbolos.tablaErrores.println("Bucando el import en " + tablaSimbolos.rutaProyecto);
            



        }
    }
}
