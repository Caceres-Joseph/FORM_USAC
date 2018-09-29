using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos.Cuerpo
{
    class _LST_CUERPO2 : nodoModelo
    {
        public _LST_CUERPO2(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void cargarPolimorfismo(elementoPolimorfo elem)
        {
            //para no seguir ejecutando 
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemRetorno ejecutarConstructor(elementoEntorno tablaEntornos, lstValores parametros)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(2);

            println("ejecutnando el constructor que hice de pregunta ========#/(&/$$$$$$$$$$$$$$");


            foreach (itemValor tem in parametros.listaValores)
            {
                println("--------");
                tem.imprimirVariable();
            }
            return retorno;
        }

    }
}
