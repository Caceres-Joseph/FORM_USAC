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
      partial class frmEntero : Form
    {
        itemValorPregunta valor;
        int limiteInferior = -1;
        int limiteSuperior = -1;

        public frmEntero(itemValorPregunta valor, elementoEntorno parametros, int limiteInferior, int limiteSuperior)
        {


            InitializeComponent();
            this.limiteInferior = limiteInferior;
            this.limiteSuperior = limiteSuperior;

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
            if (numericUpDown1.Text == null)
                numericUpDown1.Text = "";

            int numero=0;
            try
            {
                numero = int.Parse(numericUpDown1.Text);
            }
            catch(Exception e)
            {

            }

            println(numero.ToString());
            this.valor.respuesta.setValue(numero);
            this.Close();
        }
         

        public void println(String mensaje)
        {
            Console.WriteLine("[frmEntero]" + mensaje);
        }

        public void SetValores(String txtEtiqueta, String txtSugerir, String txtRequerido)
        {
            lblEtiqueta.Text = txtEtiqueta;
            lblSugerir.Text = txtSugerir;
            lblRequerido.Text = txtRequerido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void lblRequerido_Click(object sender, EventArgs e)
        {

        }

        private void lblSugerir_Click(object sender, EventArgs e)
        {

        }

        private void lblEtiqueta_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (limiteInferior > 0 && limiteSuperior >= limiteInferior)
            {
                int numero = 0;
                try
                {
                    numero = int.Parse(numericUpDown1.Text);
                }
                catch (Exception)
                {

                }

                if (numero < limiteSuperior && numero > limiteInferior)
                {

                }
                else
                {
                    MessageBox.Show("El numero no esta entre " + limiteInferior.ToString() + " y " + limiteSuperior.ToString());
                }

            }
        }
    }
}
