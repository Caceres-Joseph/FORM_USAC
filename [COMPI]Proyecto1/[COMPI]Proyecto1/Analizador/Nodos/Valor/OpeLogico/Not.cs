using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeLogico
{
    class Not : opModelo
    {
        public Not(nodoModelo hijo1, tablaSimbolos tabla, token signo) : base(hijo1, tabla, signo)
        {
        }


        public itemValor opNot(String ambito, elementoEntorno elem)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor(elem); 


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opLogica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            } 
            try
            {
                /*
                |--------------------------------------------------------------------------
                | Booleano
                |--------------------------------------------------------------------------
                */
                /*
                 *Booleano  
                 */
                if (val1.isTypeBooleano())
                {

                    
                    retorno.setValue(!val1.getBooleano());
                    return retorno;
                }

                 
                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero 
                 */

                else if (val1.isTypeEntero())
                {

                    int bool1 = 0;
                    int val1R = val1.getEntero();
                    if (val1R == 0)
                    {
                        bool1 = 1;

                    }
                    else if (val1R == 1)
                    {
                        bool1 = 0;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1);
                    return retorno;
                } 

                 


                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal 
                 */

                else if (val1.isTypeDecimal())
                {
                    double bool1 = 0.0;
                    double val1R = val1.getDecimal();
                    if (val1R == 0.0)
                    {
                        bool1 = 1.0;

                    }
                    else if (val1R == 1.0)
                    {
                        bool1 = 0.0;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1);
                    return retorno;
                }
                 
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("No se pueden operar [" + ambito + "] " + val1.getTipo() , signo);
                }
            }
            catch (Exception)
            {
                tabla.tablaErrores.insertErrorSemantic("[opLogica]No se pudo efectuar [" + ambito + " ]", signo);
            }

            return retorno;
        }
    }
}
