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

        public void ejecutar()
        {

            //Console.WriteLine("Nodo:" + nombre );

            foreach (nodoModelo temp in hijos)
            {
                Console.WriteLine("padre:" + nombre + "->hijo:"+temp.nombre);
                temp.ejecutar();
            }
        }
    }
}
