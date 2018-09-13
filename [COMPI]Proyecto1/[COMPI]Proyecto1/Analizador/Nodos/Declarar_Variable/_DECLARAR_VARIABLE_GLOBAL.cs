using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _DECLARAR_VARIABLE_GLOBAL : nodoModelo
    {
        public _DECLARAR_VARIABLE_GLOBAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;


            //Verificando si tengo como hijo a DECLARAR_VARIABLE_SINVISIBI
            if (hay_DECLARAR_VARIABLE_SINVISIBI(simbolo))
            {
                return;
            }

            // println("llego al contructor");

            token tipo = getTipo();
            token nombre = getIdentificador();
            //nodoModelo LST_CUERPO = getLST_CUERPO();

            token visbilidad = getVisibilidad(simbolo);

            int dimension = getDimensiones();
            elementoPolimorfo element = new elementoPolimorfo(visbilidad, tablaSimbolos, tipo, nombre, getVAL(), dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstVariablesGlobales.insertarElemento(element);
        }


        public token getVisibilidad(elementoClase elem)
        {

            nodoModelo tempNodo = getNodo("VISIBILIDAD");
            if (tempNodo != null)
            {
                _VISIBILIDAD visi = (_VISIBILIDAD)tempNodo;
                return visi.getVisibilidad();
            }
            else
                //Si no tiene visibilidad retorno la visibilidad de la clase, jake mate ateo! 
                return elem.visibilidad;

        }


        public token getTipo()
        {

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO tipo = (_TIPO)tempNodo;
                return tipo.getTipo();
            }
            else
                return new token("vacio");

        }


        public Boolean hay_DECLARAR_VARIABLE_SINVISIBI(elementoClase simbolo)
        {

            nodoModelo tempNodo = getNodo("DECLARAR_VARIABLE_SINVISIBI");
            if (tempNodo != null)
            {
                _DECLARAR_VARIABLE_SINVISIBI var = (_DECLARAR_VARIABLE_SINVISIBI)tempNodo;
                var.cargarVariableGlobal(simbolo);

                return true;
            }

            else
                return false;
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
