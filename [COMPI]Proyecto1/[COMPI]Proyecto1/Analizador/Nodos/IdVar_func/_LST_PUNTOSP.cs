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
    class _LST_PUNTOSP : nodoModelo
    {

        /*
        
            LST_PUNTOSP.Rule    -> sPunto + valId
                                | sPunto + valId + sAbreParent + LST_VAL + sCierraParent
                
            
                                #Corchetes

                                | sPunto + valId + LST_CORCHETES_VAL
                                | sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL;
        */
        public _LST_PUNTOSP(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
                    if (hijos.Count>0)
                    /*
                    |---------------------------- 
                    | sPunto + valId + LST_CORCHETES_VAL 
                    */
                    {

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

                            if (tempObjeto!=null)
                            {
                                return getValId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz);
                            }
                            else
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("No se pudo parsear el objeto",lstAtributos.listaAtributos[1].tok);
                                return retorno;
                            }
                            
                        }
                        
                    }

                }else if (lstAtributos.listaAtributos.Count == 4)
                {
                    if (hijos.Count>0)
                    /*
                    |---------------------------- 
                    | sPunto + valId + sAbreParent + LST_VAL + sCierraParent + LST_CORCHETES_VAL 
                    */
                    {

                    }
                    else
                    /*
                    |---------------------------- 
                    | sPunto + valId + sAbreParent + LST_VAL + sCierraParent 
                    */
                    {

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
    }
}
