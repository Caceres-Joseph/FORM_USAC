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
    partial class frmHora : Form
    {
        itemValorPregunta valor;

        public frmHora(itemValorPregunta valor, elementoEntorno parametros)
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

            string theDate = dateTimePicker1.Value.ToString("HH:mm:ss");

            if (theDate == "")
                theDate = "00:00:00";


            println("Hora seleccionada:" + theDate);
            this.valor.getRespuesta().convertirCadena(theDate);
            this.Close();
        }



        public void println(String mensaje)
        {
            Console.WriteLine("[frHora]" + mensaje);
        }

        public void SetValores(String txtEtiqueta, String txtSugerir, String txtRequerido)
        {
            lblEtiqueta.Text = txtEtiqueta;
            lblSugerir.Text = txtSugerir;
            lblRequerido.Text = txtRequerido;
        }
    }
}
