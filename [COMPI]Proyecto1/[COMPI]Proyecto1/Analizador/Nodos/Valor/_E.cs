using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using _COMPI_Proyecto1.Analizador.Nodos.IdVar_func;
using _COMPI_Proyecto1.Analizador.Nodos.Valor;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeLogico;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.Operelacional;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _E : nodoModelo
    {
        public _E(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }




        public itemValor getValor(elementoEntorno elmen)
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

                    if (hijos[0].nombre.Equals("OPE_ARITME"))
                    {

                        return hijos[0].ope_tipo(elmen);

                    }
                    else if (hijos[0].nombre.Equals("OPE_TIPO"))
                    {
                        
                        return hijos[0].ope_tipo(elmen);
                    }
                    //operador unario
                    else if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        switch (signo)
                        {
                            //Logico
                            case "-":
                                negativo opNeg = new negativo(hijos[0], tablaSimbolos, lstAtributos.getToken(0));
                                return opNeg.opNot(" Asignando valor Negativo", elmen);

                            case "!":
                                Not opeNot = new Not(hijos[0], tablaSimbolos, lstAtributos.getToken(0));
                                return opeNot.opNot("Not", elmen);

                            case "(":
                                _E ope = (_E)hijos[0];
                                itemValor te = ope.getValor(elmen);
                                return te;

                            default:
                                tablaSimbolos.tablaErrores.insertErrorSyntax("[E]No se reconoció el signo", lstAtributos.getToken(0));
                                return ob;
                        }
                    }
                    else
                    //ID_VAR_FUNC
                    {
                        nodoModelo busq = getNodo("ID_VAR_FUNC");
                        if (busq != null)
                        {
                            _ID_VAR_FUNC idFunc = (_ID_VAR_FUNC)busq;
                            return idFunc.getValor(elmen);
                        }

                        tablaSimbolos.tablaErrores.insertErrorSyntax("[E]Se esperaba un signo para operación unaria", new token());
                        return ob;
                    }

                case 2:
                    //operador binario
                    if (lstAtributos.listaAtributos.Count > 0)
                    {
                        String signo = lstAtributos.getValItem(0);
                        switch (signo)
                        {
                            //Aritmetica
                            case "+":
                                suma ope = new suma(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return ope.opSuma(elmen);
                            case "-":
                                resta opeRes = new resta(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeRes.opResta(elmen);
                            case "*":
                                multiplicacion opeMul = new multiplicacion(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMul.opMultiplicacion(elmen);
                            case "/":
                                division opeDiv = new division(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeDiv.opDivision(elmen);
                            case "^":
                                potencia opePot = new potencia(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opePot.opPotencia(elmen);
                            case "%":
                                modulo opeModulo = new modulo(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeModulo.opModulo(elmen);


                            //Relacional
                            case "==":
                                IgualQue opeIgualacion = new IgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeIgualacion.opIgualacion("Igualación", elmen);
                            case "!=":
                                DiferenteQue opeDiferenciacion = new DiferenteQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeDiferenciacion.opDiferenciacion("Diferenciación", elmen);
                            case ">":
                                MayorQue opeMayor = new MayorQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMayor.opMayorQue("Mayor Que", elmen);
                            case ">=":
                                MayorIgualQue opeMayorIgual = new MayorIgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMayorIgual.opMayorIgualQue("Mayor o Igual Que", elmen);
                            case "<":
                                MenorQue opeMenor = new MenorQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMenor.opMenorQue("Menor Que", elmen);
                            case "<=":
                                MenorIgualQue opeMenorIgual = new MenorIgualQue(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeMenorIgual.opMenorIgualQue("Menor o Igual Que", elmen);

                            //logicas

                            case "&&":
                                And opeAnd = new And(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeAnd.opAnd("And", elmen);
                            case "||":
                                Or opeOr = new Or(hijos[0], hijos[1], tablaSimbolos, lstAtributos.getToken(0));
                                return opeOr.opOr("Or", elmen);

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
                    retorno.convertirCadena(tok.tok.val);
                    return retorno;
                case "valCadena2":


                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    retorno.convertirCadena2(tok.tok.val);
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
                case "nulo":
                    retorno = new itemValor();
                    retorno.setTypeNulo();
                    return retorno;

                default:
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se reconoce el tipo: " + tok.tok.val, tok.tok);
                    return retorno;

            }

            //return retorno;
        }
    }
}
