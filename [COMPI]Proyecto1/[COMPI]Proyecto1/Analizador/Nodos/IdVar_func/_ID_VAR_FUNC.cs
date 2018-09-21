using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;

namespace _COMPI_Proyecto1.Analizador.Nodos.IdVar_func
{
    class _ID_VAR_FUNC : nodoModelo
    {
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

        elementoEntorno elementoEntorno;

        public _ID_VAR_FUNC(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {


        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override void ejecutar(elementoEntorno tablaEntornos)
        {

            this.elementoEntorno = tablaEntornos;
        }


        public itemValor getValor(elementoEntorno tablaEntornos)
        {
            itemValor retorno = new itemValor();
            retorno.setTypeVacio();

            this.retorno.setTypeVacio(); //no puede retornar nada, es un metodo mahe
            this.elementoEntorno = tablaEntornos;


            if (hayErrores())
                return retorno;


            if (lstAtributos.listaAtributos.Count == 0)
            /*
            |---------------------------- 
            |  ID_VAR_FUNC + LST_PUNTOSP 
            */
            {
                nodoModelo idVar = getNodo("ID_VAR_FUNC");
                if (idVar != null)
                {
                    nodoModelo lstPuntos = getNodo("LST_PUNTOSP");
                    if (lstPuntos != null)
                    {
                        _ID_VAR_FUNC temp1 = (_ID_VAR_FUNC)idVar;
                        _LST_PUNTOSP puntos = (_LST_PUNTOSP)lstPuntos;


                        itemValor te1 = temp1.getValor(tablaEntornos);
                        itemValor te2 = puntos.getValor(tablaEntornos, te1);
                        return te2;

                        //tengo que obtener el objeto de id_var_func



                    }
                }

            }



            if (lstAtributos.listaAtributos.Count == 1)
            {
                if (hijos.Count > 0)
                /*
                |---------------------------- 
                | valId + LST_CORCHETES_VAL 
                |------------
                | Lst_Corchtes tiene que retornar una lista de tipo entero

                 */
                {
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

                }
                else
                /*
                |---------------------------- 
                | valId 
                */
                {
                    String item1 = lstAtributos.listaAtributos[0].nombretoken;

                    if (item1.Equals("valId"))

                    {
                        return getValId(lstAtributos.listaAtributos[0].tok, elementoEntorno);
                    }

                }

            }

            if (lstAtributos.listaAtributos.Count == 3)
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

                    }
                    else
                    /*
                    |---------------------------- 
                    |  tEste + sPunto + valId
                    */
                    {

                        String esteId = lstAtributos.listaAtributos[2].nombretoken;

                        if (esteId.Equals("valId"))

                        {
                            return getValId(lstAtributos.listaAtributos[2].tok, elementoEntorno.este.tablaEntorno.raiz);
                        }
                        else
                        {
                            println("(tEste + sPunto + valId) No se encontró valId");
                        }


                    }



                }
                if (item1.Equals("valId") && item2.Equals("(") && item3.Equals(")"))
                {
                    if (hijos.Count > 0)
                    /*
                    |---------------------------- 
                    |  valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
                    */
                    {

                    }
                    else
                    /*
                    |---------------------------- 
                    |  valId + sAbreParent + LST_VAL + sCierraParent;
                    */
                    {

                    }

                }

            }

            if (lstAtributos.listaAtributos.Count == 5)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                String item3 = lstAtributos.listaAtributos[2].nombretoken;

                if (item1.Equals("este") && item2.Equals(".") && item2.Equals("valId"))
                {

                    if (hijos.Count > 0)
                    /*
                    |---------------------------- 
                    | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
                    */
                    {

                    }
                    else
                    /*
                    |---------------------------- 
                    | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                    */
                    {

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
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede acceder a la posición  de la matriz: " + idVal.val , idVal);
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
    }
}
