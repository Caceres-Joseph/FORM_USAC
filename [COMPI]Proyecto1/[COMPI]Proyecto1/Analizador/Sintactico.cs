using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using _COMPI_Proyecto1.AST;
using _COMPI_Proyecto1.Reporte;
using _COMPI_Proyecto1.Diagrama;
//hola
namespace _COMPI_Proyecto1.Analizador
{
    class Sintactico
    {
        static Semantico seman = new Semantico();
        public static Gramatica gramatica = new Gramatica();
        public static bool analizar(String cadena)
        {
            Boolean retorno = true;
            gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            if (raiz == null)
            {
                retorno= false;

            }
            else
            {
                seman.S4(raiz);
               
               // generarImagen(raiz);//aquí se genera el AST
                retorno= true;
            }

           
            //errores semanticos
            foreach (ErrorEjecucion item in seman.erroresSemanticos())
            {
                gramatica.lista.Add(item);//aquí agrego los errores semanticos
            }

            

            //Para elaborar el HTML del reporte
            ErrorEjecucion errores = new ErrorEjecucion();
            errores.GraficarTabla(gramatica.lista);
            return retorno;

        }
        public static void graficarAST(String cadena)
        {
            Boolean retorno = true;
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            if (raiz == null)
            {
                retorno = false;

            }
            else
            {                
                generarImagen(raiz);//aquí se genera el AST
                retorno = true;
            }
            

        }
        public static string sl = Convert.ToChar(92).ToString()+"n";
        public static void generarUML()
        {
            string cadena = "digraph hierarchy { \n node[shape = record, style = filled, fillcolor = ivory]\n  edge[dir = back, arrowtail = empty]\n";
            //seman.listaDeClases
            int contador = 0;

            //cadena = cadena + "2[label = \"{ AbstractSuffixTree | +text"+sl+"+root|.....}\"]";
            //cadena = cadena + "3[label = \"{ AbstractSuffixTree | +text" + sl + "+root|.....}\"]";

            foreach (Clase clase in seman.listaDeClases)
            {
                //cadena = cadena + contador.ToString()+ "[label=\"{";
                cadena = cadena + clase.nombre + "[label=\"{";
                cadena = cadena + clase.nombre+"|";


                //agregando atributos

                foreach (atributo atrib in clase.listaDeAtributos)
                {
                    string simbolo = "";
                    if (atrib.acceso == "public")
                    {
                        simbolo = "+";
                    }else if(atrib.acceso == "private")
                    {
                        simbolo = "-";
                    }else if(atrib.acceso== "protected")
                    {
                        simbolo = "#";
                    }
                    else
                    {
                        simbolo = "-";
                    }

                    cadena = cadena + simbolo + " " + atrib.tipo + " " + atrib.nombre + sl;
                }

                //metodos
                cadena = cadena + "|";
                foreach (metodo atrib in clase.listaDeMetodos)
                {
                    string simbolo = "";
                    if (atrib.acceso == "public")
                    {
                        simbolo = "+";
                    }
                    else if (atrib.acceso == "private")
                    {
                        simbolo = "-";
                    }
                    else if (atrib.acceso == "protected")
                    {
                        simbolo = "#";
                    }
                    else
                    {
                        simbolo = "-";
                    }

                    cadena = cadena + simbolo + " " + atrib.tipo + " " + atrib.nombre +"("+atrib.parametros+")"+ sl;
                }

                //Heredados
                foreach (metodo atrib in clase.listaDeHeredados)
                {
                    string simbolo = "";
                    if (atrib.acceso == "public")
                    {
                        simbolo = "+";
                    }
                    else if (atrib.acceso == "private")
                    {
                        simbolo = "-";
                    }
                    else if (atrib.acceso == "protected")
                    {
                        simbolo = "#";
                    }
                    else
                    {
                        simbolo = "-";
                    }

                    cadena = cadena + simbolo + " " + atrib.tipo + " " + atrib.nombre + "(" + atrib.parametros + ")" + sl;
                }
                cadena = cadena + "}\"]\n";
                //2[label = "{AbstractSuffixTree|+ text\n+ root|...}"]
                if (clase.padre!="")
                {
                    cadena = cadena + clase.padre + "->"+ clase.nombre + "[label= \"is\"]" + "\n";

                }

                //EL otro simbolo
                foreach (atributo atri in clase.listaDeAtributos)
                {

                    if (atri.tipo=="int")
                    {

                    }else if (atri.tipo == "String")
                    {

                    }else if (atri.tipo == "boolean")
                    {

                    }else if (atri.tipo == "double")
                    {

                    }else if (atri.tipo == "char")
                    {

                    }
                    else
                    {
                        cadena = cadena +clase.nombre +"->"+atri.tipo+"[constraint=false, arrowtail=odiamond, label = \""+atri.nombre+"\"]\n";
                    }

                }

                contador++;
            }
            // seman.validacionSemantica();

            //cadena = cadena +"Estudiante->Persona";
            cadena = cadena + "\n}";
            imagen grafico = new imagen();
            grafico.escribirDot(cadena, "UML");
        }
        public static void generarImagen(ParseTreeNode raiz)
        {
            imagen grafico = new imagen();

            String grafoDot = ControlDot.getDot(raiz);
            grafico.escribirDot(grafoDot, "arbolAST");


        }
    }
}
