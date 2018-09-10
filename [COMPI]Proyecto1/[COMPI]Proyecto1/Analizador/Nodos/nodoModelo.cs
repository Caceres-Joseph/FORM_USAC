using _COMPI_Proyecto1.Analizador.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class nodoModelo
    {

        public String nombre = "";
        public List<nodoModelo> hijos=new List<nodoModelo>();
        public tablaSimbolos tablaSimbolos;

        public nodoModelo(String nombre, tablaSimbolos tabla)
        {
            this.nombre = nombre;
            this.tablaSimbolos = tabla;
        }

        public void insertar(nodoModelo hijo)
        {
            hijos.Add(hijo);
        }

        public virtual void ejecutar()
        {

            //Console.WriteLine("Nodo:" + nombre );
            ejecutarHijos();
            
        }

        public void imprimirNodos()
        {
            foreach (nodoModelo temp in hijos)
            {
                Console.WriteLine("padre:" + nombre + "->hijo:" + temp.nombre);
                temp.ejecutar();
            }
        }

        public void ejecutarHijos()
        {

            if (hayErrores())
            {
                return;
            }

            foreach (nodoModelo temp in hijos)
            {
                Console.WriteLine("[nodoModelo]EjecutarHijos_padre:" + nombre + "->hijo:" + temp.nombre);
                temp.ejecutar();
            }
        }

        public Boolean hayErrores()
        {


            Boolean retorno = true;

            if (tablaSimbolos.tablaErrores.listaErrores.Count==0)
            {
                retorno = false;

            }
            else
            {
                tablaSimbolos.tablaErrores.println("No se puede ejecutar el nodo" + nombre + " porque hay errores en la tabla");
            }


            return retorno;


        }
    }
}
