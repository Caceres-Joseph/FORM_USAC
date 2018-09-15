using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    class lstVariablesGlobales : lstPolimorfismo
    {
        public lstVariablesGlobales(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }


        public override void ejecutar(elementoEntorno elem)
        {
            foreach (elementoPolimorfo temp in listaPolimorfa)
            {




                itemEntorno it = new itemEntorno(temp.nombre, temp.tipo, new itemValor(), temp.visibilidad, temp.dimension);
                if (temp.LST_CUERPO.nombre.Equals("VAL"))
                    //Si es una variable con valor
                    temp.LST_CUERPO.ejecutar(elem, it); 
                else
                {
                    //hay que asignarle el valor nulo
                    //println("la variable no tiene valor");
                }
            }
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[lstVariablesGlobales]" + mensaje);
        }
    }
}
