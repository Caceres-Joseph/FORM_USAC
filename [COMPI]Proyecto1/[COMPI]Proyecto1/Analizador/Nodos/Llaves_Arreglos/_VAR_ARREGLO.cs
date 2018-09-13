using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VAR_ARREGLO : nodoModelo
    {
        public _VAR_ARREGLO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }


        public token getIdentificador()
        {
            token retorno = new token();

            if (lstAtributos.listaAtributos.Count > 0)
            {
                retorno = lstAtributos.getToken(0);
            }

            return retorno;

        }

        public int getDimensiones()
        {
            int retorno = 0;
            nodoModelo tempNodo = getNodo("LST_CORCHETES");
            if (tempNodo != null)
            {
                _LST_CORCHETES temp = (_LST_CORCHETES)tempNodo;
                return temp.getDimension();
            }
            
            return retorno;
        }

    }
}
