using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Valor;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _E : nodoModelo
    {
        public _E(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar(elementoEntorno elem, itemEntorno item)
        {

            switch (hijos.Count)
            {
                case 1:

                    break;

                case 2:
                    if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        println(signo);
                    }
                    break;

            }
        }

        public itemValor getValor()
        {
            itemValor ob = new itemValor();

            if (hayErrores())
                return ob;

            switch (hijos.Count)
            {
                case 0:
                    if (lstAtributos.listaAtributos.Count > 0)
                    {

                        return parseandoDato(lstAtributos.listaAtributos[0]);

                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E] Se esperaba un valor ", new token());
                        return ob;
                        //hay un error
                    }
                     
                case 1:
                    //operador unario


                    return ob; 
                case 2:
                    //operador binario
                    if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        switch (signo)
                        {
                            case "+":
                                opAritmetica ope = new opAritmetica(hijos[0], hijos[1]);
                                return ope.opSuma(); 
                            default:
                                tablaSimbolos.tablaErrores.insertErrorSyntax("[E]No se reconoció el sigono", lstAtributos.getToken(0));
                                return ob; 
                        } 
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E]Se esperaba un signo para operación binaria",new token());
                        return ob;
                    }
                default:
                    return ob;
            }


        }


        public itemValor parseandoDato(token tok)
        {
            itemValor retorno = new itemValor();

            return retorno;
        }
    }
}
