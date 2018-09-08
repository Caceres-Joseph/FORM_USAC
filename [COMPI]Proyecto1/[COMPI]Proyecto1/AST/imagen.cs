using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.AST
{
    class imagen
    {
        public void generarImagen(string archivodot, string img)
        {
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\"";
            a.StartInfo.Arguments = "-Tjpg " + archivodot + " -o" + img;
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }


        public void escribirDot(String cadena, string nombre)
        {
            string cad = cadena;
            StreamWriter w = new StreamWriter(nombre + ".dot");
            w.WriteLine(cad);
            w.Close();
            generarImagen(nombre + ".dot", nombre + ".png");
        }
    }
}
