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
      partial class frmBooleano : Form
    {

        itemValorPregunta valor;

        public frmBooleano(itemValorPregunta valor, elementoEntorno parametros, String valVerdadero, String valFalso)
        {


            InitializeComponent();

            rbVerdadero.Text = valVerdadero;
            rbFalso.Text = valFalso;

            this.valor = valor;
            elementoEntorno carg = parametros.getGlobal();

            if (carg != null)
            {
                SetValores(carg.getEtiqueta(), carg.getSugerir(), carg.getRequerido());
            }
            else
            {

                SetValores("", "", "");
            }

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

            Boolean respuesta = false;
            if (rbVerdadero.Checked)
            {
                respuesta = true;
            }
             
            this.valor.respuesta.setValue(respuesta);
            this.Close();
        }


        public void println(String mensaje)
        {
            Console.WriteLine("[frmBooleano]" + mensaje);
        }

        public void SetValores(String txtEtiqueta, String txtSugerir, String txtRequerido)
        {
            lblEtiqueta.Text = txtEtiqueta;
            lblSugerir.Text = txtSugerir;
            lblRequerido.Text = txtRequerido;
        }

    }
}
