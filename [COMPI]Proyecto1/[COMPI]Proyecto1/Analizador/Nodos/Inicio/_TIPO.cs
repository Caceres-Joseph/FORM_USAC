using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _TIPO : nodoModelo
    {
        public _TIPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public token getTipo()
        {
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 0)
            {
                retorno = lstAtributos.getToken(0);
            }

            return retorno;

        }
    }
}
