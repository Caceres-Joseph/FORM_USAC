using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Gramatica;
using _COMPI_Proyecto1.AST;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;
using _COMPI_Proyecto1.Analizador.Tablas.Elementos;
using FastColoredTextBoxNS;

namespace _COMPI_Proyecto1.Analizador.Tablas
{
    class tablaSimbolos
    {

        public tablaErrores tablaErrores = new tablaErrores();
        public String rutaProyect = "";

        public List<elementoClase> lstClases;
        public List<elementoClase> lstPreguntas;

        public elementoConsola consola; 
        



        public void setConsola(FastColoredTextBox cuadro)
        {
          //  println("tablaSImbo_setConsola");
              
        }


        //public List<nodoModelo> lstAst;


        public tablaSimbolos(FastColoredTextBox cuadro)
        {
            this.consola = new elementoConsola(cuadro);
            //lstAst = new List<nodoModelo>();
            lstClases = new List<elementoClase>();
            lstPreguntas = new List<elementoClase>();


        }

        public Boolean esPregunta(String idVal)
        {
            Boolean retorno = false;

            foreach(elementoClase el in lstPreguntas)
            {
                if (el.nombreClase.valLower.Equals(idVal))
                {
                    return true;
                }
            }

            return retorno;
        }

        public void setRutaProyecto(String ruta)
        {

            this.rutaProyect = ruta;
        }

        public String getRutaProyecto()
        {
            return rutaProyect;
        }

        public void inicializarTablas(String ruta)
        {
            Console.WriteLine("[tablaSImbolos]inicializando tabla");
            tablaErrores = new tablaErrores();
            rutaProyect = ruta;

        }

        public Boolean iniciarAnalisis(String cadena, String nombreArchivo)
        {

            //Console.WriteLine("[arbol]rutaProyecto->" + tablaDeSimbolos.getRutaProyecto());
            Boolean retorno = false;

            //GENERANDO EL AST DE IRONY

            gramatica gramatica = new gramatica(tablaErrores, nombreArchivo);

            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;


            //GENERANDO EL ARBOL

            generarArbol generar = new generarArbol(gramatica.nombreArchivo);


            if (raiz == null)
            {
                Console.WriteLine("Arbol Vacio");
                retorno = false;

            }
            else
            {

                // seman.S(raiz);
                // grafo.generarImagen(raiz);
                nodoModelo raizArbol = new nodoModelo("raiz", this);
                raizArbol = generar.generar(raizArbol, raiz, this);


                //lstAst.Add(raizArbol); //lo guardo en la lista de ast prro

                //para cargar los imports
                raizArbol.ejecutar();

                //generarImagen(raiz);//aquí se genera el AST
                retorno = true;
            }

            return retorno;
        }


        public void imprimirClases()
        {

            foreach (elementoClase temp in lstClases)
            {
                temp.imprimir();
            }

            Console.WriteLine("------------- Preguntas ----------------------");
            foreach (elementoClase temp in lstPreguntas)
            {
                temp.imprimir();
            }
        }

        public void iniciarEjecucion()
        {
            //antes carglo los extends


            


            foreach (elementoClase temp in lstClases)
            {
                if (temp.lstPrincipal.getCount() > 0)
                {
                    ejecutandoClase(temp);

                    return;
                }
            }
            tablaErrores.println("[tablaSimbolos]No hay principal para ejecutar ");
        }



        public void cargarExtends()
        {
            foreach (elementoClase clase in lstClases)
            {
                if (!clase.extender.valLower.Equals(""))
                {
                    //hay que buscar la clase y cargar los metodos

                    elementoClase tempClase = getClase(clase.extender);
                    if (tempClase == null)
                    {
                        tablaErrores.insertErrorSemantic("No se encuentra la clase: "+clase.extender.val+" de la que se quiere heredar",clase.extender);
                        return;
                    }


                    //heredando metodos, funciones, y constructores
                    clase.lstVariablesGlobales.heredar(tempClase.lstVariablesGlobales.listaPolimorfa); 


                    clase.lstMetodo_funcion.heredar(tempClase.lstMetodo_funcion.listaPolimorfa);
                    clase.lstConstructoresHeredados.heredar(tempClase.lstConstructores.listaPolimorfa);
                    //clase.lstVariablesGlobales.heredar(tempClase.lstVariablesGlobales.listaPolimorfa);

                    //cargando 

                }
            }

            cargarExtendsPreguntas();
        }
        public void cargarExtendsPreguntas()
        {
            foreach (elementoClase clase in lstPreguntas)
            {
                if (!clase.extender.valLower.Equals(""))
                {
                    //hay que buscar la clase y cargar los metodos

                    elementoClase tempClase = getClase(clase.extender);
                    if (tempClase == null)
                    {
                        tablaErrores.insertErrorSemantic("No se encuentra la clase: " + clase.extender.val + " de la que se quiere heredar", clase.extender);
                        return;
                    }


                    //heredando metodos, funciones, y constructores
                    clase.lstVariablesGlobales.heredar(tempClase.lstVariablesGlobales.listaPolimorfa);


                    clase.lstMetodo_funcion.heredar(tempClase.lstMetodo_funcion.listaPolimorfa);
                    clase.lstConstructoresHeredados.heredar(tempClase.lstConstructores.listaPolimorfa);
                    //clase.lstVariablesGlobales.heredar(tempClase.lstVariablesGlobales.listaPolimorfa);

                    //cargando 

                }
            }
        }
         
        public void ejecutandoClase(elementoClase clase)
        {
            ///hay que crear una instancia al objeto
            println("Ejecutando el main de " + clase.nombreClase.valLower);
            objetoClase ObjClase = new objetoClase(clase, this);
            ObjClase.ejecutarGlobales();
            ObjClase.ejecutarPrincipal();
            //ObjClase.imprimirTablaEntornos();
        }

        public void println(String mensaje)
        {
            tablaErrores.println("[tablaSimbolos]" + mensaje);
        }

        public elementoClase getClase(token nombre)
        {

            foreach (elementoClase temp in lstClases)
            {
                if (temp.nombreClase.valLower.Equals(nombre.valLower))
                {
                    return temp;

                }
            }

            //no encontro la clase 
            tablaErrores.insertErrorSemantic("No se puede crear una instancia al objeto: " + nombre.val + " debido a que no existe esa clase en este ambito", nombre);
            return null;

        }




        public elementoClase getPregunta(token nombre)
        {

            foreach (elementoClase temp in lstPreguntas)
            {
                if (temp.nombreClase.valLower.Equals(nombre.valLower))
                {
                    return temp;

                }
            }

            //no encontro la clase 
            //tablaErrores.insertErrorSemantic("No se puede crear una instancia al objeto: " + nombre.val + " debido a que no existe esa clase en este ambito", nombre);
            return null;

        }



        public Boolean hayErrores(String ambito)
        {


            Boolean retorno = true;

            if (tablaErrores.listaErrores.Count == 0)
            {
                retorno = false;

            }
            else
            {
                tablaErrores.println("No se puede ejecutar [" + ambito + "] porque hay errores en la tabla");
            }


            return retorno;


        }

    }
}
