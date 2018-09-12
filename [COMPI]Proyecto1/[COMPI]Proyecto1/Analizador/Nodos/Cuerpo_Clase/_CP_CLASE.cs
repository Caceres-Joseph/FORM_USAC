using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CP_CLASE : nodoModelo
    {
        public _CP_CLASE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }
          
         
        public Boolean getPrincipal()
        {
            Boolean retorno = false;
             
            foreach (nodoModelo hijo in hijos)
            {
                _CUERPO_CLASE cuerpo = (_CUERPO_CLASE)hijo;
                if (cuerpo.getPrincipal())
                    return true;
            }
            return retorno;

        }

    }
}
