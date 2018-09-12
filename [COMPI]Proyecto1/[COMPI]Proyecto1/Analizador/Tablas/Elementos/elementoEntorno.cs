using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class elementoEntorno
    {
        Dictionary<token, itemEntorno> lstEntorno;
        elementoEntorno anterior;

        public elementoEntorno(elementoEntorno anterior)
        {
            this.anterior = anterior;
        }


    }
}
