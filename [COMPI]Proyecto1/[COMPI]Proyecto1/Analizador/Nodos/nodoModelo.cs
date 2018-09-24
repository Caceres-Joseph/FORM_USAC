using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
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
        public lstAtributos lstAtributos;
       // public elementoClase clase=new elementoClase(new token("",0,0,"--"), new token("", 0, 0, "--"), new token("", 0, 0, "--"), false);

        public tablaSimbolos tablaSimbolos;

        public nodoModelo(String nombre, tablaSimbolos tabla)
        {
            
            this.nombre = nombre;
            this.tablaSimbolos = tabla;
            this.lstAtributos = new lstAtributos(tablaSimbolos);
        }

        public void insertar(nodoModelo hijo)
        {
            hijos.Add(hijo);
        }

        /*
        |--------------------------------------------------------------------------
        | La ejecución FINAL con ITem entorno
        |--------------------------------------------------------------------------
        |
        

        public virtual void ejecutar(elementoEntorno elem, itemEntorno item)
        {
            ejecutarHijos(elem, item);
        }

        public void ejecutarHijos(elementoEntorno elem, itemEntorno item)
        {

            if (hayErrores())
                return;

            foreach (nodoModelo temp in hijos)
            {
                temp.ejecutar(elem, item);
            }
        }*/


        /*
        |--------------------------------------------------------------------------
        | La ejecución FINAL
        |--------------------------------------------------------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */

        public virtual itemRetorno ejecutar(elementoEntorno tablaEntornos)
        {
             
            
            itemRetorno resultado=ejecutarHijos(tablaEntornos);
            return resultado;
              
        }

        public itemRetorno ejecutarHijos(elementoEntorno elem)
        {

            itemRetorno retorno = new itemRetorno(0);

            if (hayErrores())
                return retorno;


            foreach (nodoModelo temp in hijos)
            {

                itemRetorno resultado = temp.ejecutar(elem);
                if (resultado.isNormal())
                {
                    //continua normal
                }
                else
                {

                    return resultado;
                }
               
            }

            return retorno;
        }


        /*
        |--------------------------------------------------------------------------
        | Para construir el arbol
        |--------------------------------------------------------------------------
        |
        */
        public virtual void ejecutar()
        {

            ejecutarHijos();

        }

        public void ejecutarHijos()
        {

            if (hayErrores()) 
                return; 

            foreach (nodoModelo temp in hijos)
            {
                // Console.WriteLine("[nodoModelo]EjecutarHijos_padre:" + nombre + "->hijo:" + temp.nombre);
                temp.ejecutar();
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Para cargas el cuerpo de la clase
        |--------------------------------------------------------------------------
        |
        */
        public virtual void ejecutar(elementoClase simbolo)
        {
            ejecutarHijos(simbolo);
        }
        public void ejecutarHijos(elementoClase elemento)
        {


            if (hayErrores()) 
                return; 

            foreach (nodoModelo temp in hijos)
            {
                // Console.WriteLine("[nodoModelo]EjecutarHijos_padre:" + nombre + "->hijo:" + temp.nombre);
                temp.ejecutar(elemento);
            }
        }
        /*
        |--------------------------------------------------------------------------
        | Cargando el elemento polimorfo, el que tiene metdos/func/vari
        |--------------------------------------------------------------------------
        |
        */

        public virtual void cargarPolimorfismo(elementoPolimorfo elem)
        {
            cargarPolimorfismoHijos(elem);
        }
        public void cargarPolimorfismoHijos(elementoPolimorfo elemento)
        {
             
            if (hayErrores()) 
                return;
            
            foreach (nodoModelo temp in hijos)
            {
                // Console.WriteLine("[nodoModelo]EjecutarHijos_padre:" + nombre + "->hijo:" + temp.nombre);
                temp.cargarPolimorfismo(elemento);
            }
        }




        /*
        |--------------------------------------------------------------------------
        | Imprimir NOdos
        |--------------------------------------------------------------------------
        |
        */

        public void imprimirNodos()
        {
            foreach (nodoModelo temp in hijos)
            {
                Console.WriteLine("padre:" + nombre + "->hijo:" + temp.nombre);
                temp.ejecutar();
            }
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones ope Tipo
        |-------------------------------------------------------------------------------------------------------------------
        |  
        */

        public virtual itemValor ope_tipo( elementoEntorno elem)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();
            return retorno;
        }





        public virtual void cargarImports()
        {
            if (hayErrores())
                return;

            foreach(nodoModelo temp in hijos)
            {
               // Console.WriteLine("[nodoModelo]cargarImports_padre:" + nombre + "->hijo:" + temp.nombre);
                temp.cargarImports();
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

        public nodoModelo getNodo(String nombre)
        {

            nodoModelo retorno = null;

            foreach (nodoModelo temp in hijos)
            {
                if (temp.nombre.Equals(nombre))
                {
                    retorno = temp;
                    break;
                }
            }

            return retorno;

        }

        public void imprimirAtributos()
        {
            println(nombre + "{");
            lstAtributos.imprimir();
            println("}");

        }


        public void println(String mensaje)
        {
            Console.WriteLine("[" +nombre +"]"+ mensaje);
        }

        public void print(String mensaje)
        {
            Console.Write(mensaje);
        }
    }
}
