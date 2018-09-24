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
    class _ID_VAR_FUNC : _ID_VAR_FUNC_PADRE
    {
        public _ID_VAR_FUNC(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemEntorno getDestino(elementoEntorno elementoEntorno)
        {
            itemEntorno retorno = null;

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
                        itemEntorno te2 = puntos.getDestino(elementoEntorno, te1);
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

                    String item1 = lstAtributos.listaAtributos[0].nombretoken;
                    token nombreVar = lstAtributos.getToken(0);
                    if (item1.Equals("valId"))

                    {
                        _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)getNodo("LST_CORCHETES_VAL");
                        return getEntornoId(lstAtributos.listaAtributos[0].tok, elementoEntorno, lstCorchetes.getLstInt(elementoEntorno, nombreVar));
                    }
                    #endregion
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
                        return getEntornoId(lstAtributos.listaAtributos[0].tok, elementoEntorno, new List<int>());
                    }
                    
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


                        String valId = lstAtributos.listaAtributos[2].nombretoken;
                        token nombreVar = lstAtributos.getToken(2);
                        if (valId.Equals("valId"))

                        {
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)getNodo("LST_CORCHETES_VAL");
                            return getEntornoId(lstAtributos.listaAtributos[2].tok, elementoEntorno.este.tablaEntorno.raiz, lstCorchetes.getLstInt(elementoEntorno, nombreVar));
                        }

                        #endregion
                    }
                    else
                    /*
                    |---------------------------- 
                    |  tEste + sPunto + valId
                    */
                    {
                        String valId = lstAtributos.listaAtributos[2].nombretoken;

                        if (valId.Equals("valId"))

                        {
                            return getEntornoId(lstAtributos.listaAtributos[2].tok, elementoEntorno.este.tablaEntorno.raiz, new List<int>());
                        }

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

                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo" + lstAtributos.getToken(0).val + "()[] ", lstAtributos.getToken(0));

                    }

                    if (hijos.Count == 1)
                    {
                        String nombreHijo = hijos[0].nombre;
                        if (nombreHijo.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        |  valId + sAbreParent + LST_VAL + sCierraParent;
                        |-------------
                        | Esto es un metodo
                        */
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo" + lstAtributos.getToken(0).val + "()", lstAtributos.getToken(0));

                        }
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
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo este." + lstAtributos.getToken(0).val + "()[] ", lstAtributos.getToken(0));

                    }
                    else if (hijos.Count == 1)
                    {
                        if (hijos[0].nombre.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        | tEste + sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                        */
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo este." + lstAtributos.getToken(0).val + "() ", lstAtributos.getToken(0));

                        }
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

        public itemEntorno getEntornoId(token idVal, elementoEntorno elem, List<int> lstDimensiones)
        // aquí hay que buscar dentro de la tabla de simbolos y devoler el valor, e ir buscando
        // hacia atraás para encontral el id
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            itemEntorno et = elem.getItemValor(idVal.valLower);
            if (et != null)
            {
                et.lstDimensionesAcceso = lstDimensiones;
                return et;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La variable : " + idVal.val + "no se encuentra en el ambito correcto para su acceso, no se ha declarado  o no tiene permisos para acceder a ella", idVal);
            }

            return null;
        }

         
    }
}
