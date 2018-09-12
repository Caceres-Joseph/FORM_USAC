using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CUERPO_CLASE : nodoModelo
    {
        public _CUERPO_CLASE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public Boolean getPrincipal()
        {
            Boolean retorno = false;

            //tengo que revisar si dentro de los hijos se encuentra el metodo principa jejeje

            nodoModelo temp = getNodo("MAIN");
            if (temp!=null) 
                return true; 

            return retorno;

        }

    }
}
