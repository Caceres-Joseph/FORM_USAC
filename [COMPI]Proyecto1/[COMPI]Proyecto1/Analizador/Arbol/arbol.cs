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

namespace _COMPI_Proyecto1.Analizador.Arbol
{
    class arbol
    {

        //aqui tengo que definir la tabla de simbolos, 
        //tener una tabla de errores 

        //y la raíz


        public tablaSimbolos tablaDeSimbolos = new tablaSimbolos();
        public nodoModelo raizArbol;
       // public String rutaDeLaCarpeta = "";


        public arbol()
        {
            raizArbol = new nodoModelo("raiz", tablaDeSimbolos);
        }

        public Boolean iniciarAnalisis(String cadena)
        {
            Boolean retorno = false;

            //GENERANDO EL AST DE IRONY

            gramatica gramatica = new gramatica(tablaDeSimbolos.tablaErrores);
            
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            //GENERANDO EL ARBOL

            generarArbol generar = new generarArbol();
            
            
            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                retorno = false;

            }
            else
            {
               
                // seman.S(raiz);
                grafo.generarImagen(raiz);
                Console.WriteLine("rutaProyecto->"+tablaDeSimbolos.rutaProyecto);
                raizArbol = generar.generar(raizArbol, raiz, tablaDeSimbolos);
                raizArbol.ejecutar();
                 
                //generarImagen(raiz);//aquí se genera el AST
                retorno = true;
            }

            return retorno;
        }
    }
}
