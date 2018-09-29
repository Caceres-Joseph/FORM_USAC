using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _METODO : nodoModelo
    /* METODO.Rule = VISIBILIDAD + TIPO + VAR_ARREGLO + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave
            | TIPO + VAR_ARREGLO + sAbreParent + LST_PARAMETROS + sCierraParent + sAbreLlave + LST_CUERPO + sCierraLlave;
     */
    {
        public _METODO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;
            // println("llego al contructor");

            token tipo = getTipo();
            token nombre = getIdentificador();
            nodoModelo LST_CUERPO = getLST_CUERPO();
            token visbilidad=getVisibilidad(simbolo);
            int dimension = getDimensiones();
            elementoPolimorfo element = new elementoPolimorfo(visbilidad,tablaSimbolos, tipo, nombre, LST_CUERPO, dimension);

            cargarPolimorfismoHijos(element);
            simbolo.lstMetodo_funcion.insertarElemento(element);


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

        public nodoModelo getLST_CUERPO()
        {
            nodoModelo tempNodo = getNodo("LST_CUERPO");
            if (tempNodo != null)
                return tempNodo;
            else
                return new nodoModelo("---", tablaSimbolos);

        }
    }
}
