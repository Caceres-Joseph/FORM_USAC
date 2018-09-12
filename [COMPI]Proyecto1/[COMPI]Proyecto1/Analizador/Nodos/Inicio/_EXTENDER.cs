using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _EXTENDER : nodoModelo
    {
        public _EXTENDER(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public override void ejecutar()
        {
        }

        public override void ejecutar(elementoClase simbolo)
        {
        }


        public token getExtender()
        {
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 0)
            {//si hay visibilidad
                //tPadre + valId
                retorno = lstAtributos.getToken(1);
            }
            else
            {//no hay extender prro
                retorno = new token("");
            }

            return retorno;

        }
    }
}
