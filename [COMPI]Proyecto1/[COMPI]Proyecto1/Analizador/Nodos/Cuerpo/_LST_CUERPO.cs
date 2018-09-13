using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _LST_CUERPO : nodoModelo
    {
        public _LST_CUERPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void cargarPolimorfismo(elementoPolimorfo elem)
        {
            //para no seguir ejecutando 
        }
    }

}
