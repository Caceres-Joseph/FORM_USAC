using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace _COMPI_Proyecto1.GUI.Preguntas
{
    partial class frmAudio : Form
    {
        String ruta = "";
        Boolean boolReproducir = false;
       // SoundPlayer simpleSound;
       // WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public frmAudio(elementoEntorno parametros, String ruta, Boolean boolReproducir)
        {
            this.ruta = ruta;
            this.boolReproducir = boolReproducir;


            InitializeComponent();


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



            lblRuta.Text = ruta;

            crearAudio();
            stop();

            if (boolReproducir)
            {
                play();
            }

        }




        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void crearAudio()
        {
            try
            {
                axWindowsMediaPlayer1.URL = ruta;

                //simpleSound = new SoundPlayer(@ruta);
            }
            catch (Exception)
            {

            }

        }
        public void play()
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (Exception)
            {

            }
        }

        public void stop()
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                //simpleSound.Stop();
            }
            catch (Exception)
            {

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop();
        }




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Metodos
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
         

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
