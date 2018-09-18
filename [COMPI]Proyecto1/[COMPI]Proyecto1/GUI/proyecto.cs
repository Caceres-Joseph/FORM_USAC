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
        public arbol arbol ;
        FastColoredTextBox consola = new FastColoredTextBox();
        public proyecto(String texto)
        {
            arbol = new arbol(consola);
            tab.Style = MetroFramework.MetroColorStyle.Orange;
            tab.SetBounds(5, 5, 900, 495);
            tab.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            page.Controls.Add(tab);

            this.texto = texto;
          
            seleccionarRutaProyecto();

            page.Text = texto;

            crearConsola();
            


        }

        public void crearConsola()
        {
           
            arbol.tablaDeSimbolos.setConsola(consola);
            page.Controls.Add(consola);
            consola.SetBounds(0,500,950,100);
            consola.BackColor = Color.Black;
            consola.ForeColor = Color.White;
            consola.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        public void ejecutarTab()
        {

            Console.WriteLine("=========================================================================");
            //Console.WriteLine("ejectuando el proyecto_>" + page.Text);
            //Console.WriteLine(tab.SelectedIndex);
            //arbol = new arbol();
            // arbol.tablaDeSimbolos.inicializarTablas(arbol.tablaDeSimbolos.getRutaProyecto());


            String rutaProyecto = arbol.tablaDeSimbolos.getRutaProyecto();
            FastColoredTextBox temp = arbol.tablaDeSimbolos.consola.consola;
            temp.Text = "";


            arbol = new arbol(temp);
            arbol.tablaDeSimbolos.setRutaProyecto(rutaProyecto);

            String contenido= lstTabs[tab.SelectedIndex].cuadro.Text;
            arbol.iniciarAnalisis(contenido,lstTabs[tab.SelectedIndex].page.Text);
            arbol.tablaDeSimbolos.imprimirClases();
            arbol.tablaDeSimbolos.iniciarEjecucion();
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
                arbol.setRutaProyecto(ruta);
                //arbol.getTablaSimblos().setRutaProyecto (ruta);
                //Console.WriteLine("[proyecto]"+ruta);
                
            }

            return;
        }
    }
}
