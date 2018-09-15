using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica
{
    class resta : opAritmetica
    {
        public resta(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }


        public itemValor opResta()
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor();
            itemValor val2 = hijo2.getValor();


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]opSuma Hijo1 es null", new token("--"));
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]opSuma Hijo1 es null", new token("--"));
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
                 *Booleano - Booleano = Booleano
                 */

                /*
                 *Booleano - Entero = Entero
                 */

                if (val1.isTypeBooleano() && val2.isTypeEntero())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;

                    retorno.setTypeEntero();
                    retorno.valor = entero1 - val2.getEntero();
                }



                /*
                 *Booleano - Decimal = Decimal
                 */

                else if (val1.isTypeBooleano() && val2.isTypeDecimal())
                {


                    Double entero1 = 0.0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1.0;
                    }
                    else
                        entero1 = 0.0;

                    retorno.setTypeDecimal();
                    retorno.valor = entero1 - val2.getDecimal();
                }


                /*
                 *Booleano + Cadena = Cadena
                 */
     

                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero - Booleano = Entero
                 */

                else if (val1.isTypeEntero() && val2.isTypeBooleano())
                {
                    int entero2 = 0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1;
                    }
                    else
                        entero2 = 0;

                    retorno.setTypeEntero();
                    retorno.valor = val1.getEntero() - entero2;
                }

                /*
                 *Entero - Entero = Entero
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    retorno.setTypeEntero();
                    retorno.valor = val1.getEntero() - val2.getEntero();
                }


                /*
                 *Entero - Decimal = Decimal
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {
                    retorno.setTypeDecimal();
                    retorno.valor = (Double)val1.getEntero() - val2.getDecimal();
                }

                /*
                 *Entero - Cadena = Cadena
                 */

         

                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena + Booleano = Cadena
                 */
 
                /*
                 *Cadena + Numerico = Cadena
                 */

            
                /*
                 *Cadena + Decimal = Cadena
                 */

               

                /*
                 *Cadena + Cadena = Cadena
                 */

                


                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal - Booleano = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeBooleano())
                {
                    Double entero2 = 0.0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1.0;
                    }
                    else
                        entero2 = 0.0;

                    retorno.setTypeDecimal();
                    retorno.valor = val1.getDecimal() - entero2;
                }

                /*
                 *Decimal - Numerico = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {

                    retorno.setTypeDecimal();
                    retorno.valor = val1.getDecimal() - (Double)val2.getEntero();
                }

                /*
                 *Decimal - Cadena = Cadena
                 */
 
                /*
                 *Decimal - Decimal = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {
                    retorno.setTypeDecimal();
                    retorno.valor = val1.getDecimal() - val2.getDecimal();
                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("No se pueden operar [RESTA] " + val1.getTipo() + " menos " + val2.getTipo(), signo);
                }

                 
                //aquí hay que parsear los objetos

            }
            catch (Exception e)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmeticaSuma]No se pudo efectuar la resta", signo);
            }

            return retorno;
        }

    }
}
