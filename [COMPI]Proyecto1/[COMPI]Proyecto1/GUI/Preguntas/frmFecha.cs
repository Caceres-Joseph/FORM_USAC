using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _COMPI_Proyecto1.GUI.Preguntas
{
    partial class frmFecha : Form
    {

        itemValorPregunta valor;

        public frmFecha(itemValorPregunta valor, elementoEntorno parametros)
        {


            InitializeComponent();


            this.valor = valor;
            elementoEntorno carg = parametros.getGlobal();

            if (carg != null)
            {
                SetValores(carg.getEtiqueta(), carg.getSugerir(), carg.getRequerido());
            }
            else
            {
                println("no se encontro el global");
                SetValores("", "", "");
            }

            //solo tengo que traer los que estan globales, jejejejejejeje

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            siguiente();
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Metodos
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void siguiente()
        {

            string theDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");

            if (theDate == "")
                theDate = "10/10/2010";


            println("Fecha seleccionada:" + theDate);
            this.valor.getRespuesta().convertirCadena(theDate);
            this.Close();
        }



        public void println(String mensaje)
        {
            Console.WriteLine("[frmFecha]" + mensaje);
        }

        public void SetValores(String txtEtiqueta, String txtSugerir, String txtRequerido)
        {
            lblEtiqueta.Text = txtEtiqueta;
            lblSugerir.Text = txtSugerir;
            lblRequerido.Text = txtRequerido;
        }

        private void frmFecha_Load(object sender, EventArgs e)
        {

        }
    }
}
