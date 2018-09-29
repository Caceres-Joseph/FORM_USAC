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
    class _ID_VAR_FUNC_PADRE : nodoModelo
    {
        public _ID_VAR_FUNC_PADRE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        itemValor retorno = new itemValor();


        /*
        
            ID_VAR_FUNC.Rule = ID_VAR_FUNC + LST_PUNTOSP
                             | tEste + sPunto + valId
                             | valId
                             | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                             | valId + sAbreParent + LST_VAL + sCierraParent
                             
            
                             #para los corchetes                

                            | tEste + sPunto + valId + LST_CORCHETES_VAL
                            | valId + LST_CORCHETES_VAL
                            | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL
                            | valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
                            ;
        */

        //elementoEntorno elementoEntorno;


        /*
      |-------------------------------------------------------------------------------------------------------------------
      | EJECUCIÓN DESDE EL CUERPO DEL METODO
      |-------------------------------------------------------------------------------------------------------------------
      |
      */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)

        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {
            itemRetorno retorno = new itemRetorno(0);
            itemValor te2 = getValor(tablaEntornos);

            //println(te2.getTipo() + "|" + te2.nombrePregunta.valLower + "|entorno de ejecutar final ===================================0");


            //if (!(te2.nombrePregunta.valLower.Equals("---") && te2.nombrePregunta.valLower.Equals("") && te2.nombrePregunta.valLower.Equals("--")))
            if (te2.nombrePregunta.esPregunta)
            {
                //println("Estoy ejecutando");
                if (te2 != null)
                {
                    //ahora hay que buscarl la pregunta en la tabla de simbolos prro.
                    itemValor te3 = getValId(te2.nombrePregunta, tablaEntornos);
                    if (te3.isTypeObjeto())
                    {
                        elementoEntorno entor = te3.getObjeto().tablaEntorno.raiz;
                        entor.este.ejecutarMetodoFuncion(new token("ejecutarfinal"), new lstValores(), entor);
                    }
                    else
                    {
                        println("no me retorno un objeto");
                    }
                }
                else
                {
                    println("[Error]sin mvalor fue nulo");
                }
            }

            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemValor getValor(elementoEntorno elementoEntorno)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeVacio();

            retorno.setTypeVacio(); //no puede retornar nada, es un metodo mahe



            if (hayErrores())
                return retorno;


            if (lstAtributos.listaAtributos.Count == 0)
            /*
            |---------------------------- 
            |  ID_VAR_FUNC + LST_PUNTOSP 
            */
            {
                #region reg1
                nodoModelo idVar = getNodo("ID_VAR_FUNC");
                if (idVar != null)
                {
                    nodoModelo lstPuntos = getNodo("LST_PUNTOSP");
                    if (lstPuntos != null)
                    {
                        _ID_VAR_FUNC temp1 = (_ID_VAR_FUNC)idVar;
                        _LST_PUNTOSP puntos = (_LST_PUNTOSP)lstPuntos;


                        itemValor te1 = temp1.getValor(elementoEntorno);
                        itemValor te2 = puntos.getValor(elementoEntorno, te1);


                        //aquí puedo revisar si fue una pregunta para poder guardarla en el entorno
                        if (te2.isTypeObjeto())
                        {
                            if (te2.nombreObjeto.Equals("form"))
                            {

                                //guardando la pregunta dentro de la tabla de simbolos, jejejejejejejejejejejejejeje
                                itemEntorno sim = new itemEntorno(te1.nombrePregunta, te1.nombrePregunta, te1, new token("publico"), new List<int>(), tablaSimbolos);
                                elementoEntorno.insertarEntorno(sim);


                                ///ejecuto el metodo ejecutar final, es el que muestra las preguntas
                                //elementoEntorno.este.ejecutarMetodoFuncion(new token("ejecutarfinal"), new lstValores(), sim.valor.getObjeto().tablaEntorno.raiz);
                                //println("entorno de ejecutar final ===================================0");

                                // sim.valor.getObjeto().tablaEntorno.raiz.este.ejecutarMetodoFuncion(new token("ejecutarfinal"), new lstValores(), sim.valor.getObjeto().tablaEntorno.raiz);


                            }
                        }

                        return te2;

                        //tengo que obtener el objeto de id_var_func

                    }
                }
                #endregion
            }

            else if (lstAtributos.listaAtributos.Count == 1)
            {
                if (hijos.Count > 0)
                /*
                |---------------------------- 
                | valId + LST_CORCHETES_VAL 
                |------------
                | Lst_Corchtes tiene que retornar una lista de tipo entero

                 */
                {
                    #region reg2
                    token nombreVar = lstAtributos.getToken(0);
                    nodoModelo nodoLstCor = getNodo("LST_CORCHETES_VAL");
                    if (nodoLstCor != null)
                    {
                        _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCor;
                        List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, nombreVar);
                        String item1 = lstAtributos.listaAtributos[0].nombretoken;
                        //mapeando el indice

                        if (item1.Equals("valId"))

                        {
                            return getValIdCorchetes(lstAtributos.listaAtributos[0].tok, elementoEntorno, listaEntero);
                        }
                        else
                        {
                            println(" valId + LST_CORCHETES_VAL -> No viene val id");
                        }
                    }
                    #endregion
                }
                else
                /*
                |---------------------------- 
                | valId 
                */
                {
                    #region reg3
                    String item1 = lstAtributos.listaAtributos[0].nombretoken;

                    if (item1.Equals("valId"))

                    {
                        return getValId(lstAtributos.listaAtributos[0].tok, elementoEntorno);
                    }
                    #endregion 
                }

            }

            else if (lstAtributos.listaAtributos.Count == 3)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                String item3 = lstAtributos.listaAtributos[2].nombretoken;

                if (item1.Equals("este") && item2.Equals(".") && item3.Equals("valId"))
                {
                    if (hijos.Count > 0)
                    /*
                    |---------------------------- 
                    |  tEste + sPunto + valId  + LST_CORCHETES_VAL
                    */
                    {
                        #region reg4
                        token nombreVar = lstAtributos.getToken(2);
                        nodoModelo nodoLstCor = getNodo("LST_CORCHETES_VAL");
                        if (nodoLstCor != null)
                        {
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCor;
                            List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, nombreVar);
                            String item11 = lstAtributos.listaAtributos[2].nombretoken;
                            //mapeando el indice

                            if (item11.Equals("valId"))

                            {
                                return getValIdCorchetes(lstAtributos.listaAtributos[2].tok, elementoEntorno.este.tablaEntorno.raiz, listaEntero);
                            }
                            else
                            {
                                println(" tEste + sPunto + valId  + LST_CORCHETES_VAL -> No viene val id");
                            }
                        }
                        #endregion
                    }
                    else
                    /*
                    |---------------------------- 
                    |  tEste + sPunto + valId
                    */
                    {
                        #region cuerpo
                        String esteId = lstAtributos.listaAtributos[2].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            return getValId(lstAtributos.listaAtributos[2].tok, elementoEntorno.este.tablaEntorno.raiz);
                        }
                        else
                        {
                            println("(tEste + sPunto + valId) No se encontró valId");
                        }

                        #endregion
                    }



                }
                if (item1.Equals("valId") && item2.Equals("(") && item3.Equals(")"))
                {
                    if (hijos.Count == 2)
                    /*
                    |---------------------------- 
                    |  valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
                    |------------------------
                    * Primero ejecuto el metodo que me tiene que retornar siempre dimension>0
                    * luego enviarle ese valor, para extraer lo que se quiere
                    */
                    {
                        #region cuerpo
                        if (hayErrores())
                            return retorno;

                        String esteId = lstAtributos.listaAtributos[0].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            //esto es del metodo
                            nodoModelo nodoTemp = getNodo("LST_VAL");
                            _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                            itemValor itemValorRetornoMetodo = elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(0), lstParametros.getLstValores(elementoEntorno), elementoEntorno.este.tablaEntorno.raiz);

                            //esto es de la parte del arreglo
                            nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                            List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[0].tok);

                            if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                            //tienen la misma dimension
                            {
                                println("getValCorchetes");
                                return getValCorchetes(lstAtributos.getToken(0), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                            }
                            else
                            //no tienen la misma dimensión.
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(0).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(0));
                                return retorno;
                            }
                        }
                        else
                        {
                            println("valId + sAbreParent + LST_VAL + sCierraParent; -> no viene valId");
                            return retorno;
                        }


                        #endregion
                    }

                    if (hijos.Count == 1)
                    {
                        String nombreHijo = hijos[0].nombre;
                        if (nombreHijo.Equals("LST_CORCHETES_VAL"))
                        /*
                        |---------------------------- 
                        |  valId + sAbreParent + sCierraParent + LST_CORCHETES_VAL;
                        */
                        {
                            #region cuerpo
                            if (hayErrores())
                                return retorno;

                            String esteId = lstAtributos.listaAtributos[0].nombretoken;

                            if (esteId.Equals("valId"))

                            {
                                //esto es del metodo
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                lstValores sinParametros = new lstValores();

                                itemValor itemValorRetornoMetodo = elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(0), sinParametros, elementoEntorno.este.tablaEntorno.raiz);

                                //esto es de la parte del arreglo
                                nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                                _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                                List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[0].tok);

                                if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                                //tienen la misma dimension
                                {
                                    println("getValCorchetes");
                                    return getValCorchetes(lstAtributos.getToken(0), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                                }
                                else
                                //no tienen la misma dimensión.
                                {
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(0).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(0));
                                    return retorno;
                                }
                            }
                            else
                            {
                                println("valId + sAbreParent + LST_VAL + sCierraParent; -> no viene valId");
                                return retorno;
                            }

                            #endregion
                        }
                        else if (nombreHijo.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        |  valId + sAbreParent + LST_VAL + sCierraParent;
                        |-------------
                        | Esto es un metodo
                        | Desde aquí puedo llamar a las preguntas, y tiene mayor prioridad
                        | si me encuentro dentro de un entorno de nombre, formulario, o de nombre grupo
                        */
                        {
                            #region cuerpo
                            String esteId = lstAtributos.listaAtributos[0].nombretoken;


                            /*if (elementoEntorno.nombre.Equals("formulario") || elementoEntorno.nombre.Equals("grupo"))

                            * Esto es como el constructor nuevo pregunta() 

                           { 
                           }*/

                            //primero busco en las preguntas, luego en los metodos, jejejejeje
                            itemValor ret = crearPregunta(elementoEntorno);
                            if (ret != null)
                            {
                                //eso quiere decir que es una pregunta

                                ret.nombrePregunta = lstAtributos.getToken(0);
                                ret.nombrePregunta.esPregunta = true;
                                return ret;
                            }

                            //si no lo encuentro como pregunta, sigo la ejecución en busca de un metodo.
                            if (esteId.Equals("valId"))

                            {
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                                return elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(0), lstParametros.getLstValores(elementoEntorno), elementoEntorno.este.tablaEntorno.raiz);
                            }
                            else
                            {
                                println("valId + sAbreParent + LST_VAL + sCierraParent; -> no viene valId");
                            }

                            #endregion

                        }
                    }

                    if (hijos.Count == 0)
                    /*
                    |---------------------------- 
                    |  valId + sAbreParent +  sCierraParent;
                    |-------------
                    | Esto es un metodo sin parámetros
                    | hay que buscarlo entre la lista de metodos
                    */
                    {
                        #region cuerpo
                        String esteId = lstAtributos.listaAtributos[0].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            lstValores sinParametros = new lstValores();
                            return elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(0), sinParametros, elementoEntorno.este.tablaEntorno.raiz);
                        }
                        else
                        {
                            println("valId + sAbreParent +  sCierraParent -> no viene valId");
                        }
                        #endregion 
                    }


                }

            }
            else if (lstAtributos.listaAtributos.Count == 5)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                String item3 = lstAtributos.listaAtributos[2].nombretoken;

                if (item1.Equals("este") && item2.Equals(".") && item3.Equals("valId"))
                {

                    if (hijos.Count == 2)
                    /*
                    |---------------------------- 
                    | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
                    */
                    {
                        #region cuerpo
                        if (hayErrores())
                            return retorno;

                        String esteId = lstAtributos.listaAtributos[2].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            //esto es del metodo
                            nodoModelo nodoTemp = getNodo("LST_VAL");
                            _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                            itemValor itemValorRetornoMetodo = elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(2), lstParametros.getLstValores(elementoEntorno), elementoEntorno.este.tablaEntorno.raiz);

                            //esto es de la parte del arreglo
                            nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                            List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[2].tok);

                            if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                            //tienen la misma dimension
                            {
                                println("getValCorchetes");
                                return getValCorchetes(lstAtributos.getToken(2), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                            }
                            else
                            //no tienen la misma dimensión.
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(2).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(2));
                                return retorno;
                            }
                        }
                        else
                        {
                            println("tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;");
                        }
                        #endregion
                    }
                    else if (hijos.Count == 1)
                    {
                        if (hijos[0].nombre.Equals("LST_CORCHETES_VAL"))

                        /*
                        |---------------------------- 
                        | tEste + sPunto + valId + sAbreParent + sCierraParent + LST_CORCHETES_VAL;
                        */
                        {
                            #region cuerpo
                            if (hayErrores())
                                return retorno;

                            String esteId = lstAtributos.listaAtributos[2].nombretoken;

                            if (esteId.Equals("valId"))

                            {
                                //esto es del metodo
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                lstValores sinParametros = new lstValores();

                                itemValor itemValorRetornoMetodo = elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(2), sinParametros, elementoEntorno.este.tablaEntorno.raiz);

                                //esto es de la parte del arreglo
                                nodoModelo nodoLstCorchetes = getNodo("LST_CORCHETES_VAL");
                                _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)nodoLstCorchetes;
                                List<int> listaEntero = lstCorchetes.getLstInt(elementoEntorno, lstAtributos.listaAtributos[2].tok);

                                if (itemValorRetornoMetodo.dimensiones.Count == listaEntero.Count)
                                //tienen la misma dimension
                                {
                                    println("getValCorchetes");
                                    return getValCorchetes(lstAtributos.getToken(2), elementoEntorno, listaEntero, itemValorRetornoMetodo);

                                }
                                else
                                //no tienen la misma dimensión.
                                {
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("El metodo: " + lstAtributos.getToken(2).val + " no devuelve la misma cantidad de dimensiones que a las que se quiere acceder", lstAtributos.getToken(2));
                                    return retorno;
                                }
                            }
                            else
                            {
                                println("tEste + sPunto + valId + sAbreParent + sCierraParent + LST_CORCHETES_VAL");
                            }
                            #endregion
                        }
                        else if (hijos[0].nombre.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                        */
                        {
                            #region cuerpo
                            print("tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent");
                            String esteId = lstAtributos.listaAtributos[2].nombretoken;

                            if (esteId.Equals("valId"))

                            {
                                nodoModelo nodoTemp = getNodo("LST_VAL");
                                _LST_VAL lstParametros = (_LST_VAL)nodoTemp;
                                return elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(2), lstParametros.getLstValores(elementoEntorno), elementoEntorno.este.tablaEntorno.raiz);
                            }
                            else
                            {
                                println("valId + sAbreParent + LST_VAL + sCierraParent; -> no viene valId");
                            }

                        }
                        #endregion

                    }
                    else if (hijos.Count == 0)
                    /*
                    |---------------------------- 
                    | tEste + sPunto + valId + sAbreParent  + sCierraParent
                    */
                    {

                        #region cuerpo
                        print("tEste + sPunto + valId + sAbreParent  + sCierraParent");
                        String esteId = lstAtributos.listaAtributos[2].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            nodoModelo nodoTemp = getNodo("LST_VAL");
                            lstValores sinParametros = new lstValores();
                            return elementoEntorno.este.ejecutarMetodoFuncion(lstAtributos.getToken(2), sinParametros, elementoEntorno.este.tablaEntorno.raiz);
                        }
                        else
                        {
                            println("valId + sAbreParent + LST_VAL + sCierraParent; -> no viene valId");
                        }
                        #endregion
                    }


                }

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
                tablaSimbolos.tablaErrores.insertErrorSemantic("La variable : " + idVal.val + "no se encuentra en el ambito correcto para su acceso, no se ha declarado  o no tiene permisos para acceder a ella", idVal);
            }

            return retorno;
        }


        public itemValor getValIdCorchetes(token idVal, elementoEntorno elem, List<int> lstIndex)

        /*
        |---------------------------- 
        | getValIdCorchetes
        */
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



        public itemValor crearPregunta(elementoEntorno elementoEntor)
        /*
          |--------------------------------------------------------------------------
          |  valId + sAbreParent + LST_VAL + sCierraParent;
          |  tNuevo + valId + sAbreParent + LST_VAL + sCierraParent
          |--------------------------------------------------------------------------
          | 
          | tengo que crear una nueva clase y cargar los valores globales con sus metdos, funciones, y validar constructores
          | hay que buscar la clase primero
          |
          */
        {

            itemValor retorno = new itemValor();
            retorno.setTypeVacio();


            if (hayErrores())
                return null;


            //token tokId = lstAtributos.getToken(1);
            token tokInstancia = lstAtributos.getToken(0);
            elementoClase temp = tablaSimbolos.getPregunta(tokInstancia);
            if (temp != null)
            {
                objetoClase ObjClase = new objetoClase(temp, tablaSimbolos);
                lstValores lstValores2 = new lstValores();
                //ahora tengo que llamar al constructor, pero digamos que no tiene, jejejeje


                if (hijos.Count > 0)
                {
                    nodoModelo hijo = hijos[0];
                    _LST_VAL lstval = (_LST_VAL)hijo;
                    lstValores2 = lstval.getLstValores(elementoEntor);
                    //me tiene que devolver una lista de valores,

                }
                ObjClase.ejecutarConstructor(lstAtributos.getToken(0), 0, lstValores2, ObjClase.tablaEntorno.raiz);
                ObjClase.ejecutarGlobales();//cargando sus valores globales 
                                            // jlk




                // println("========================00     imprimir lo que contiene la pregunta   00 ==================");
                // elementoEntor.imprimir();
                //println("ejecutando constructor de la claes, new objeto()");

                retorno.setValue(ObjClase, lstAtributos.getToken(0).valLower);
                retorno.setTypeObjeto(tokInstancia.valLower);
                //println("Es un objeto");
                return retorno;
            }
            else
            {
                return null;
            }

        }

    }
}
