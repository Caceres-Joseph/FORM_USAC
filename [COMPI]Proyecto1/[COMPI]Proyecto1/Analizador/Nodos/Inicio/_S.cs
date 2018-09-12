using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _S : nodoModelo
    {
        public _S(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }

        public override void ejecutar()
        {
            if (hayErrores())
                return;
            
            //ejecutando al contrario, primero el cuerpo de la clase luego el import

            for (int i =hijos.Count; i>0; i--)
            {
                hijos[i-1].ejecutar();
            }
            
        }

    }
}
