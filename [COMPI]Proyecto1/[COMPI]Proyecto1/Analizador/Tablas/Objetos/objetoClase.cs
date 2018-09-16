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
            this.tablaEntorno = new tablaEntornos(tabla);
        }

        public void ejecutarGlobales()
        {
            cuerpoClase.lstVariablesGlobales.ejecutar(tablaEntorno.raiz);
        }

        public void ejecutarConstructor(token nombre, int dimension, lstValores lstValores2, elementoEntorno tablaEntorno)
        {
            cuerpoClase.lstConstructores.ejecutarMetodo(nombre, dimension, lstValores2, tablaEntorno);

        }

        public void imprimirTablaEntornos()
        {
            Console.WriteLine("---------------------- Tabla de entornos ----------------------");
            tablaEntorno.imprimir();
        }


        public void ejecutarPrincipal()
        {
            //hay que enviarle un nuevo enterno
            elementoEntorno hijo1 = new elementoEntorno(tablaEntorno.raiz, tablaSimbolos, "main");
            cuerpoClase.lstPrincipal.ejecutar(hijo1);
        }
    }
}
