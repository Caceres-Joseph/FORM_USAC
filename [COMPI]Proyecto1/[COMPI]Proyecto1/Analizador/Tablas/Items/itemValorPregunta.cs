using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemValorPregunta
    {

        public itemValor respuesta;

        public itemValorPregunta()
        {
            respuesta = new itemValor();
        }


        public itemValor getRespuesta()
        {
            return respuesta;
        }
    }
}
