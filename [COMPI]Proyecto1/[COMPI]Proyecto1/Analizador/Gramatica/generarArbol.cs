using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Nodos.Asignar_Valor;
using _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas;
using _COMPI_Proyecto1.Analizador.Nodos.IdVar_func;
using _COMPI_Proyecto1.Analizador.Nodos.Llaves_Arreglos;
using _COMPI_Proyecto1.Analizador.Tablas;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Gramatica
{
    class generarArbol
    {
        public String nombreArchivo;
        public generarArbol(String archivo)
        {
            this.nombreArchivo = archivo;
        }
         
        public nodoModelo generar(nodoModelo raiz, ParseTreeNode AST, tablaSimbolos tabla)
        {
            crearArbol(raiz, AST, tabla);

            return raiz;
        }

        private void crearArbol(nodoModelo padre, ParseTreeNode nodoIrony, tablaSimbolos tabla)
        {
             
            nodoModelo hijoNodo=null;
            if (nodoIrony.ChildNodes.Count == 0)
            {
                if (nodoIrony.Token == null)
                {
                    //no terminal sin hijos
                    //Console.WriteLine("NoTerminal->" + nodoIrony.ToString());
                    // grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony.ToString() + "\"];\n";
                }
                else
                {
                    String terminal = escapar(nodoIrony.Token.Value.ToString());
                    String nombreTerminal = nodoIrony.Term.Name;
                    token tok = new token(terminal,nodoIrony.Token.Location.Line, nodoIrony.Token.Location.Column, nombreArchivo);

                    //Console.WriteLine("[generarArbol]crearArbol:"+nodoIrony.Term.ToString());
                    padre.lstAtributos.insertar(nombreTerminal,tok);

                    //Console.WriteLine("terminal->" + terminal);
                    //grafo += nodoIrony.GetHashCode() + "[label=\"" + terminal + "\"];\n";
                }
            }
            else
            { 
                hijoNodo = getNodo(nodoIrony.ToString(), tabla);
                //Console.WriteLine("insertando| " + padre.nombre + "->" + hijoNodo.nombre);
                padre.insertar(hijoNodo);
                //grafo += nodoIrony.GetHashCode() + "[label=\"" + nodoIrony + "\"];\n";
            }


            foreach (ParseTreeNode hijo in nodoIrony.ChildNodes)
            {
                  
                    crearArbol(hijoNodo, hijo, tabla);
 
                //grafo += nodoIrony.GetHashCode() + "->" + hijo.GetHashCode() + ";\n";
                
            }

            return;
        }
         

        public nodoModelo getNodo(String nombreNoTerminal, tablaSimbolos tabla)
        {
            nodoModelo retorno=null;

            switch (nombreNoTerminal)
            {
                case "S":
                    retorno = new _S(nombreNoTerminal, tabla);
                    
                    break;
                    
                case "LST_IMPORT":
                    retorno = new _LST_IMPORT(nombreNoTerminal, tabla);
                    
                    break;
                case "IMPORT":
                    retorno = new _IMPORT(nombreNoTerminal, tabla);

                    break;
                case "LST_CLASE":
                    retorno = new _LST_CLASE(nombreNoTerminal, tabla);

                    break;
                case "CLASE":
                    retorno = new _CLASE(nombreNoTerminal, tabla);

                    break;
                case "TIPO":
                    retorno = new _TIPO(nombreNoTerminal, tabla);

                    break;

                case "EXTENDER":
                    retorno = new _EXTENDER(nombreNoTerminal, tabla);

                    break;
                case "VISIBILIDAD":
                    retorno = new _VISIBILIDAD(nombreNoTerminal, tabla);

                    break;
                case "LST_PARAMETROS":
                    retorno = new _LST_PARAMETROS(nombreNoTerminal, tabla);

                    break;
                case "PARAMETRO":
                    retorno = new _PARAMETRO(nombreNoTerminal, tabla);

                    break;
                case "LST_VAL":
                    retorno = new _LST_VAL(nombreNoTerminal, tabla);

                    break;
                case "CP_CLASE":
                    retorno = new _CP_CLASE(nombreNoTerminal, tabla);

                    break;
                case "CUERPO_CLASE":
                    retorno = new _CUERPO_CLASE(nombreNoTerminal, tabla);

                    break;
                case "METODO":
                    retorno = new _METODO(nombreNoTerminal, tabla);

                    break;
                case "SOBRESCRITURA":
                    retorno = new _SOBRESCRITURA(nombreNoTerminal, tabla);

                    break;
                case "MAIN":
                    retorno = new _MAIN(nombreNoTerminal, tabla);

                    break;
                case "CONSTRUCTOR":
                    retorno = new _CONSTRUCTOR(nombreNoTerminal, tabla);

                    break;
                case "DECLARAR_VARIABLE_GLOBAL":
                    retorno = new _DECLARAR_VARIABLE_GLOBAL(nombreNoTerminal, tabla);

                    break;
                case "DECLARAR_VARIABLE_SINVISIBI":
                    retorno = new _DECLARAR_VARIABLE_SINVISIBI(nombreNoTerminal, tabla);

                    break; 

                case "VAL":
                    retorno = new _VAL(nombreNoTerminal, tabla);

                    break;
                case "LST_LLAVES_VAL":
                    retorno = new _LST_LLAVES_VAL(nombreNoTerminal, tabla);

                    break;
                case "LLAVES_VAL_P":
                    retorno = new _LLAVES_VAL_P(nombreNoTerminal, tabla);

                    break;
                case "VAR_ARREGLO":
                    retorno = new _VAR_ARREGLO(nombreNoTerminal, tabla);

                    break;
                case "LST_CORCHETES":
                    retorno = new _LST_CORCHETES(nombreNoTerminal, tabla);

                    break;
                case "LST_CORCHETES_VAL":
                    retorno = new _LST_CORCHETES_VAL(nombreNoTerminal, tabla);

                    break;
                case "USAR_METO_VAR":
                    retorno = new _USAR_METO_VAR(nombreNoTerminal, tabla);

                    break;
                case "USAR_VARIABLEP":
                    retorno = new _USAR_VARIABLEP(nombreNoTerminal, tabla);

                    break;
                case "USAR_VARIABLE":
                    retorno = new _USAR_VARIABLE(nombreNoTerminal, tabla);

                    break;
                case "USAR_METODO":
                    retorno = new _USAR_METODO(nombreNoTerminal, tabla);

                    break;
                case "LLAMADA_FORMULARIO":
                    retorno = new _LLAMADA_FORMULARIO(nombreNoTerminal, tabla);

                    break;
                case "LST_CUERPO":
                    retorno = new _LST_CUERPO(nombreNoTerminal, tabla);

                    break;
                case "CUERPO":
                    retorno = new _CUERPO(nombreNoTerminal, tabla);

                    break;

                case "VALOR":
                    retorno = new _VALOR(nombreNoTerminal, tabla);

                    break;
                case "PAR_CORCHETES_VACIOS":
                    retorno = new _PAR_CORCHETES_VACIOS(nombreNoTerminal, tabla); 
                    break;
                case "E":
                    retorno = new _E(nombreNoTerminal, tabla);
                    break;
                case "FUNCIONES_NATIVAS":
                    retorno = new _FUNCIONES_NATIVAS(nombreNoTerminal, tabla);
                    break;
                case "IMPRIMIR":
                    retorno = new _IMPRIMIR(nombreNoTerminal, tabla);
                    break;


                case "ID_VAR_FUNC":
                    retorno = new _ID_VAR_FUNC(nombreNoTerminal, tabla);
                    break;

                case "LST_PUNTOSP":
                    retorno = new _LST_PUNTOSP(nombreNoTerminal, tabla);
                    break;

                case "ASIG_VALOR":
                    retorno = new _ASIG_VALOR(nombreNoTerminal, tabla);
                    break;

                case "PAR_CORCHETES_VAL":
                    retorno = new _PAR_CORCHETES_VAL(nombreNoTerminal, tabla);
                    break;

                default:
                    retorno= new nodoModelo("Desc_"+nombreNoTerminal, tabla);
                    Console.WriteLine("[generarArbol]No se encontró el nodo:"+nombreNoTerminal);
                    break;
            }
            
            return retorno;
        }
         
         
        private static String escapar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }

    }


}
