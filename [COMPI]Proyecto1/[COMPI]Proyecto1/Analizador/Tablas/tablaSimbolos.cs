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
using _COMPI_Proyecto1.Analizador.Clase.Item;

namespace _COMPI_Proyecto1.Analizador.Tablas
{
      class tablaSimbolos
    {

        public tablaErrores tablaErrores = new tablaErrores();
        public String rutaProyect = "";
        public List<elementoClase> lstClases;

        //public List<nodoModelo> lstAst;


        public tablaSimbolos()
        {
            //lstAst = new List<nodoModelo>();
            lstClases = new List<elementoClase>();

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
                nodoModelo  raizArbol = new nodoModelo("raiz", this);
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

            foreach(elementoClase temp in lstClases)
            {
               temp.imprimir();
            }
        }

        public void iniciarEjecucion()
        {

            foreach (elementoClase temp in lstClases)
            {
                if (temp.lstPrincipal.getCount()>0)
                {
                    ejecutandoClase(temp);
                   
                    return;
                }
            }
            tablaErrores.println("[tablaSimbolos]No hay principal para ejecutar ");
        }

        public void ejecutandoClase(elementoClase clase)
        {
            ///hay que crear una instancia al objeto
            println("Ejecutando el main de " + clase.nombreClase.valLower);
            objetoClase objectoClase = new objetoClase();



        }
        
        public void println(String mensaje)
        {
            tablaErrores.println("[tablaSimbolos]"+mensaje);
        }
    }
}
