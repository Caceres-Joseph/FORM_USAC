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
    class _LST_PUNTOSP : _LST_PUNTOSP_PADRE
    {
        public _LST_PUNTOSP(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public itemEntorno getDestino(elementoEntorno elementoEntorno, itemValor item)
        {
            itemEntorno retorno = null;

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
                        objetoClase tempObjeto = item.getObjeto();

                        String item1 = lstAtributos.listaAtributos[1].nombretoken;
                        token nombreVar = lstAtributos.getToken(1);
                        if (item1.Equals("valId"))
                        {
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)getNodo("LST_CORCHETES_VAL");
                            return getEntornoId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz, lstCorchetes.getLstInt(elementoEntorno, nombreVar));
                        }

                    }
                    else
                    /*
                    |---------------------------- 
                    | sPunto + valId 
                    */
                    {

                        objetoClase tempObjeto = item.getObjeto();

                        String item1 = lstAtributos.listaAtributos[1].nombretoken;
                        token nombreVar = lstAtributos.getToken(1);
                        if (item1.Equals("valId"))
                        {
                            _LST_CORCHETES_VAL lstCorchetes = (_LST_CORCHETES_VAL)getNodo("LST_CORCHETES_VAL");
                            return getEntornoId(lstAtributos.listaAtributos[1].tok, tempObjeto.tablaEntorno.raiz, new List<int>());
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

                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo" + lstAtributos.getToken(1).val + "()[]", lstAtributos.getToken(1));

                    }
                    else if (hijos.Count == 1)
                    {


                        if (hijos[0].nombre.Equals("LST_VAL"))
                        /*
                        |---------------------------- 
                        | sPunto + valId + sAbreParent + LST_VAL + sCierraParent 
                        */
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se le puede asignar un valor a la expresión metodo" + lstAtributos.getToken(1).val + "()", lstAtributos.getToken(1));
                            
                        }
                    }
                }
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSyntax("[objeto.objeto]El atributo/arreglo/metodo al que se quiere acceder no es de tipo objeto", new token());
            }

            return null;
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
