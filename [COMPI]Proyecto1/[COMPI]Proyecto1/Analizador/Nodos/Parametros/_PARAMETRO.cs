using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _PARAMETRO : nodoModelo
    /*
     * PARAMETRO.Rule = TIPO + VAR_ARREGLO;
     */
    {
        public _PARAMETRO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public override void cargarPolimorfismo(elementoPolimorfo elem)
        {


            if (hayErrores())
                return;

            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO temp = (_TIPO)tempNodo;
                nodoModelo temp2 = getNodo("VAR_ARREGLO");
                if (temp2 != null)
                {
                    _VAR_ARREGLO tempVar = (_VAR_ARREGLO)temp2;
                    elem.insertarParametro(tempVar.getIdentificador(), temp.getTipo(), tempVar.getDimensiones());
                }
            }
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FORMULARiO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public elementoPolimorfo getPolimorfo()
        {
            elementoPolimorfo retorno = null;

            if (hayErrores())
                return retorno;


            nodoModelo tempNodo = getNodo("TIPO");
            if (tempNodo != null)
            {
                _TIPO temp = (_TIPO)tempNodo;
                nodoModelo temp2 = getNodo("VAR_ARREGLO");
                if (temp2 != null)
                {
                    _VAR_ARREGLO tempVar = (_VAR_ARREGLO)temp2;

                    token visibilidad = new token("publico");
                    token tipo = temp.getTipo();
                    token nombre = tempVar.getIdentificador();
                    int dimensiones = tempVar.getDimensiones();
                    retorno = new elementoPolimorfo(visibilidad, tablaSimbolos, tipo, nombre, new _LST_CUERPO("LST_CUERPO", tablaSimbolos), dimensiones);
                    return retorno;
                }
            }
              
            return retorno;
        }

    }
}
