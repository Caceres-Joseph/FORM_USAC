using _COMPI_Proyecto1.Analizador.Arbol;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _COMPI_Proyecto1.GUI
{
    class proyecto
    {
       public  List<FastColoredTextBox> ListaEntradas = new List<FastColoredTextBox>();//Lista de errores
        public List<tab> lstTabs = new List<tab>();

       public  MetroFramework.Controls.MetroTabPage page = new MetroFramework.Controls.MetroTabPage();
        //MetroFramework.Controls.MetroTabPage page2 = new MetroFramework.Controls.MetroTabPage();

        public MetroFramework.Controls.MetroTabControl tab = new MetroFramework.Controls.MetroTabControl();
        public string texto = "";
        public arbol arbol = new arbol();

        public proyecto()
        {
            tab.Style = MetroFramework.MetroColorStyle.Orange;
            tab.SetBounds(5, 5, 900, 500);
            tab.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            page.Controls.Add(tab);


            texto = Microsoft.VisualBasic.Interaction.InputBox(
                "Nombre del proyecto",
                "Nombre del proyecto",
                "Proyecto");

            seleccionarRutaProyecto();

            page.Text = texto; 

        }

        public void ejecutarTab()
        {
            //Console.WriteLine("ejectuando el proyecto_>" + page.Text);
            //Console.WriteLine(tab.SelectedIndex);
            arbol = new arbol();
            String contenido= lstTabs[tab.SelectedIndex].cuadro.Text;
            arbol.iniciarAnalisis(contenido);


        }
        public void insertarTab(tab tabInsertar)
        {
            tab.Controls.Add(tabInsertar.page);
            lstTabs.Add(tabInsertar);
        }
        public MetroFramework.Controls.MetroTabPage getTab()
        {
            return page;

        }

        public void seleccionarRutaProyecto()
        { 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string ruta = fbd.SelectedPath;
                arbol.tablaDeSimbolos.rutaProyecto = ruta;
                Console.WriteLine(ruta);

                
            }
            

        }
    }
}
