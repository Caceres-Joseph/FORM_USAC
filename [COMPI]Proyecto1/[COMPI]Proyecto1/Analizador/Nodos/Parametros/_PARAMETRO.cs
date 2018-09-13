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

    }
}
