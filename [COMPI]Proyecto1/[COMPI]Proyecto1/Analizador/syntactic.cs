using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador
{
   public class syntactic
    {

        public  grammar gramatica = new grammar();
        public  bool analizar(String cadena)
        {
            Boolean retorno = false;
            gramatica = new grammar();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
             
            if (raiz == null)
            {
                retorno = false;

            }
            else
            {
                Console.WriteLine("Arbol no vacio");
                // seman.S(raiz);
                Sintactico.generarImagen(raiz);
                //generarImagen(raiz);//aquí se genera el AST
                retorno= true;
            }

            return retorno;
            
        }
    }
}
