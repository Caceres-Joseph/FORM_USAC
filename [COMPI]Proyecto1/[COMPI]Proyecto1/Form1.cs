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

namespace _COMPI_Proyecto1
{
    public partial class Form1 : MetroForm
    {
        public List<List<RichTextBox>> ListaDeProyectos = new List<List<RichTextBox>>();
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

            String cadena = "";

            foreach (RichTextBox entrada in ListaDeProyectos[metroTabControl1.SelectedIndex])
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
             }
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imagen im = new imagen();

            im.generarImagen("grafo.dot",  "grafo.png");
        }
        public void crearTab()
        {
            RichTextBox cuadro = new RichTextBox();
            
            MetroFramework.Controls.MetroTabPage page = new MetroFramework.Controls.MetroTabPage();
            //string entrada = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un Dato");
            page.Controls.Add(cuadro);

            cuadro.SetBounds(10, 10, 800, 400);
            cuadro.BackColor = SystemColors.Menu;
            cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;

           /* MetroFramework.Controls.MetroButton boton = new MetroFramework.Controls.MetroButton();
            boton.Text = "x";
            boton.SetBounds(0, 0, 20, 20);
            boton.Click += (sender, args) =>
            {

                //aquí va el codigo para eliminar 
            };
           
            page.Controls.Add(boton);
            */
            string texto = Microsoft.VisualBasic.Interaction.InputBox(
        "Nombre de la clase",
        "Nombre de la clase",
        "clase.java");

            page.Text = texto;

           // metroTabControl2.Controls.Add(page);
            listaDeTabs[metroTabControl1.SelectedIndex].Controls.Add(page);

            ListaDeProyectos[metroTabControl1.SelectedIndex].Add(cuadro);
            //ListaEntradas.Add(cuadro);
            treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.Add(texto);

        }
      

        public void crearTab(String nombre, String contenido)
        {
            RichTextBox cuadro = new RichTextBox();
            cuadro.Text = contenido;
            MetroFramework.Controls.MetroTabPage page = new MetroFramework.Controls.MetroTabPage();
            //string entrada = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un Dato");
            page.Controls.Add(cuadro);
            cuadro.SetBounds(10, 10, 800, 400);
            cuadro.BackColor = SystemColors.Menu;
            cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;
          

            page.Text = nombre;
           // metroTabControl2.Controls.Add(page);
            listaDeTabs[metroTabControl1.SelectedIndex].Controls.Add(page);

            //ListaEntradas.Add(cuadro);
            ListaDeProyectos[metroTabControl1.SelectedIndex].Add(cuadro);
            treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.Add(nombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crearTab();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // crearTab();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            String cadena = "";
            foreach (RichTextBox entrada in ListaEntradas)
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

            openFileDialog1.InitialDirectory = "c:\\";
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
            Sintactico.generarUML();

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "UML.png";
            proc.Start();
        }

        private void aSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String cadena = "";

            foreach (RichTextBox entrada in ListaDeProyectos[metroTabControl1.SelectedIndex])
            {

                cadena = cadena + "\n" + entrada.Text;
            }
            Sintactico.graficarAST(cadena);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "arbolAST.png";
            proc.Start();


        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RichTextBox> ListaEntradas = new List<RichTextBox>();//Lista de errores


            MetroFramework.Controls.MetroTabPage page = new MetroFramework.Controls.MetroTabPage();
            //MetroFramework.Controls.MetroTabPage page2 = new MetroFramework.Controls.MetroTabPage();

            MetroFramework.Controls.MetroTabControl tab = new MetroFramework.Controls.MetroTabControl();
            tab.Style = MetroFramework.MetroColorStyle.Orange;

            tab.SetBounds(5, 5, 900, 500);
            tab.Font= new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            //page2.Text = "hola";
           
            //tab.Controls.Add(page2);
            page.Controls.Add(tab);
            //RichTextBox cuadro = new RichTextBox();
           // cuadro.Font  = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            //string entrada = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un Dato");

            //cuadro.SetBounds(10, 10, 900, 400);
            //cuadro.BackColor = SystemColors.Menu;
            //cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //page2.Controls.Add(cuadro);
            string texto = Microsoft.VisualBasic.Interaction.InputBox(
        "Nombre del proyecto",
        "Nombre del proyecto",
        "Proyecto");

            page.Text = texto;
            metroTabControl1.Controls.Add(page);

            listaDeTabs.Add(tab);
            ListaDeProyectos.Add(ListaEntradas);


            //para la vista arbol


            treeView1.BeginUpdate();
            treeView1.Nodes.Add(texto);

            //treeView1.Nodes[0].Nodes.Add("Child 1");
            //treeView1.Nodes[0].Nodes.Add("Child 2");
            //treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            treeView1.EndUpdate();



            //  ListaEntradas.Add(cuadro);
        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TablaErrores.html";
            proc.Start();
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
            ListaDeProyectos[metroTabControl1.SelectedIndex].RemoveAt(indice);


            //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveAt(listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex); //para elimiar la clase de la vista árbol
                                                                                                                                       //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveByKey(listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex.)
                                                                                                                                       //treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes.RemoveByKey("Fecha.java");
           // treeView1.Nodes[metroTabControl1.SelectedIndex].Nodes[listaDeTabs[metroTabControl1.SelectedIndex].SelectedIndex].Remove();
          

        }
    }
}
