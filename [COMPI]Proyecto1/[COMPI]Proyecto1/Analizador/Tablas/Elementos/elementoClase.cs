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
        public lstPolimorfismo lstPrincipal;
        public lstPolimorfismo lstMetodo_funcion;
        public lstPolimorfismo lstConstructores;
        //public lstPolimorfismo lstSobrescritura;
        public lstPolimorfismo lstVariablesGlobales;

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
        
        //public Boolean hayMain;

        public List<nodoModelo> lstHijos;
        public tablaSimbolos tablaErrores;
        /*public elementoClase(token nombre)
         {
             this.nombreClase = nombre;

         }*/

        public elementoClase(token nombre, token visibilidad, token extender, List<nodoModelo> lstHijos, tablaSimbolos tabla)
        {
            this.tablaErrores = tabla;
            this.lstHijos = lstHijos;
            this.nombreClase = nombre;
            this.visibilidad = visibilidad;
            this.extender = extender;



            this.lstPrincipal = new lstPolimorfismo(this.tablaErrores, "principales");
            this.lstMetodo_funcion = new lstPolimorfismo(this.tablaErrores, "metodos_funciones");
            this.lstConstructores = new lstPolimorfismo(this.tablaErrores, "constructores");
            //this.lstSobrescritura = new lstPolimorfismo(this.tablaErrores, "sobrescritura");
            this.lstVariablesGlobales = new lstPolimorfismo(this.tablaErrores, "var_globales");
        }


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




        public void ejecutar()///me tiene que retornar una tabla de funciones/constructores
        {

        }

        /*
         * Siempre tengo que recibir una tabla de simbolos
         */

        public void ejecutarMetodoFuncion()
        {

        }



    }
}
