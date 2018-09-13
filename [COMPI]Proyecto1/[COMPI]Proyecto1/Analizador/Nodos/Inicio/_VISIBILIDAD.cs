using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VISIBILIDAD : nodoModelo
    {
        public _VISIBILIDAD(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar()
        {
        }

        public override void ejecutar(elementoClase simbolo)
        {
        }


        public  token getVisibilidad()
        {
            token retorno = new token("privado");

            if (lstAtributos.listaAtributos.Count>0)
            {
                retorno = lstAtributos.getToken(0);
            }

            return retorno;
            
        }
    }
}
