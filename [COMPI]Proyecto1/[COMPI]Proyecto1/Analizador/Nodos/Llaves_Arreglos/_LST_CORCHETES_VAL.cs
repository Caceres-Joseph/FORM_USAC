using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Llaves_Arreglos;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _LST_CORCHETES_VAL : nodoModelo
    {
        public _LST_CORCHETES_VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public List<int> getLstInt(elementoEntorno tablaEntor, token nombreVar)
        {
            List<int> retorno = new List<int>();


            foreach( nodoModelo temp in hijos)
            {

                
                //tiene que ser de dimensión cero prro

                if (hayErrores())
                    return retorno;

                _PAR_CORCHETES_VAL par = (_PAR_CORCHETES_VAL)temp;
                itemValor te=  par.getValor(tablaEntor, nombreVar);

                 
                
                if (te.isTypeBooleano())
                {
                    if (te.getBooleano())
                        retorno.Add(1);
                    else
                        retorno.Add(0);
                }
                else if(te.isTypeDecimal())
                {
                    int valor = Convert.ToInt32(te.getDecimal());

                    if (valor>=0)
                    {
                        retorno.Add(valor);
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede crear una matriz con tamaño negativo",nombreVar);
                        return retorno;
                    }
                    
                    
                }
                else if (te.isTypeEntero())
                {
                    if (te.getEntero() >= 0)
                    {
                       // println("Agreando:" + te.getEntero());
                        retorno.Add(te.getEntero());
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede crear una matriz con tamaño negativo", nombreVar);
                        return retorno;
                    }
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede crear una matriz con tamaño de tipo : "+te.getTipo(), nombreVar);
                    return retorno;

                }
            }

            return retorno;
        }
    }
}
