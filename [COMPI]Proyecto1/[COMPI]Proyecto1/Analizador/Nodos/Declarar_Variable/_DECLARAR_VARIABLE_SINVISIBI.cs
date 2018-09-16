using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _DECLARAR_VARIABLE_SINVISIBI : nodoModelo
    {
        public _DECLARAR_VARIABLE_SINVISIBI(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            //ya estoy recibiendo la tabla donde debo trabajar prro
            if (hayErrores())
                return;

            token tipo = getTipo();
            token nombre = getIdentificador();
            //nodoModelo LST_CUERPO = getLST_CUERPO();

            token visbilidad = new token("privado");
            int dimension = getDimensiones();

            _VAL val = getNodoVAL();
            if (val!=null)
            {
                //se estan guardando valores en la variable

                itemEntorno it = new itemEntorno(nombre, tipo, val.getValor(), visbilidad, dimension, tablaSimbolos);
                tablaEntornos.insertarEntorno(it);
              
            }
            else
            {
                //Se declaro la variable pero el valor es nulo 
                itemEntorno it = new itemEntorno(nombre, tipo, new itemValor(), visbilidad, dimension, tablaSimbolos);
                tablaEntornos.insertarEntorno(it);
            }
             
        }

        public _VAL getNodoVAL()
        {
            nodoModelo temp = getNodo("VAL");
            if (temp!=null)
            {
                return (_VAL)temp;
            }
            else
            {
                return null;
            } 

        }
         

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Para cargar las variables globales prro
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public void cargarVariableGlobal(elementoClase simbolo)
        {
            if (hayErrores())
                return;


            token tipo = getTipo();
            token nombre = getIdentificador();
            //nodoModelo LST_CUERPO = getLST_CUERPO();

            token visbilidad = getVisibilidad(simbolo);

            int dimension = getDimensiones();
            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, getVAL(), dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstVariablesGlobales.insertarElemento(element);
        }

         

        public token getTipo()
        {

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO tipo = (_TIPO)tempNodo;

                token retorno= tipo.getTipo();

                if (retorno.valLower.Equals("vacio"))
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede declarar una variable de tipo vacio:"+retorno.val, retorno);
                }
                return retorno;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede declarar una variable de tipo vacio:" , new token("vacio"));
                return new token("vacio");
            }

            
        }


        public token getVisibilidad(elementoClase elem)
        {
             
                //Si no tiene visibilidad retorno la visibilidad de la clase, jake mate ateo! 
                return elem.visibilidad;

        }




        public token getIdentificador()
        {
            token retorno = new token("--");
            nodoModelo temp2 = getNodo("VAR_ARREGLO");
            if (temp2 != null)
            {
                _VAR_ARREGLO tempVar = (_VAR_ARREGLO)temp2;
                retorno = tempVar.getIdentificador();
            }
            return retorno;
        }


        public int getDimensiones()
        {

            int retorno = 0;
            nodoModelo temp2 = getNodo("VAR_ARREGLO");
            if (temp2 != null)
            {
                _VAR_ARREGLO tempVar = (_VAR_ARREGLO)temp2;
                retorno = tempVar.getDimensiones();
            }
            return retorno;
        }


        public nodoModelo getVAL()
        {
            nodoModelo tempNodo = getNodo("VAL");
            if (tempNodo != null)
                return tempNodo;
            else
                return new nodoModelo("---", tablaSimbolos);

        }
    }
}
