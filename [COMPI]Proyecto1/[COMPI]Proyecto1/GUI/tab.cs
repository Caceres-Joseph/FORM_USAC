﻿using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.GUI
{
    class tab
    {
       public  FastColoredTextBox cuadro = new FastColoredTextBox();
       public MetroFramework.Controls.MetroTabPage page = new MetroFramework.Controls.MetroTabPage();
       public String texto = "";


        public  tab()
        {

            cuadro.TextChanged += textChangedEventHandler;
            page.Controls.Add(cuadro);

            cuadro.SetBounds(10, 10, 800, 400);
            cuadro.BackColor = SystemColors.Menu;
            cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;

            texto = Microsoft.VisualBasic.Interaction.InputBox(
               "Nombre de la clase",
               "Nombre de la clase",
               "class.xform");

            page.Text = texto;

        }

        public tab(String nombre, String contenido)
        {
            cuadro.TextChanged += textChangedEventHandler;
            page.Controls.Add(cuadro);

            cuadro.SetBounds(10, 10, 800, 400);
            cuadro.BackColor = SystemColors.Menu;
            cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            cuadro.Text = contenido;

            page.Text = nombre;
        }


        Style OrangeStyle = new TextStyle(Brushes.Orange, null, FontStyle.Bold);
        Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        Style GrayStyle = new TextStyle(Brushes.LightGray, null, FontStyle.Regular);

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {

            Regex r = new Regex(
                @"clase|importar|extender|padre|principal|sobrescribir|nuevo|nada|este"
                , RegexOptions.IgnoreCase
            );

            e.ChangedRange.SetStyle(BlueStyle, r);


            Regex r2 = new Regex(
               // "\"(\\w)*\""
               @"""""|''|"".*?[^\\]""|'.*?[^\\]'"
               , RegexOptions.IgnoreCase
            );

            e.ChangedRange.SetStyle(OrangeStyle, r2);


            Regex JScriptCommentRegex1 = new Regex(@"\$\#(.)*\#\$", RegexOptions.Multiline);
            Regex JScriptCommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            Regex JScriptCommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)",
                 RegexOptions.Singleline | RegexOptions.RightToLeft);


            e.ChangedRange.SetStyle(OrangeStyle, JScriptCommentRegex1);

            //e.ChangedRange.SetStyle(BlueStyle, @"clase");



        }

    }
}