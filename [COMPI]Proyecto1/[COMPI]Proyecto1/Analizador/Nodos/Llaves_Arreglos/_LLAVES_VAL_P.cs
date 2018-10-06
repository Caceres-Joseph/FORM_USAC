using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;

namespace _COMPI_Proyecto1.Analizador.Nodos

{
    class _LLAVES_VAL_P : nodoModelo
    /*
    |--------------------------------------------------------------------------
    |  LLAVES_VAL_P.Rule = sAbreLlave + LST_LLAVES_VAL + sCierraLlave
    |                    | sAbreLlave + LST_VAL + sCierraLlave; 
    |-------------------------------------------------------------------------- 
    |  El LST_VAL puede venir vacio
    |
     */
    {
        public _LLAVES_VAL_P(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public void getArray(Dictionary<int, itemValor> diccionario, List<int> dimensioenes, token tipo, int dimensionActual, elementoEntorno elemEntor)
        {

            if (hayErrores())
                return;

            if (hijos.Count > 0)
            {
                nodoModelo temp = hijos[0];
                if (temp.nombre.Equals("LST_LLAVES_VAL"))
                {
                    _LST_LLAVES_VAL lstLlaves = (_LST_LLAVES_VAL)temp;
                    dimensionActual++; //incremento la dimensio
                    lstLlaves.getArray2(diccionario, dimensioenes, tipo, dimensionActual, elemEntor);

                    return;
                }
                else if (temp.nombre.Equals("LST_VAL"))
                {
                    dimensionActual++;
                    _LST_VAL lstVal = (_LST_VAL)temp;
                    lstValores lstVals = lstVal.getLstValores(elemEntor);

                    if (dimensionActual > dimensioenes.Count)
                    {
                        dimensioenes.Add(lstVals.listaValores.Count);
                    }
                    else
                    {
                        if (dimensioenes[dimensionActual - 1] != lstVals.listaValores.Count)
                        //hay problema con la cantidad de hijos
                        {

                            tablaSimbolos.tablaErrores.insertErrorSemantic("No coincide el tamaño de la matriz: " + dimensionActual, tipo);
                        }
                    }

                    foreach (itemValor it in lstVals.listaValores)
                    {
                        //validando los tipos 

                        if (it.dimensiones.Count > 0)
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("El lenguaje no soporta variables, o nuevos arreglos anidados de una forma diferente de {{E,E},{E,E}}: Error en matriz de tipo:" + tipo.val, tipo);
                            return;
                        }

                        object objeto = it.getValorParseado(tipo.valLower);


                        if (it.isTypeNulo())
                        {


                            itemValor item = new itemValor();
                            item.setTypeNulo();
                            int dimensionArray = diccionario.Count;
                            diccionario.Add(dimensionArray, item);
                        } 
                        else if (it.isTypeObjeto())
                        {

                            if (objeto == null)
                            //no se pudo parsear
                            {
                                println("Es de tipo objeto, pero no coincidieron los nombres");
                                //retorno un error 
                                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede introducir un tipo : " + it.getTipo() + " a una matriz de tipo : " + tipo.val, tipo);
                                return;
                            }
                            else
                            //si se pudo parsear
                            {

                                itemValor item = new itemValor();
                                item.setValue(objeto, tipo.valLower);

                                //hay que insertarlo al diccionario
                                int dimensionArray = diccionario.Count;
                                diccionario.Add(dimensionArray, item);
                            }

                            //hay que validar si son los mismos tipos de objeto


                        }
                        else
                        {
                            if (objeto == null)
                            //no se pudo parsear
                            {

                                /*if (tipo.val.Equals("--")) //no indicaron el tipo, asi que se vaya alv
                                {

                                    itemValor item = new itemValor();
                                    item.setType(it.getTipo());
                                    item.valor = objeto;

                                    //hay que insertarlo al diccionario
                                    int dimensionArray = diccionario.Count;
                                    diccionario.Add(dimensionArray, item);

                                }
                                else
                                {

                                    //retorno un error 
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("NO se puede introducir un tipo : " + it.getTipo() + " a una matriz de tipo : " + tipo.val, tipo);
                                    return;
                                }*/


                                //retorno un error 
                                tablaSimbolos.tablaErrores.insertErrorSemantic("NO se puede introducir un tipo : " + it.getTipo() + " a una matriz de tipo : " + tipo.val, tipo);
                                return;

                            }
                            else
                            //si se pudo parsear
                            {

                                itemValor item = new itemValor();
                                item.setType(tipo.valLower);
                                item.valor = objeto;

                                //hay que insertarlo al diccionario
                                int dimensionArray = diccionario.Count;
                                diccionario.Add(dimensionArray, item);
                            }

                        }
                    }


                    int listaFinal = getDimensionMapeada(dimensioenes, tipo);
                   // println("la lista mapeada es de longitud->" + listaFinal.ToString());


                }

            }
            else
            {
                //tiene que ser error, ya que no se apceta si trae cer en una dimension
            }


            return;
        }


        public int getDimensionMapeada(List<int> lista, token tipo)
        {
            int indice = 1;
            foreach (int temp in lista)
            {
                if (indice == 0)
                //no puede haber un tamaño cero
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No puede definir una dimensión de tamaño cero en la matriz de tipo: " + tipo.val, tipo);
                    return indice;
                }
                else
                {
                    indice = indice * temp;
                }
            }

            return indice;
        }



    }
}
