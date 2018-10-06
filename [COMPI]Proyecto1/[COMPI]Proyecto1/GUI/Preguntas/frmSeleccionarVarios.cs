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
    partial class frmSeleccionarVarios : Form
    {

        itemValorPregunta valor;
        List<CheckBox> lstButons = new List<CheckBox>();


        public frmSeleccionarVarios(itemValorPregunta valor, elementoEntorno parametros, List<String> lstString)
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
            foreach (String strTemp in lstString)
            {
                println(strTemp);

                CheckBox rad = new CheckBox();
                rad.Text = strTemp;
                rad.Location = new Point(10, i * 20);
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

            int i = 0;
            foreach (CheckBox rbTemp in lstButons)
            {
                if (rbTemp.Checked)
                {
                    if (i == 0)
                    {
                        seleccionado = rbTemp.Text;
                    }
                    else
                    {
                        seleccionado = seleccionado +", "+ rbTemp.Text;
                    }
                     
                    i++;
                     
                }
            }

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
