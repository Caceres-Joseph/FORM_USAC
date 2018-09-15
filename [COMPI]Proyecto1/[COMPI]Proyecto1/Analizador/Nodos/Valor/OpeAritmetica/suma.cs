using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica
{
    class suma : opAritmetica
    {
        public suma(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor opSuma()
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
                 *Booleano + Booleano = Booleano
                 */
                if (val1.isTypeBooleano() && val2.isTypeBooleano())
                {

                    retorno.setTypeBooleano();
                    retorno.valor = val1.getBooleano() || val2.getBooleano();
                }

                /*
                 *Booleano + Entero = Entero
                 */

                else if (val1.isTypeBooleano() && val2.isTypeEntero())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;

                    retorno.setTypeEntero();
                    retorno.valor = entero1 + val2.getEntero();
                }



                /*
                 *Booleano + Decimal = Decimal
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
                    retorno.valor = entero1 + val2.getDecimal();
                }


                /*
                 *Booleano + Cadena = Cadena
                 */
                else if (val1.isTypeBooleano() && val2.isTypeCadena())
                {

                    retorno.setTypeCadena();
                    retorno.valor = val1.getBooleano().ToString() + val2.getCadena();

                }


                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero + Booleano = Entero
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
                    retorno.valor = val1.getEntero() + entero2;
                }

                /*
                 *Entero + Entero = Entero
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    retorno.setTypeEntero();
                    retorno.valor = val1.getEntero() + val2.getEntero();
                }


                /*
                 *Entero + Decimal = Decimal
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {
                    retorno.setTypeDecimal();
                    retorno.valor = (Double)val1.getEntero() + val2.getDecimal();
                }

                /*
                 *Entero + Cadena = Cadena
                 */

                else if (val1.isTypeEntero() && val2.isTypeCadena())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getEntero().ToString() + val2.getCadena();
                }


                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena + Booleano = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeBooleano())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getCadena() + val2.getBooleano().ToString();
                }

                /*
                 *Cadena + Numerico = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeEntero())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getCadena() + val2.getEntero().ToString();
                }
                /*
                 *Cadena + Decimal = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeDecimal())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getCadena() + val2.getDecimal().ToString();
                }

                /*
                 *Cadena + Cadena = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeCadena())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getCadena() + val2.getCadena();
                }


                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal + Booleano = Decimal
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
                    retorno.valor = val1.getDecimal() + entero2;
                }

                /*
                 *Decimal + Numerico = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {

                    retorno.setTypeDecimal();
                    retorno.valor = val1.getDecimal() + (Double)val2.getEntero();
                }

                /*
                 *Decimal + Cadena = Cadena
                 */

                else if (val1.isTypeDecimal() && val2.isTypeCadena())
                {
                    retorno.setTypeCadena();
                    retorno.valor = val1.getDecimal().ToString() + val2.getCadena();
                }
                /*
                 *Decimal + Decimal = Decimal
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {
                    retorno.setTypeDecimal();
                    retorno.valor = val1.getDecimal() + val2.getDecimal();
                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("No se pueden operar [SUMA] " + val1.getTipo() + " con " + val2.getTipo(), signo);
                }




                //aquí hay que parsear los objetos

            }
            catch (Exception e)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmeticaSuma]No se pudo efectuar la suma", signo);
            }

            return retorno;
        }
    }
}
