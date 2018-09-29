using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;

namespace _COMPI_Proyecto1.Analizador.Nodos.IdVar_func
{
    class _LST_PUNTOSP_PADRE : nodoModelo
    /*

       LST_PUNTOSP.Rule    -> sPunto + valId
                           | sPunto + valId + sAbreParent + LST_VAL + sCierraParent


                           #Corchetes

                           | sPunto + valId + LST_CORCHETES_VAL
                           | sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
   */

    {
        public _LST_PUNTOSP_PADRE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        | elementoEntorno,es el ambito actual
        | itemValor es el objeto donde voy a seguir buscandos
        | solo puedo recibir item de tipo objeto
        */

        public itemValor getValor(elementoEntorno elementoEntorno, itemValor item)
        {
           
            itemValor retorno = new itemValor();
            retorno.setTypeVacio();



            if (hayErrores())
                return retorno;


            if (item.isTypeObjeto())
            {
                if (lstAtributos.listaAtributos.Count == 2)
                {
                    if (hijos.Count > 0)
                    /*
                    |---------------------------- 
                    | sPunto + valId + LST_CORCHETES_VAL 
                    */
                    {

                        token nombreVar = lstAtributos.getToken(1);
                        nodoModelo nodoLstCor = getNodo("LST_CORCHETES_VAL");
                        if (nodoLstCor != null)
                        {
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCor;
                            List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, nombreVar);
                            String item1 = lstAtributos.listaAtributos[1].nombretoken;
                            //mapeando el indice

                            if (item1.Equals("valId"))

                            {
                                objetoClase tempObjeto = item.getObjeto();

                                if (tempObjeto != null)
                                {
                                    return getValIdCorchetes(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz, listaEntero);
                                    //return getValId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz);
                                }
                                else
                                {
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear el objeto", lstAtributos.listaAtributos[1].tok);
                                    return retorno;
                                }

                            }
                            else
                            {
                                println("sPunto + valId + LST_CORCHETES_VAL -> No viene val id");
                            }
                        }

                    }
                    else
                    /*
                    |---------------------------- 
                    | sPunto + valId 
                    */
                    {

                        String item1 = lstAtributos.listaAtributos[1].nombretoken;

                        if (item1.Equals("valId"))

                        {
                            objetoClase tempObjeto = item.getObjeto();

                            if (tempObjeto != null)
                            {
                                return getValId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz);
                            }
                            else
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear el objeto", lstAtributos.listaAtributos[1].tok);
                                return retorno;
                            }

                        }

                    }

                }
                else if (lstAtributos.listaAtributos.Count == 4)
                {


                    if (hijos.Count == 2)
                    /*
                    |---------------------------- 
                    | sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL 
                    */
                    {
                        if (hayErrores())
                            return retorno;

                        String esteId = lstAtributos.listaAtributos[1].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            objetoClase tempObjeto = item.getObjeto();


                            //esto es del metodo
                            nodoModelo nodoTemp = getNodo("LST_VAL");
                            _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                            itemValor itemValorRetornoMetodo = tempObjeto.ejecutarMetodoFuncion(lstAtributos.getToken(1), lstParametros.getLstValores(elementoEntorno), tempObjeto.tablaEntorno.raiz);

                            //esto es de la parte del arreglo
                            nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                            List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[1].tok);

                            if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                            //tienen la misma dimension
                            {

                                return getValCorchetes(lstAtributos.getToken(1), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                            }
                            else
                            //no tienen la misma dimensión.
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(1).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(1));
                                return retorno;
                            }
                        }
                        else
                        {
                            println(" sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL  -> no viene valId");
                            return retorno;
                        }

                    }
                    else if (hijos.Count == 1)
                    {

                        if (hijos[0].nombre.Equals("LST_CORCHETES_VAL"))
                        /*
                        |---------------------------- 
                        | sPunto + valId + sAbreParent +  sCierraParent + LST_CORCHETES_VAL 
                        */
                        {


                            if (hayErrores())
                                return retorno;

                            String esteId = lstAtributos.listaAtributos[1].nombretoken;

                            if (esteId.Equals("valId"))

                            {
                                objetoClase tempObjeto = item.getObjeto();


                                //esto es del metodo
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                lstValores sinParametros = new lstValores();
                                //elementoEntorno.este.tablaEntorno.raiz
                                itemValor itemValorRetornoMetodo = tempObjeto.ejecutarMetodoFuncion(lstAtributos.getToken(1), sinParametros, tempObjeto.tablaEntorno.raiz);

                                //esto es de la parte del arreglo
                                nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                                _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                                List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[1].tok);

                                if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                                //tienen la misma dimension
                                {

                                    return getValCorchetes(lstAtributos.getToken(1), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                                }
                                else
                                //no tienen la misma dimensión.
                                {
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(1).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(1));
                                    return retorno;
                                }
                            }
                            else
                            {
                                println(" sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL  -> no viene valId");
                                return retorno;
                            }
                        }
                        else if (hijos[0].nombre.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        | sPunto + valId + sAbreParent + LST_VAL + sCierraParent 
                        */
                        {




                            #region cuerpo
                            String esteId = lstAtributos.listaAtributos[1].nombretoken;

                            objetoClase tempObjeto = item.getObjeto();

                            if (esteId.Equals("valId"))

                            {
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                                itemValor reto= tempObjeto.ejecutarMetodoFuncion(lstAtributos.getToken(1), lstParametros.getLstValores(elementoEntorno), tempObjeto.tablaEntorno.raiz);
                                reto.nombrePregunta = item.nombrePregunta;

                                return reto; 
                            }
                            else
                            {
                                println("sPunto + valId + sAbreParent + LST_VAL + sCierraParent ");
                            }

                            #endregion


                        }
                    }
                    else if (hijos.Count == 0)
                    /*
                    |---------------------------- 
                    | sPunto + valId + sAbreParent + sCierraParent 
                    */
                    {
                        #region cuerpo
                        String esteId = lstAtributos.listaAtributos[1].nombretoken;

                        objetoClase tempObjeto = item.getObjeto();


                        println("el nombre del objeto es " + tempObjeto.cuerpoClase.nombreClase.val);
                        if (esteId.Equals("valId"))

                        {
                            nodoModelo nodoTemp = getNodo("LST_VAL");
                            lstValores sinParametros = new lstValores();
                            return tempObjeto.ejecutarMetodoFuncion(lstAtributos.getToken(1), sinParametros, tempObjeto.tablaEntorno.raiz);
                        }
                        else
                        {
                            println("sPunto + valId + sAbreParent + sCierraParent ");
                        }

                        #endregion
                    }
                }


            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSyntax("[objeto.objeto]El atributo/arreglo/metodo al que se quiere acceder no es de tipo objeto", new token());
            }

            return retorno;
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemValor getValId(token idVal, elementoEntorno elem)
        // aquí hay que buscar dentro de la tabla de simbolos y devoler el valor, e ir buscando
        // hacia atraás para encontral el id
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            itemEntorno et = elem.getItemValor(idVal.valLower);
            if (et != null)
            {
                return et.valor;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se ha declarado la variable : " + idVal.val + " o no tiene permisos para acceder a ella", idVal);
            }

            return retorno;

        }


        public itemValor getValIdCorchetes(token idVal, elementoEntorno elem, List<int> lstIndex)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            itemEntorno et = elem.getItemValor(idVal.valLower);

            if (et != null)
            {


                if (et.dimension.Count == lstIndex.Count)
                {

                    int indiceFinal = 1;
                    //validando si no se salió de los indices
                    for (int i = 0; i < et.dimension.Count; i++)
                    {
                        if (lstIndex[i] < et.dimension[i])
                        {

                            if (i == 0)
                            //inicilizo la lista
                            {
                                indiceFinal = lstIndex[i];
                            }
                            else
                            {
                                indiceFinal = indiceFinal * et.dimension[i] + lstIndex[i];
                            }


                        }
                        else
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("El índice está fuera de rango de la matriz: " + idVal.val + " , rango máximo permitido para la dimensión:" + i + " es " + (et.dimension[i] - 1), idVal);
                            return retorno;
                        }
                    }

                    //validando que no salga del arreglo de adentro

                    if (indiceFinal < et.valor.arrayValores.Count)
                    {
                        return et.valor.arrayValores[indiceFinal];
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede acceder a la posición  de la matriz: " + idVal.val, idVal);
                        return retorno;
                    }
                    //println("El indice al que quiero acceder es al indice :" + indiceFinal + " de la matriz :" + idVal.val);

                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No coinciden las dimensiones en la matriz: " + idVal.val + " para acceder a ella", idVal);
                    return retorno;
                }

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La variable : " + idVal.val + "no se encuentra en el ambito correcto para su acceso, no se ha declarado  o no tiene permisos para acceder a ella", idVal);
            }



            return retorno;
        }


        public itemValor getValCorchetes(token idVal, elementoEntorno elem, List<int> lstIndex, itemValor itemVal)

        /*
        |---------------------------- 
        | getValCorchetes
        *--------------------
        * Sireve para los metodos que retornanan arreglos
        */
        {
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            if (itemVal.dimensiones.Count == lstIndex.Count)
            {

                int indiceFinal = 1;
                //validando si no se salió de los indices
                for (int i = 0; i < itemVal.dimensiones.Count; i++)
                {
                    if (lstIndex[i] < itemVal.dimensiones[i])
                    {

                        if (i == 0)
                        //inicilizo la lista
                        {
                            indiceFinal = lstIndex[i];
                        }
                        else
                        {
                            indiceFinal = indiceFinal * itemVal.dimensiones[i] + lstIndex[i];
                        }


                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("El índice está fuera de rango de la matriz: " + idVal.val + " , rango máximo permitido para la dimensión:" + i + " es " + (itemVal.dimensiones[i] - 1), idVal);
                        return retorno;
                    }
                }

                //validando que no salga del arreglo de adentro

                if (indiceFinal < itemVal.arrayValores.Count)
                {
                    return itemVal.arrayValores[indiceFinal];
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede acceder a la posición  de la matriz: " + idVal.val, idVal);
                    return retorno;
                }
                //println("El indice al que quiero acceder es al indice :" + indiceFinal + " de la matriz :" + idVal.val);

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No coinciden las dimensiones en la matriz: " + idVal.val + " para acceder a ella", idVal);
                return retorno;
            }

        }
    }
}
