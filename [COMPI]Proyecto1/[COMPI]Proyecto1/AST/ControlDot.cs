using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.AST
{
    class ControlDot
    {
        private static int contador;
        private static String grafo;

        public static String getDot(ParseTreeNode raiz)
        {
            grafo = "digraph G{";
            grafo += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";
            //  grafo += "nodo0[label=\"etiqueta\"];\n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            grafo += "}";
            return grafo;
        }
        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nombreHijo + "\n";
                contador++;
                recorrerAST(nombreHijo, hijo);


            }
        }
        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
