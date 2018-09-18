using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Elementos
{
    class elementoConsola
    {

        public List<String> listaConsola;

        public FastColoredTextBoxNS.FastColoredTextBox consola;
        public elementoConsola(FastColoredTextBoxNS.FastColoredTextBox cuadro)
        {
            listaConsola = new List<string>();
            this.consola = cuadro;
        }


        public void insertar(String elemento)
        { 
            listaConsola.Add(elemento);
            this.consola.Text +=  elemento+ "\n";
        }

    }
}
