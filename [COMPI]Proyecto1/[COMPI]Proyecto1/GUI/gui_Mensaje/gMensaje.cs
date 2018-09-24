using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _COMPI_Proyecto1.GUI.gui_Mensaje
{
    public partial class gMensaje : Form
    {
        public gMensaje()
        {
            InitializeComponent();
        }

        private void gMensaje_Load(object sender, EventArgs e)
        {

        }

        public void mensaje(String mensaje)
        {
            label1.Text = mensaje;
        }
    }
}
