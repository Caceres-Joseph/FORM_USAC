using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Gramatica;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.AST;
using FastColoredTextBoxNS;

namespace _COMPI_Proyecto1.Analizador.Arbol
{
    class arbol
    {

        //aqui tengo que definir la tabla de simbolos, 
        //tener una tabla de errores 

        //y la raíz


        public tablaSimbolos tablaDeSimbolos ;
        public nodoModelo raizArbol;
       // public String rutaDeLaCarpeta = "";


        public arbol(FastColoredTextBox cuadro)
        {
            

            tablaDeSimbolos = new tablaSimbolos(cuadro);
            //tablaDeSimbolos.setRutaProyecto("ruta prueba prro");
            raizArbol = new nodoModelo("raiz", tablaDeSimbolos);
        }

        public void setRutaProyecto(String ruta)
        {
            tablaDeSimbolos.setRutaProyecto(ruta);
        }

        public Boolean iniciarAnalisis(String cadena, String nombreArchivo)
        {

            //Console.WriteLine("[arbol]rutaProyecto->" + tablaDeSimbolos.getRutaProyecto());
            Boolean retorno = false;

            //GENERANDO EL AST DE IRONY

            gramatica gramatica = new gramatica(tablaDeSimbolos.tablaErrores, nombreArchivo);
            
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            //GENERANDO EL ARBOL

            generarArbol generar = new generarArbol(gramatica.nombreArchivo);
            
            
            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                retorno = false;

            }
            else
            {
               
                // seman.S(raiz);
                grafo.generarImagen(raiz);
               
                raizArbol = generar.generar(raizArbol, raiz, tablaDeSimbolos);
                //tablaDeSimbolos.lstAst.Add(raizArbol);
                
                //para cargar los imports
                raizArbol.ejecutar();
                  
                retorno = true;
            }

            return retorno;
        }


        public tablaSimbolos getTablaSimblos()
        {
            return tablaDeSimbolos;
        }
    }
}
