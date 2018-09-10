using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Gramatica;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Arbol
{
   public  class arbol
    {

        //aqui tengo que definir la tabla de simbolos, 
        //tener una tabla de errores 

        //y la raíz


        tablaSimbolos tablaDeSimbolos = new tablaSimbolos();
        nodoModelo raizArbol;

        public arbol()
        {
            raizArbol = new nodoModelo("raiz", tablaDeSimbolos);
        }

        public Boolean iniciarAnalisis(String cadena)
        {

            //GENERANDO EL AST DE IRONY

            gramatica gramatica = new gramatica();
            Boolean retorno = false;
            gramatica = new gramatica();
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
                Sintactico.generarImagen(raiz);
                raizArbol = generar.generar(raizArbol, raiz, tablaDeSimbolos);
                raizArbol.ejecutar();
                //generarImagen(raiz);//aquí se genera el AST
                retorno = true;
            }

            return retorno;
        }
    }
}
