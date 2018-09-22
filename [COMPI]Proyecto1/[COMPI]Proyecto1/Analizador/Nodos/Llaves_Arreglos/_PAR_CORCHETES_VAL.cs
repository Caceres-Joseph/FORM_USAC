using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;

namespace _COMPI_Proyecto1.Analizador.Nodos.Llaves_Arreglos
{
    class _PAR_CORCHETES_VAL : nodoModelo
    {
        public _PAR_CORCHETES_VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public itemValor getValor(elementoEntorno elementoEntor, token tipo)
        {
            itemValor retorno = new itemValor();

            if (hayErrores())
                return retorno;
            //println(hijos[0].nombre);

            nodoModelo temp = getNodo("E");
            if (temp != null)
            /*
            |---------------------------- 
            | PAR_CORCHETES_VAL.Rule = sAbreCorchete + E + sCierraCorchete; 
            */
            {
                _E ret = (_E)temp;
                // ret.getValor(elementoEntor).imprimirVariable();

                ///return ret.getValor(elementoEntor);
                itemValor temporal = ret.getValor(elementoEntor);
                if (temporal.dimensiones.Count > 0)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("El lenguaje no soporta variables, o nuevos arreglos anidados de una forma diferente de {{E,E},{E,E}}: Error en matriz", tipo);
                    return retorno;
                }
                else
                {
                    //temporal.imprimirVariable();
                    return temporal;
                }

            }

            return retorno;
        }

        #region getValorAnterio
        /*
        public itemValor getValor(elementoEntorno elementoEntor, token tipo)
        {
            itemValor retorno = new itemValor();

            if (hayErrores())
                return retorno;

            nodoModelo temp = getNodo("E");
            if (temp!=null)
            {
                _E ret = (_E)temp;
                // ret.getValor(elementoEntor).imprimirVariable();

                itemValor temporal = ret.getValor(elementoEntor);


                if (temporal.dimensiones.Count>0) 
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("El lenguaje no soporta variables, o nuevos arreglos anidados de una forma diferente de {{E,E},{E,E}}: Error en matriz" , tipo);
                    return retorno;
                }
                else
                {
                    return temporal;
                }
                
            }
            
            return retorno;
        }*/
        #endregion
    }
}
