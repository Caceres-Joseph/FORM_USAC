using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemValor
    {

        public string tipo;
        public Object valor;
        public itemValor(string tipo)
        {
            this.tipo = tipo;
            this.valor = new object();
        }

        public itemValor()
        {
            this.tipo = "nulo";
            this.valor = new object();
        }
    }
}
