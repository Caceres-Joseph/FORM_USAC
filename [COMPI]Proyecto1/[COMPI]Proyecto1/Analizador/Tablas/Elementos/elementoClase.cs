using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class elementoClase
    {
        public lstPrincipal lstPrincipal;
        public lstMetodo_funcion lstMetodo_funcion;
        public lstConstructores lstConstructores;
        //public lstPolimorfismo lstSobrescritura;
        public lstVariablesGlobales lstVariablesGlobales;


        //extend saber de donde extendio 
        //nombre de la clase
        //variables globales
        //principal
        //constructores
        //metodos
        //funciones
        //override


        public token nombreClase;
        public token visibilidad;
        public token extender;
        public List<nodoModelo> lstHijos;
        public tablaSimbolos tablaErrores;


        /*
        |--------------------------------------------------------------------------
        | Constructor
        |--------------------------------------------------------------------------
        |
        */

        public elementoClase(token nombre, token visibilidad, token extender, List<nodoModelo> lstHijos, tablaSimbolos tabla)
        {
            this.tablaErrores = tabla;
            this.lstHijos = lstHijos;
            this.nombreClase = nombre;
            this.visibilidad = visibilidad;
            this.extender = extender;

            


            this.lstPrincipal = new lstPrincipal(this.tablaErrores, "principales");
            this.lstMetodo_funcion = new lstMetodo_funcion(this.tablaErrores, "metodos_funciones");
            this.lstConstructores = new lstConstructores(this.tablaErrores, "constructores");
            //this.lstSobrescritura = new lstPolimorfismo(this.tablaErrores, "sobrescritura");
            this.lstVariablesGlobales = new lstVariablesGlobales(this.tablaErrores, "var_globales");
        }


        /*
        |--------------------------------------------------------------------------
        | Métodos para imprimir
        |--------------------------------------------------------------------------
        |
        */


        public void imprimir()
        {
            println(nombreClase.valLower + "{");
            println("\tVisibilidad:" + visibilidad.valLower);
            println("\tExtender:" + extender.valLower);

            imprimirListas(); 
            println("}");
        }

        public void println(String mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void imprimirListas()
        {
            lstPrincipal.imprimir();
            lstMetodo_funcion.imprimir();
            lstConstructores.imprimir();
            //lstSobrescritura.imprimir();
            lstVariablesGlobales.imprimir();

        }



        /*
        |--------------------------------------------------------------------------
        | Cargando ya la tabla de entornos
        |--------------------------------------------------------------------------
        |
        */
         
        public void ejecutarPrincipal()
        {

        }

        public void ejecutarConstructor()
        {

        }


    }
}
