using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Diagrama
{
    
    class Clase
    {
        public string nombre = "";
        public string padre = "";
        public string acceso = "";
        public List<metodo> listaDeMetodos = new List<metodo>();
        public List<metodo> listaDeHeredados = new List<metodo>();
        public List<atributo> listaDeAtributos = new List<atributo>();

        public void imprimir()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Nombre->"+nombre);
            Console.WriteLine("Padre->"+padre);
            Console.WriteLine("Visibilidad->"+acceso);
            Console.WriteLine("---------[Atributos]--------");

            foreach (atributo atri in listaDeAtributos)
            {
                Console.WriteLine("| Acceso->"+atri.acceso+"| Tipo->"+atri.tipo+"| Nombre->"+atri.nombre);

            }
            Console.WriteLine("---------[Metodos]--------");

            foreach (metodo metodo in listaDeMetodos)
            {
                Console.WriteLine("| Acceso->" + metodo.acceso + "| Tipo->" + metodo.tipo + "| Nombre->" + metodo.nombre+"| Parametros->"+metodo.parametros);

            }
            Console.WriteLine("---------[Heredados]--------");

            foreach (metodo metodo in listaDeHeredados)
            {
                Console.WriteLine("| Acceso->" + metodo.acceso + "| Tipo->" + metodo.tipo + "| Nombre->" + metodo.nombre + "| Parametros->" + metodo.parametros);

            }
        }
    }
   
}
