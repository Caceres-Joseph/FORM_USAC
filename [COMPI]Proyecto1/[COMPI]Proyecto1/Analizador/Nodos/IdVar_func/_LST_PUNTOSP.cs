using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos.IdVar_func
{
    class _LST_PUNTOSP : nodoModelo
    {

        /*
        
            LST_PUNTOSP.Rule -> sPunto + valId
                              | sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                

        */
        public _LST_PUNTOSP(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }
    }
}
