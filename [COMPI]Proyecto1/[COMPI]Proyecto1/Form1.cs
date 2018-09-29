using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using _COMPI_Proyecto1.Analizador;
using _COMPI_Proyecto1.AST;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using _COMPI_Proyecto1.GUI;
using _COMPI_Proyecto1.GUI.TIpos;

namespace _COMPI_Proyecto1
{
    public partial class Form1 : MetroForm
    {
         List<proyecto> ListaDeProyectos = new List<proyecto>();
        //public List<List<FastColoredTextBox>> ListaDeProyectos = new List<List<FastColoredTextBox>>();
        public  List<MetroFramework.Controls.MetroTabControl> listaDeTabs=new List<MetroFramework.Controls.MetroTabControl>();
     

        public Form1()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)



        {



            ListaDeProyectos[metroTabControl1.SelectedIndex].ejecutarTab();
            /*

            String cadena = "";

            foreach (FastColoredTextBox entrada in ListaDeProyectos[metroTabControl1.SelectedIndex])
            {

                cadena = cadena + "\n" + entrada.Text;
            }
            //Console.WriteLine(cadena);

           bool resultado = Sintactico.analizar(cadena);
             if (resultado)
             {
                if (Sintactico.gramatica.lista.Count!=0)
                {
                    txtConsola.Text = ">>Cadena correcta, el analizador se recupero de varios errores :/";
                }
                else
                {
                    txtConsola.Text = ">>Cadena correcta, se puede generar el diagrama de clases :)";
                }
               
                 
                 // Console.WriteLine("cadena correcta");
             }
             else
             {
                 txtConsola.Text = ">>Cadena incorrecta, no se pudo recuperar del error :(";
                 // Console.WriteLine("cadena incorrecta");
             }*/
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imagen im = new imagen();

            im.generarImagen("grafo.dot",  "grafo.png");
        }
        public void crearTab()
        {
            tab ta = new tab();

           // metroTabControl2.Controls.Add(page);
           // listaDeTabs[metroTabControl1.SelectedIndex].Controls.Add(ta.page);

            ListaDeProyectos[metroTabControl1.SelectedIndex].insertarTab(ta);
            //ListaEntradas.Add(cuadro);
            treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.Add(ta.texto);

        } 

        public void crearTab(String nombre, String contenido)
        {



            tab ta = new tab(nombre, contenido);

            //listaDeTabs[metroTabControl1.SelectedIndex].Controls.Add(ta.page);

            //ListaDeProyectos[metroTabControl1.SelectedIndex].Add(ta.cuadro);
            ListaDeProyectos[metroTabControl1.SelectedIndex].insertarTab(ta);
            treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.Add(nombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearTab();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // crearTab();
            nuevoProyecto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            String cadena = "";
            foreach (FastColoredTextBox entrada in ListaEntradas)
            {

                cadena = cadena +"\n"+ entrada.Text;
            }
            Console.WriteLine(cadena);
            */
            // Console.WriteLine(metroTabControl1.SelectedIndex);
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Parent");
            treeView1.Nodes[0].Nodes.Add("Child 1");
            treeView1.Nodes[0].Nodes.Add("Child 2");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            treeView1.EndUpdate();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {


            System.IO.Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = ListaDeProyectos[metroTabControl1.SelectedIndex].arbol.getTablaSimblos().getRutaProyecto();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            string ruta = openFileDialog1.FileName.ToString();



                            
                            // openFileDialog1.OpenFile.ToString();
                            string[] words = ruta.Split(Convert.ToChar(92));
                            string nombre = words[words.Length - 1];
                            string text = System.IO.File.ReadAllText(@ruta);
                            crearTab(nombre, text);
                           
                            /*
                            Console.WriteLine(words[words.Length - 1]);
                            foreach (string word in words)
                            {
                               // Console.WriteLine(word);
                            }
                            */




                            // Display the file contents to the console. Variable text is a string.
                            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crearTab();
        }

        private void diagramaDeClasesToolStripMenuItem_Click(object sender, EventArgs e)
        { 
        }

        private void aSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            String cadena = "";

            foreach (FastColoredTextBox entrada in ListaDeProyectos[metroTabControl1.SelectedIndex])
            {

                cadena = cadena + "\n" + entrada.Text;
            }
            Sintactico.graficarAST(cadena);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "arbolAST.png";
            proc.Start();
            */

        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoProyecto();
        }

        public void nuevoProyecto()
        {
            String texto = Microsoft.VisualBasic.Interaction.InputBox(
              "Nombre del proyecto",
              "Nombre del proyecto",
              "Proyecto");
            if (texto.Length>0)
            {
                proyecto proyect = new proyecto(texto);

                metroTabControl1.Controls.Add(proyect.page);

                listaDeTabs.Add(proyect.tab);

                ListaDeProyectos.Add(proyect);

                treeView1.BeginUpdate();
                treeView1.Nodes.Add(proyect.texto);
                treeView1.EndUpdate();
            }
        }



        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaDeProyectos[metroTabControl1.SelectedIndex].arbol.tablaDeSimbolos.tablaErrores.mostrarHTLM();
        }

        private void eliminarClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   metroTabControl1.
            //listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex
            // ListaDeProyectos[metroTabControl1.SelectedIndex].
            // ListaDeProyectos[metroTabControl1.SelectedIndex]
            //listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex;
            //listaDeTabs[metroTabControl1.SelectedIndex];
            //metroTabControl1.Controls.RemoveAt(listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex);


            int indice = listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex;
            treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes[indice].Remove();

            listaDeTabs[metroTabControl1.SelectedIndex].Controls.RemoveAt(indice);
           // ListaDeProyectos[metroTabControl1.SelectedIndex].RemoveAt(indice);


            //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveAt(listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex); //para elimiar la clase de la vista árbol
                                                                                                                                       //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveByKey(listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex.)
                                                                                                                                       //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveByKey("Fecha.java");
           // treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes[listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex].Remove();
          

        }

        private void txtConsola_TextChanged(object sender, EventArgs e)
        {

        }

        private void verFomularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Condicion con = new Condicion();
            con.Show();


            Entero ent = new Entero();
            ent.Show();

           Opcion opc = new Opcion();
            opc.Show();


            Form1 con2 = new Form1();
            con2.Show();


        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
