using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemAtributo
    {
        public token tok;
        public String nombretoken;
        public itemAtributo(token tok ,String nombretoken)
        {
            this.tok = tok;
            this.nombretoken = nombretoken;
        }
    }
}
