using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    class lstPrincipal : lstPolimorfismo
    {
        public lstPrincipal(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }


        public override void ejecutar(elementoEntorno elem)
        {
            if (tabla.hayErrores("lstPrincipal_ejecutar"))
                return;

            if (listaPolimorfa.Count>0)
            {
                elementoPolimorfo temp = listaPolimorfa[0];
                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                {
                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;
                    val.ejecutar(elem);
                    imprimir(elem);

                }
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No se encuentra el main", new token());
            }
 
        }

        public void imprimir(elementoEntorno elem)
        {
          //  Console.WriteLine("-----La tabla de simbolos de pincipal----");
            elem.imprimir();
             
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[lstVariablesGlobales]" + mensaje);
        }
    }
}
