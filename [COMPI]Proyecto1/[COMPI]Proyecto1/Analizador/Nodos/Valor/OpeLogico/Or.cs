using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeLogico
{
    class Or : opModelo
    {
        public Or(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }


        public itemValor opOr(String ambito)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor();
            itemValor val2 = hijo2.getValor();


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opLogica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opLogica]" + ambito + " Hijo1 es null", new token("--"));
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
                 *Booleano * Booleano = Booleano
                 */
                if (val1.isTypeBooleano() && val2.isTypeBooleano())
                {



                    retorno.setValue(val1.getBooleano() || val2.getBooleano());
                    return retorno;
                }

                /*
                 *Booleano * Entero = Entero
                 */

                else if (val1.isTypeBooleano() && val2.isTypeEntero())
                {


                    Boolean bool2 = false;
                    int val2R = val2.getEntero();
                    if (val2R == 0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El numero " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(val1.getBooleano() || bool2);
                    return retorno;
                }

                /*
                 *Booleano * Decimal = Decimal
                 */

                else if (val1.isTypeBooleano() && val2.isTypeDecimal())
                {


                    Boolean bool2 = false;
                    Double val2R = val2.getDecimal();
                    if (val2R == 0.0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1.0)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(val1.getBooleano() || bool2);
                    return retorno;
                }


                /*
                 *Booleano * Cadena = Cadena
                 */



                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero * Booleano = Entero
                 */

                else if (val1.isTypeEntero() && val2.isTypeBooleano())
                {

                    Boolean bool1 = false;
                    int val1R = val1.getEntero();
                    if (val1R == 0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || val2.getBooleano());
                    return retorno;
                }

                /*
                 *Entero * Entero = Entero
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    Boolean bool1 = false;
                    int val1R = val1.getEntero();
                    if (val1R == 0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    Boolean bool2 = false;
                    int val2R = val2.getEntero();


                    if (val2R == 0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || bool2);
                    return retorno;
                }


                /*
                 *Entero * Decimal = Decimal
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {

                    Boolean bool1 = false;
                    int val1R = val1.getEntero();
                    if (val1R == 0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    Boolean bool2 = false;
                    Double val2R = val2.getDecimal();


                    if (val2R == 0.0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1.0)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || bool2);
                    return retorno;
                }

                /*
                 *Entero * Cadena = Cadena
                 */



                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena * Booleano = Cadena
                 */



                /*
                 *Cadena * Numerico = Cadena
                 */


                /*
                 *Cadena * Decimal = Cadena
                 */


                /*
                 *Cadena * Cadena = Cadena
                 */


                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal * Booleano = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeBooleano())
                {
                    Boolean bool1 = false;
                    double val1R = val1.getDecimal();
                    if (val1R == 0.0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1.0)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || val2.getBooleano());
                    return retorno;
                }

                /*
                 *Decimal * Numerico = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {


                    Boolean bool1 = false;
                    double val1R = val1.getDecimal();
                    if (val1R == 0.0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1.0)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    Boolean bool2 = false;
                    int val2R = val2.getEntero();


                    if (val2R == 0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El entero: " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || bool2);
                    return retorno;
                }

                /*
                 *Decimal * Cadena = Cadena
                 */

                /*
                 *Decimal * Decimal = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {

                    Boolean bool1 = false;
                    double val1R = val1.getDecimal();
                    if (val1R == 0.0)
                    {
                        bool1 = false;

                    }
                    else if (val1R == 1.0)
                    {
                        bool1 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val1R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }



                    Boolean bool2 = false;
                    Double val2R = val2.getDecimal();


                    if (val2R == 0.0)
                    {
                        bool2 = false;

                    }
                    else if (val2R == 1.0)
                    {
                        bool2 = true;
                    }
                    else
                    {
                        tabla.tablaErrores.insertErrorSemantic("El decimal: " + val2R + " no se puede parsear a un valor booleano", signo);
                        return retorno;
                    }

                    retorno.setValue(bool1 || bool2);
                    return retorno;

                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("No se pueden operar [" + ambito + "] " + val1.getTipo() + " con " + val2.getTipo(), signo);
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
