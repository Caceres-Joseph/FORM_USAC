using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _LST_PARAMETROS : nodoModelo
    /*
     *  LST_PARAMETROS.Rule = MakeStarRule(LST_PARAMETROS, sComa, PARAMETRO);
     */
    {
        public _LST_PARAMETROS(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | FORMULARiO
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public List<elementoPolimorfo> getParametros()
        {
            
            List<elementoPolimorfo> lstElementosPolimorfos = new List<elementoPolimorfo>();
            
            if (hayErrores())
                return lstElementosPolimorfos;

            foreach (_PARAMETRO param in hijos)
            {
                elementoPolimorfo temp = param.getPolimorfo();
                if (temp!=null)
                {
                    lstElementosPolimorfos.Add(temp);
                }
                else
                {
                    println("Formulario, vino un elemento polimorfo nulo prro");
                }
            }
            return lstElementosPolimorfos;
        }
    }
}
