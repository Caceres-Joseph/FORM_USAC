using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas
{
    class tablaErrores
    {
        private List<elementoError> listaErrores = new List<elementoError>();//Lista de errores


        public void insertar(elementoError nodo)
        {
            listaErrores.Add(nodo);
        }


        public void println(Object str)
        {
            String mensaje = str.ToString();
            Console.WriteLine(mensaje);
            Console.WriteLine("\n>");
        }


        public void print(Object str)
        {
            String mensaje = str.ToString();
            Console.Write(mensaje);
        }
        
        public void insertErrorSyntax(String ambito, int linea, int columna, String mensaje)
        {
            elementoError elem = new elementoError();
            elem.ambito = ambito;
            elem.tipo = "Sintactico";
            elem.linea = (linea + 1).ToString();
            elem.columna = (columna + 1).ToString();
            elem.descripcion = mensaje;

            this.listaErrores.Add(elem);
            println("[Error]Sintactico-> " + mensaje);
        }

        public void insertErrorLexical(String ambito, int linea, int columna, String mensaje)
        {
            elementoError elem = new elementoError();
            elem.ambito = ambito;
            elem.tipo = "Lexico";
            elem.linea =(linea + 1).ToString();
            elem.columna = (columna + 1).ToString();
            elem.descripcion = mensaje;
            this.listaErrores.Add(elem);
            println("[Error]Lexico-> " + mensaje);
        }

        public void insertErrorSemantic(String ambito, int linea, int columna, String mensaje)
        {

            elementoError elem = new elementoError();
            elem.ambito = ambito;
            elem.tipo = "Semantico";
            elem.linea = (linea + 1).ToString();
            elem.columna = (columna + 1).ToString();
            elem.descripcion = mensaje;
            this.listaErrores.Add(elem);
            println("[Error]Semantico-> " + mensaje);
        }


        public void concat(tablaErrores tab)
        {
            this.listaErrores = listaErrores.Concat(tab.listaErrores).ToList();
        }



        public void imprimir()
        {
            println("-----cError--------");



            foreach (elementoError lstErrore in listaErrores)
            {
                print("Ambito{");
                print(lstErrore.ambito);
                println("}");
                print("Linea{");
                print(lstErrore.linea);
                println("}");
                print("Columna{");
                print(lstErrore.columna);
                println("}");
                print("Tipo{");
                print(lstErrore.tipo);
                println("}");
                print("Descripcion{");
                print(lstErrore.descripcion);
                println("}");
            }
        }

        public void mostrarHTLM()
        {
            escribirTabla();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TablaErrores.html";
            proc.Start();
        }

        public void escribirTabla()
        {
            GraficarHtml(listaErrores);
        }

        public void GraficarHtml(List<elementoError> listaErrores)
        {
            String tablasimboloshtml = "";

            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundo = DateTime.Now.Second;

            tablasimboloshtml += "<html>\n\t<head>\n\t\t<title>Reporte de Errores</title>" + "<meta charset=" + "\"" + "utf-8" + "\"" + ">"
                    + "\n\t\t<link rel=" + "\"" + "stylesheet" + "\"" + " href=" + "\"" + "css/normal.css"
                    + "\"" + ">\n"
                    + "\n\t\t<link rel=" + "\"" + "stylesheet" + "\"" + " href=" + "\"" + "css/style.css\">\n" +
                    "\t</head>\n\t<body>"
                    + "\n\t\t<div style=" + "\"" + "text-align:left;" + "\"" + ">"
                    + "\n\t\t\t<h1>REPORTE DE ERRORES</h1>"
                    + "\n\t\t\t<h2>Dia de ejecución:" + dia + " de " + getMes(mes) + " de " + año + "</h2>"
                    + "\n\t\t\t<h2>Hora de ejecución:" + hora + ":" + minuto + ":" + segundo + " " + hora + "</h2>"
                    + "\n\t\t\t<table class = \"responstable\">\n";
            tablasimboloshtml += "\t\t\t\t<TR>\n\t\t\t\t\t<TH>Ambito</TH> <TH>Tipo</TH> <TH>Linea</TH> <TH>Columna</TH><TH>Descripcion</TH>\n\t\t\t\t</TR>";

            foreach (elementoError nodo in listaErrores)
            {
                tablasimboloshtml += "\n\t\t\t\t<TR>";
                tablasimboloshtml += "\n\t\t\t\t\t<TD>" + nodo.ambito + "</TD>" + "<TD>" + nodo.tipo + "</TD>" + "<TD>" + nodo.linea + "</TD>" + "<TD>" + nodo.columna + "</TD>" + "<TD>" + nodo.descripcion + "</TD>" ;
                tablasimboloshtml += "\n\t\t\t\t</TR>";



            }

            tablasimboloshtml += "\n\t\t\t</table>\n\t\t</div>\n\t" +
              " <script src='css/respond.js'></script>\n" + "</body>\n</html>";


            System.IO.StreamWriter w = new System.IO.StreamWriter("TablaErrores.html");
            w.WriteLine(tablasimboloshtml);
            w.Close();
        }



        public String getMes(int mes)
        {
            String m = "";
            switch (mes)
            {
                case 1:
                    m = "Enero";
                    break;
                case 2:
                    m = "Febrero";
                    break;
                case 3:
                    m = "Marzo";
                    break;
                case 4:
                    m = "Abril";
                    break;
                case 5:
                    m = "Mayo";
                    break;
                case 6:
                    m = "Junio";
                    break;
                case 7:
                    m = "Julio";
                    break;
                case 8:
                    m = "Agosto";
                    break;
                case 9:
                    m = "Septiembre";
                    break;
                case 10:
                    m = "Octubre";
                    break;
                case 11:
                    m = "Noviembre";
                    break;
                default:
                    m = "Diciembre";
                    break;
            }
            return m;

        }


    }
}
