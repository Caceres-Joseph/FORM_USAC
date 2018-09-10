using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.GeneradorAst
{
    class generarRecorrido
    {
        String grafo = "";



        private  void concatenar(ParseTreeNode nodoIrony)
        {
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {
                    //no terminal sin hijos
                    Console.WriteLine("NoTerminal->" + nodoIrony.ToString());
                   // grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony.ToString() + "\"];\n";
                }
                else
                {
                    String terminal = escapar(nodoIrony.Token.Value.ToString());
                    Console.WriteLine("terminal->" + terminal);
                    grafo += nodoIrony.GetHashCode() + "[label=\"" + terminal + "\"];\n";
                }
            }
            else
            {
                Console.WriteLine("NoTerminal2->" + nodoIrony.ToString());
                grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony + "\"];\n";
            }
            foreach (ParseTreeNode hijo in nodoIrony.ChildNodes)
            {
                grafo += nodoIrony.GetHashCode() + "->" + hijo.GetHashCode() + ";\n";
                concatenar(hijo);
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
