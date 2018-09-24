using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
namespace _COMPI_Proyecto1.Analizador.Nodos.Ope_tipo
{
    class _TAM : nodoModelo
    /*
    ------------------------------------------
    * TAM.Rule = tEntero + sAbreParent + E + sCierraParent;
    ------------------------------------------
    * retorno:entero
    */
    {
        public _TAM(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones ope Tipo
        |-------------------------------------------------------------------------------------------------------------------
        |  
        */



        public override itemValor ope_tipo(elementoEntorno elem)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            if (hijos.Count != 1)
                return retorno;




            _E nodoE1 = (_E)hijos[0];


            if (hayErrores())
                return retorno;





            itemValor itemInicio = nodoE1.getValor(elem);


            if (itemInicio.valor != null)
            {


                if (itemInicio.isTypeBooleano() || itemInicio.isTypeEntero() || itemInicio.isTypeDecimal())
                {

                    Object intObject = itemInicio.getValorParseado("entero");
                    if (intObject!=null)
                    {
                        int reton = (int)intObject;
                        retorno.setValue(reton);
                        return retorno;
                    }
                }

                Object cadeObject = itemInicio.getValorParseado("cadena");
                 
                if (cadeObject != null)
                {

                    String caden = (String)cadeObject;

                    retorno.setValue(caden.Length);
                    return retorno;
                }
                else
                {

                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a cadena para verificar su tamaño", lstAtributos.getToken(0));
                    return retorno;
                }


            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear un objeto nulo", lstAtributos.getToken(0));
                return retorno;
            }


        }


        public  itemValor calcularTamanio(itemValor itemInicio, elementoEntorno elem)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;
            


            if (itemInicio.valor != null)
            {


                if (itemInicio.isTypeBooleano() || itemInicio.isTypeEntero() || itemInicio.isTypeDecimal())
                {

                    Object intObject = itemInicio.getValorParseado("entero");
                    if (intObject != null)
                    {
                        int reton = (int)intObject;
                        retorno.setValue(reton);
                        return retorno;
                    }
                }

                Object cadeObject = itemInicio.getValorParseado("cadena");

                if (cadeObject != null)
                {

                    String caden = (String)cadeObject;

                    retorno.setValue(caden.Length);
                    return retorno;
                }
                else
                {

                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear a cadena para verificar su tamaño", lstAtributos.getToken(0));
                    return retorno;
                }


            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede parsear un objeto nulo", lstAtributos.getToken(0));
                return retorno;
            }


        }
    }
}
