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
    partial class frmSeleccionarUno : Form
    {

        itemValorPregunta valor;
        List<RadioButton> lstButons=new List<RadioButton>();

            
        public frmSeleccionarUno(itemValorPregunta valor, elementoEntorno parametros, List<String> lstString )
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



            int i = 0;
            foreach(String strTemp in lstString)
            {
                println(strTemp);

                RadioButton rad = new RadioButton();
                rad.Text = strTemp;
                rad.Location = new Point(10 , i * 20);
                lstButons.Add(rad);
                i++;
                grupoBox.Controls.Add(rad);
            }


            //cargando los elementos al panel
           


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

            String seleccionado = "nada";
            foreach(RadioButton rbTemp in lstButons)
            {
                if (rbTemp.Checked)
                {
                    seleccionado = rbTemp.Text;
                    break;
                }
            }
            /*if (txtRespuesta.Text == null)
                txtRespuesta.Text = "";
                */
            this.valor.getRespuesta().setValue(seleccionado);
            this.Close();
        }



        public void println(String mensaje)
        {
            Console.WriteLine("[frmSeleccionarUno]" + mensaje);
        }

        public void SetValores(String txtEtiqueta, String txtSugerir, String txtRequerido)
        {
            lblEtiqueta.Text = txtEtiqueta;
            lblSugerir.Text = txtSugerir;
            lblRequerido.Text = txtRequerido;
        }
    }
}
