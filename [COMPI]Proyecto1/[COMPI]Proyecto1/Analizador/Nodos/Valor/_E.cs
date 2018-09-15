using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Valor;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica;
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
            ob.setTypeNulo();

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
                                suma ope = new suma(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return ope.opSuma();
                            case "-":
                                resta opeRes = new resta(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeRes.opResta();
                            case "*":
                                multiplicacion opeMul = new multiplicacion(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMul.opMultiplicacion();
                            case "/":
                                division opeDiv= new division(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeDiv.opDivision();
                            case "^":
                                potencia opePot = new potencia(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opePot.opPotencia();
                            case "%":
                                modulo opeModulo = new modulo(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeModulo.opModulo();
                            default:
                                tablaSimbolos.tablaErrores.insertErrorSyntax("[E]No se reconoció el sigono", lstAtributos.getToken(0));
                                return ob;
                        }
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E]Se esperaba un signo para operación binaria", new token());
                        return ob;
                    }
                default:
                    return ob;
            }


        }


        public itemValor parseandoDato(itemAtributo tok)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            switch (tok.nombretoken)
            {
                case "valBoolean":
                    retorno = new itemValor();
                    retorno.setTypeBooleano();
                    switch (tok.tok.valLower)
                    {
                        case "false":
                            retorno.valor = false;
                            return retorno;
                        case "true":
                            retorno.valor = true;
                            return retorno;
                        case "verdadero":
                            retorno.valor = true;
                            return retorno;
                        case "falso":
                            retorno.valor = false;
                            return retorno;
                        default:
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parser a booleano el tipo:" + tok.tok.val, tok.tok);
                            return retorno;
                    }
                case "valCaracter":
                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    retorno.convertirCadena(tok.tok.valLower);

                    return retorno;
                case "valCadena":


                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    retorno.convertirCadena(tok.tok.valLower);
                    return retorno;
                case "valCadena2":


                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    retorno.convertirCadena2(tok.tok.valLower);
                    return retorno;
                case "valNumero":
                    try
                    {
                        retorno = new itemValor();
                        retorno.setTypeEntero();
                        retorno.valor = int.Parse(tok.tok.valLower);
                        return retorno;
                    }
                    catch (FormatException e)
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear a entero el valor: " + tok.tok.val, tok.tok);
                        return retorno;
                    }
                case "valDecimal":
                    try
                    {
                        retorno = new itemValor();
                        retorno.setTypeDecimal();
                        retorno.valor = double.Parse(tok.tok.valLower);
                        return retorno;
                    }
                    catch (FormatException e)
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear a decimal el valor: " + tok.tok.val, tok.tok);
                        return retorno;
                    }
                default:
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se reconoce el tipo: " + tok.tok.val, tok.tok);
                    return retorno;

            }

            //return retorno;
        }
    }
}
