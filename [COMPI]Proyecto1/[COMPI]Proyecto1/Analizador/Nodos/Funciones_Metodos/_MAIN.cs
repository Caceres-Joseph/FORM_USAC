using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _MAIN : nodoModelo
    {
        public _MAIN(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        
        public override void ejecutar(elementoClase simbolo)
        {

            if (hayErrores())
                return;

            token tipo = new token("vacio");
            token nombre = new token("principal");
            nodoModelo LST_CUERPO= getLST_CUERPO();

            elementoPolimorfo element = new elementoPolimorfo(new token("publico"),tablaSimbolos, tipo, nombre, LST_CUERPO,0);
             
            simbolo.lstPrincipal.insertarElemento(element);
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
