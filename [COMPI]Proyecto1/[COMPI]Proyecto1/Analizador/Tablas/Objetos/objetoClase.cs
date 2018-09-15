using _COMPI_Proyecto1.Analizador.Tablas.Items;
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
            this.tablaEntorno = new tablaEntornos();
        }


        public void ejecutarGlobales()
        {
            cuerpoClase.lstVariablesGlobales.ejecutar(tablaEntorno.raiz); 
        }


    }
}
