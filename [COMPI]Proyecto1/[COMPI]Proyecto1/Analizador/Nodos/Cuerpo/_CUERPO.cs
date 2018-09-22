using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CUERPO : nodoModelo
    {
        public _CUERPO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        /*public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        {

            itemRetorno retorno = new itemRetorno(0);

            if (hayErrores())
                return retorno;

            foreach (nodoModelo temp in hijos)
            {

                int resultado = temp.ejecutar(tablaEntornos, retornoFuncion);
                if (resultado == 0)
                {
                    //continua normal
                }
                else
                {

                    println("ejecutarHijos->retorno :" + resultado);
                    println("retornoFuncion->" + retornoFuncion.getTipo());
                    return resultado;
                }

            }

            return 0;
        }*/
    }
}
