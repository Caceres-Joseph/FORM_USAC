using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica
{
    class negativo : opModelo
    {
        public negativo(nodoModelo hijo1, tablaSimbolos tabla, token signo) : base(hijo1, tabla, signo)
        {
        }


        public itemValor opNot(String ambito)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor();


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opLogica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            }
            try
            {

                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero 
                 */

                if (val1.isTypeEntero())
                {


                    int val1R = (-1) * val1.getEntero();

                    retorno.setValue(val1R);
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
                    double val1R = (-1)*val1.getDecimal();
                   
                    retorno.setValue(val1R);
                    return retorno;
                }

                else
                {
                    tabla.tablaErrores.insertErrorSemantic("No se pueden operar [" + ambito + "] " + val1.getTipo(), signo);
                }
            }
            catch (Exception)
            {
                tabla.tablaErrores.insertErrorSemantic("[OpAritemetica]No se pudo efectuar [" + ambito + " ]", signo);
            }

            return retorno;
        }
    }
}
