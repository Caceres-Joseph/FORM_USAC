using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _ESCRIBIR_ARCHIVO : nodoModelo
    /*
     * tEscribirArchivo + sAbreParent + LST_VAL + sCierraParent + sPuntoComa;
    */
    {
        public static string nombreArchivo = "Respuestas/vacio.html";
        public static string contenido = "" +
                "\n<!DOCTYPE html>" +
                "\n<html >" +
                "\n<head>" +
                "\n  <meta charset=\"UTF - 8\"> " +
                "\n  <title>Respuestas</title> " +
                "\n  <link rel='stylesheet' href='../css/normal.css'>" +
                "\n  <link rel='stylesheet' href='../css/style.css'>" +
                "\n  <script src='../css/respond.js'></script>" +
                "\n</head>" +
                "\n<body>" +
                "\n  <h1>Respuestas</h1>" +
                "\n  <h2>Formulario:  <span> Edades </span></h2>" +
                "\n  <table class='responstable'>" +
                "\n  <tr>" +
                "\n     <th>Num </th>" +
                "\n     <th>Fecha/hora </th>" +
                "\n     <th>Pregunta</th>" +
                "\n	    <th>Respuesta</th>" +
                "\n  </tr>";

        public static int numPregunta = 0;


        public static void resetVariables()
        {
            contenido = "" +
                "\n<!DOCTYPE html>" +
                "\n<html >" +
                "\n<head>" +
                "\n  <meta charset=\"UTF - 8\"> " +
                "\n  <title>Respuestas</title> " +
                "\n  <link rel='stylesheet' href='../css/normal.css'>" +
                "\n  <link rel='stylesheet' href='../css/style.css'>" +
                "\n  <script src='../css/respond.js'></script>" +
                "\n</head>" +
                "\n<body>" +
                "\n  <h1>Respuestas</h1>" +
                "\n  <h2>Formulario:  <span> Edades </span></h2>" +
                "\n  <table class='responstable'>" +
                "\n  <tr>" +
                "\n     <th>Num </th>" +
                "\n     <th>Fecha/hora </th>" +
                "\n     <th>Pregunta</th>" +
                "\n	    <th>Respuesta</th>" +
                "\n  </tr>";

            nombreArchivo = "Respuestas/vacio.html";
            numPregunta = 0;
        }

        public static void resetVariables(String nombreArchivo2)
        {
            contenido = "" +
                "\n<!DOCTYPE html>" +
                "\n<html >" +
                "\n<head>" +
                "\n  <meta charset=\"UTF - 8\"> " +
                "\n  <title>Respuestas</title> " +
                "\n  <link rel='stylesheet' href='../css/normal.css'>" +
                "\n  <link rel='stylesheet' href='../css/style.css'>" +
                "\n  <script src='../css/respond.js'></script>" +
                "\n</head>" +
                "\n<body>" +
                "\n  <h1>Respuestas</h1>" +
                "\n  <h2>Formulario:  <span> " + nombreArchivo2 + " </span></h2>" +
                "\n  <table class='responstable'>" +
                "\n  <tr>" +
                "\n     <th>Num </th>" +
                "\n     <th>Fecha/hora </th>" +
                "\n     <th>Pregunta</th>" +
                "\n	    <th>Respuesta</th>" +
                "\n  </tr>"; 
            nombreArchivo = "Respuestas/" + nombreArchivo2 + ".html";
            numPregunta = 0;
        }



        public _ESCRIBIR_ARCHIVO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {

            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;

            _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
            lstValores listaValores = temp.getLstValores(tablaEntornos);


            if (listaValores.listaValores.Count == 2)

            /*
            |---------------------------- 
            |  NOMBRE, TEXTO
            */
            {

            }
            else if (listaValores.listaValores.Count == 1)

            /*
            |---------------------------- 
            |  TEXTO 
            */
            {
                itemValor limitInf = listaValores.listaValores[0];
                Object obj = limitInf.getValorParseado("cadena");

                if (obj != null)
                {


                    String contenido = (String)obj;
                    contenido = "\n < tr > " +
                                "\n     <td>" + numPregunta + "</td>" + contenido;
                    numPregunta++;
                    _ESCRIBIR_ARCHIVO.contenido = _ESCRIBIR_ARCHIVO.contenido + contenido;
                    escribirArchivo(_ESCRIBIR_ARCHIVO.contenido, _ESCRIBIR_ARCHIVO.nombreArchivo);
                    return retorno;
                }
            }

            return retorno;
        }

        public void escribirArchivo(String cadena, string nombre)
        {
            string cad = cadena;
            StreamWriter w = new StreamWriter(nombre);
            w.WriteLine(cad);
            w.Close();
        }
    }
}
