using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Objetos
{
    class objetoClase
    {

        public elementoClase cuerpoClase;
        public tablaEntornos tablaEntorno;
        public tablaSimbolos tablaSimbolos;
        //aqui tambien tiene que haber una tabla de entorno prro

        public objetoClase(elementoClase cuerpoClase, tablaSimbolos tabla)
        {
            this.tablaSimbolos = tabla;
            this.cuerpoClase = cuerpoClase;
            this.tablaEntorno = new tablaEntornos(tabla, this);
        }


        /*
        |----------------------------------------------
        |  Cargando las variables globales
        |----------------------------------------------
        */
        
        public void ejecutarGlobales()
        {
            cuerpoClase.lstVariablesGlobales.ejecutar(tablaEntorno.raiz);
        }

        /*
        |----------------------------------------------
        |  Ejecutando el constructor
        |----------------------------------------------
        */

        public void ejecutarConstructor(token nombre, int dimension, lstValores parametros, elementoEntorno tablaEntorno)
        {
         
            /*
             * Console.WriteLine("-------------");
            foreach (itemValor tmp in parametros.listaValores)
            {
                Console.WriteLine("[ObjetoClase]->");

                tmp.imprimirVariable();
            }
            */

            cuerpoClase.lstConstructores.ejecutarMetodo(nombre, parametros, tablaEntorno);
        }

        /*
        |----------------------------------------------
        |  Ejecutando una función o un método.
        |----------------------------------------------
        */

        public itemValor ejecutarMetodoFuncion(token nombre, lstValores parametros, elementoEntorno entorno)
        {
            /*foreach (itemValor tmp in parametros.listaValores)
            {



                Console.WriteLine("[ObjetoClase]->");
                Console.WriteLine("tipo->"+tmp.getTipo());
                Console.WriteLine("nombreObjeto->" + tmp.nombreObjeto);
                tmp.imprimirVariable();
            }*/

            return cuerpoClase.lstMetodo_funcion.getMetodoFuncion(nombre, parametros, entorno, nombre.valLower); 
             
        }


        /*
        |----------------------------------------------
        |  Ejecutando Forulario.
        |----------------------------------------------
        */

        public itemValor ejecutarFormulario(token nombre, lstValores parametros, elementoEntorno entorno)
        {
            /*foreach (itemValor tmp in parametros.listaValores)
            {



                Console.WriteLine("[ObjetoClase]->");
                Console.WriteLine("tipo->"+tmp.getTipo());
                Console.WriteLine("nombreObjeto->" + tmp.nombreObjeto);
                tmp.imprimirVariable();
            }*/

            return cuerpoClase.lstFormularios.getMetodoFuncion(nombre, parametros, entorno,"formulario");

        }

        /*
        |----------------------------------------------
        |  Ejecutando Constructor Heredado
        |----------------------------------------------
        */

        public void ejecutarConstructorHeredado( lstValores parametros, elementoEntorno tablaEntorno, token linea)
        {
             
            cuerpoClase.lstConstructoresHeredados.ejecutarConstructorHeredad( parametros, tablaEntorno, linea);
        }


        /*
        |----------------------------------------------
        |  Ejecutando el Main
        |----------------------------------------------
        */

        public void ejecutarPrincipal()
        {
            //hay que enviarle un nuevo enterno
            elementoEntorno hijo1 = new elementoEntorno(tablaEntorno.raiz, tablaSimbolos, "main", this);
            cuerpoClase.lstPrincipal.ejecutar(hijo1);
        }





        public void imprimirTablaEntornos()
        {
            Console.WriteLine("---------------------- Tabla de entornos ----------------------");
            tablaEntorno.imprimir();
        }

    }
}
