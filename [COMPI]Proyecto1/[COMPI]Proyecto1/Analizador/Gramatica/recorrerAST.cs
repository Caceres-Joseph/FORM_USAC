using _COMPI_Proyecto1.Analizador.Arbol;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Gramatica
{

    /*
     * En esta parte reconozco los impport
     * Cargo las otras clases
     */
    class recorrerAST
    {
        public static gramatica gramatica = new gramatica();

        public Boolean analizar(String cadena)
        {
            Boolean retorno = false;

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
                iniciar(raiz);

                // generarImagen(raiz);//aquí se genera el AST
                retorno = true;
            }

            return retorno;
        } 
        public void iniciar(ParseTreeNode raiz)
        {

            recorrerAst("nodo0", raiz); 
        }

         
        private static void recorrerAst(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = hijo.ToString();

                recorrerAst(nombreHijo, hijo);
                
            }
        }


        public void S(ParseTreeNode nodo, arbol arbol)
        {
             
            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 1)
                {
                    LST_CLASE(nodo.ChildNodes[0], arbol);
                }
                else if (nodo.ChildNodes.Count == 2)
                {
                    LST_IMPORT(nodo.ChildNodes[0], arbol);
                    LST_CLASE(nodo.ChildNodes[1], arbol);
                }
            }
        }
          
        public void LST_IMPORT(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {

                foreach (ParseTreeNode hijo in nodo.ChildNodes)
                {
                    IMPORT(hijo,arbol);
                }

            }
        }

        public void IMPORT(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
        public void LST_CLASE(ParseTreeNode nodo, arbol arbol)
        {

            foreach (ParseTreeNode hijo in nodo.ChildNodes)
            {
                CLASE(hijo, arbol);
            }

        }
        public void CLASE(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 6)
                {
                    EXTENDER(nodo.ChildNodes[2], arbol);
                    CP_CLASE(nodo.ChildNodes[4], arbol);
                }
                else if (nodo.ChildNodes.Count == 7)
                {
                    VISIBILIDAD(nodo.ChildNodes[2], arbol);
                    EXTENDER(nodo.ChildNodes[3], arbol);
                    CP_CLASE(nodo.ChildNodes[5],arbol);
                }
            }
        }
        public void TIPO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
        public void EXTENDER(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {

            }
        }
        public void VISIBILIDAD(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                 
            }
        }
        public void LST_PARAMETROS(ParseTreeNode nodo, arbol arbol)
        {


            foreach (ParseTreeNode hijo in nodo.ChildNodes)
            {
                PARAMETRO(hijo, arbol);
            }
        }
        public void PARAMETRO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {
                    TIPO(nodo.ChildNodes[0], arbol);
                    VALOR(nodo.ChildNodes[1], arbol);

                } 
            }
        }
        public void LST_VAL(ParseTreeNode nodo, arbol arbol)
        {

            foreach (ParseTreeNode hijo in nodo.ChildNodes)
            {
                PARAMETRO(hijo, arbol);
            }
        }

        public void CP_CLASE(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }

        public void CUERPO_CLASE(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void METODO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void SOBRESCRITURA(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void MAIN(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void CONSTRUCTOR(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void DECLARAR_VARIABLE_GLOBAL(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void DECLARAR_VARIABLE_SINVISIBI(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void VAL(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void LST_LLAVES_VAL(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }

        public void LLAVES_VAL_P(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }

        public void VAR_ARREGLO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void LST_CORCHETES(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void LST_CORCHETES_VAL(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void USAR_METO_VAR(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void USAR_VARIABLEP(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void USAR_VARIABLE(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void USAR_METODO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void LLAMADA_FORMULARIO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }
        public void LST_CUERPO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }

        public void CUERPO(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }

        public void VALOR(ParseTreeNode nodo, arbol arbol)
        {

            if (nodo.ChildNodes.Count != 0)//por si no trae nodos
            {
                if (nodo.ChildNodes.Count == 2)
                {

                }
                else if (nodo.ChildNodes.Count == 1)
                {

                }
            }
        }






    }
}
