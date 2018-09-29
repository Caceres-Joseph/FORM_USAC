using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.Operelacional
{
    class IgualQue : opModelo
    {
        public IgualQue(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor opIgualacion(String ambito, elementoEntorno elem)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor(elem);
            itemValor val2 = hijo2.getValor(elem);


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + " Hijo1 es null", new token("--"));
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
                 *Booleano == Booleano 
                 */
                if (val1.isTypeBooleano() && val2.isTypeBooleano())
                {

                    if (val1.getBooleano() == val2.getBooleano())
                    {
                        retorno.setValue(true);
                    }
                    else
                    {
                        retorno.setValue(false);
                    }
                    return retorno;
                }

                /*
                 *Booleano == Entero 
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


                    if (entero1 == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }



                /*
                 *Booleano == Decimal 
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

                    if (entero1 == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                 *Booleano == Cadena  
                 */

                else if (val1.isTypeBooleano() && val2.isTypeCadena())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;

                    if (entero1 == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero == Booleano  
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

                    if (val1.getEntero() == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }

                /*
                 *Entero == Entero  
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    if (val1.getEntero() == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                 *Entero == Decimal  
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {


                    Double num2 = val2.getDecimal();


                    int valInt2 = (int)Math.Truncate(num2);

                    if (val1.getEntero() == valInt2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Entero == Cadena 
                 * 
                 */

                else if (val1.isTypeEntero() && val2.isTypeCadena())
                {

                    if (val1.getEntero() == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena * Booleano = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeBooleano())
                {
                    int entero2 = 0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1;
                    }
                    else
                        entero2 = 0;

                    if (val1.getCadena().Length == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena == Numerico 
                 */


                else if (val1.isTypeCadena() && val2.isTypeEntero())
                {


                    if (val1.getCadena().Length == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }
                /*
                 *Cadena == Decimal  
                 */

                else if (val1.isTypeCadena() && val2.isTypeDecimal())
                {

                    if (val1.getCadena().Length == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena == Cadena 
                 */
                else if (val1.isTypeCadena() && val2.isTypeCadena())
                {

                    if (val1.getCadena().Equals(val2.getCadena()))
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal == Booleano 
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

                    if (val1.getDecimal() == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;

                }

                /*
                 *Decimal == Numerico 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {
                    int valInt1 = (int)Math.Truncate(val1.getDecimal());

                    if (valInt1 == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal == Cadena 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeCadena())
                {
                    if (val1.getDecimal() == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal == Decimal 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {
                    if (val1.getDecimal() == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Comparando tipo date
                |--------------------------------------------------------------------------
                */
                /*
                 *FechaHora == Fecha 
                 */

                else if ((val1.isTypeFechaHora() || val1.isTypeFecha() || val1.isTypeHora()) && (val2.isTypeFechaHora() || val2.isTypeFecha() || val2.isTypeHora()))
                {
                    if (val1.getFechaHora() == val2.getFechaHora())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Nulos
                |--------------------------------------------------------------------------
                */

                else if (val1.isTypeNulo() && val2.isTypeNulo())
                {
                    retorno.setValue(true);



                    println("Si se recoocieron los tipos");
                    println("val1->" + val1.getTipo());
                    println("val2->" + val2.getTipo());

                    return retorno;
                }

                else
                {


                    if (val1.valor.Equals(val2.valor))
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;

                    //tabla.tablaErrores.insertErrorSemantic("No se pueden operar [" + ambito + "] " + val1.getTipo() + " con " + val2.getTipo(), signo);
                }
            }
            catch (Exception)
            {
                tabla.tablaErrores.insertErrorSemantic("[opRelacional]No se pudo efectuar [" + ambito + " ]", signo);
            }

            return retorno;
        }

        public itemValor opIgualacion22(String ambito, elementoEntorno elem)
        {
            itemValor retorno = new itemValor();
            itemValor val1 = hijo1.getValor(elem);
            itemValor val2 = hijo2.getValor(elem);


            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + " Hijo1 es null", new token("--"));
                return retorno;
            }




            /*
            |--------------------------------------------------------------------------
            | Booleano
            |--------------------------------------------------------------------------
            */
            /*
             *Booleano + Booleano = Booleano
             
            if (val1.isTypeBooleano() && val2.isTypeBooleano())
            {
                tabla.tablaErrores.insertErrorSemantic("No se pueden comparar valores booleanos  [" + ambito + "] " + val1.getTipo() + " == " + val2.getTipo(), signo);


                return retorno;
            }*/


            /*
             *Decimal + Numerico = Decimal
            */

            else if (val1.isTypeDecimal() && val2.isTypeEntero())
            {
                Double num1 = val1.getDecimal();


                int valInt1 = (int)Math.Truncate(num1);

                if (valInt1.Equals(val2.getEntero()))
                    retorno.setValue(true);
                else
                    retorno.setValue(false);
                return retorno;
            }

            /*
             *Entero + Decimal = Decimal
             */

            else if (val1.isTypeEntero() && val2.isTypeDecimal())
            {
                Double num2 = val2.getDecimal();


                int valInt2 = (int)Math.Truncate(num2);

                if (valInt2.Equals(val1.getEntero()))
                    retorno.setValue(true);
                else
                    retorno.setValue(false);
                return retorno;

            }
            else
            {

                if (val1.valor.Equals(val2.valor))
                    retorno.setValue(true);
                else
                    retorno.setValue(false);
                return retorno;
            }
        }




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */



        public itemValor opIgualacion(itemValor val1, itemValor val2, String ambito, elementoEntorno elem)
        {
            itemValor retorno = new itemValor();



            if (val1 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + "Hijo1 es null", new token("--"));
                return retorno;
            }
            if (val2 == null)
            {
                tabla.tablaErrores.insertErrorSemantic("[opAritmetica]" + ambito + " Hijo1 es null", new token("--"));
                return retorno;
            }


            println("----al principio---");
            println("val1->" + val1.getTipo());
            println("val2->" + val2.getTipo());


            try
            {
                /*
                |--------------------------------------------------------------------------
                | Booleano
                |--------------------------------------------------------------------------
                */
                /*
                 *Booleano == Booleano 
                 */
                if (val1.isTypeBooleano() && val2.isTypeBooleano())
                {

                    if (val1.getBooleano() == val2.getBooleano())
                    {
                        retorno.setValue(true);
                    }
                    else
                    {
                        retorno.setValue(false);
                    }
                    return retorno;
                }

                /*
                 *Booleano == Entero 
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


                    if (entero1 == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }



                /*
                 *Booleano == Decimal 
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

                    if (entero1 == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                 *Booleano == Cadena  
                 */

                else if (val1.isTypeBooleano() && val2.isTypeCadena())
                {


                    int entero1 = 0;
                    if (val1.getBooleano())
                    {
                        entero1 = 1;
                    }
                    else
                        entero1 = 0;

                    if (entero1 == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Entero
                |--------------------------------------------------------------------------
                */
                /*
                 *Entero == Booleano  
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

                    if (val1.getEntero() == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);

                    return retorno;
                }

                /*
                 *Entero == Entero  
                 */

                else if (val1.isTypeEntero() && val2.isTypeEntero())
                {
                    if (val1.getEntero() == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                 *Entero == Decimal  
                 */

                else if (val1.isTypeEntero() && val2.isTypeDecimal())
                {


                    Double num2 = val2.getDecimal();


                    int valInt2 = (int)Math.Truncate(num2);

                    if (val1.getEntero() == valInt2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Entero == Cadena 
                 * 
                 */

                else if (val1.isTypeEntero() && val2.isTypeCadena())
                {

                    if (val1.getEntero() == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Cadena
                |--------------------------------------------------------------------------
                */

                /*
                 *Cadena * Booleano = Cadena
                 */

                else if (val1.isTypeCadena() && val2.isTypeBooleano())
                {
                    int entero2 = 0;
                    if (val2.getBooleano())
                    {
                        entero2 = 1;
                    }
                    else
                        entero2 = 0;

                    if (val1.getCadena().Length == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena == Numerico 
                 */


                else if (val1.isTypeCadena() && val2.isTypeEntero())
                {


                    if (val1.getCadena().Length == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }
                /*
                 *Cadena == Decimal  
                 */

                else if (val1.isTypeCadena() && val2.isTypeDecimal())
                {

                    if (val1.getCadena().Length == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Cadena == Cadena 
                 */
                else if (val1.isTypeCadena() && val2.isTypeCadena())
                {

                    if (val1.getCadena().Equals(val2.getCadena()))
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                |--------------------------------------------------------------------------
                | Decimal
                |--------------------------------------------------------------------------
                */
                /*
                 *Decimal == Booleano 
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

                    if (val1.getDecimal() == entero2)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;

                }

                /*
                 *Decimal == Numerico 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeEntero())
                {
                    int valInt1 = (int)Math.Truncate(val1.getDecimal());

                    if (valInt1 == val2.getEntero())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal == Cadena 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeCadena())
                {
                    if (val1.getDecimal() == val2.getCadena().Length)
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }

                /*
                 *Decimal == Decimal 
                 */

                else if (val1.isTypeDecimal() && val2.isTypeDecimal())
                {
                    if (val1.getDecimal() == val2.getDecimal())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | Comparando tipo date
                |--------------------------------------------------------------------------
                */
                /*
                 *FechaHora == Fecha 
                 */

                else if ((val1.isTypeFechaHora() || val1.isTypeFecha() || val1.isTypeHora()) && (val2.isTypeFechaHora() || val2.isTypeFecha() || val2.isTypeHora()))
                {
                    if (val1.getFechaHora() == val2.getFechaHora())
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;
                }


                /*
                |--------------------------------------------------------------------------
                | NULO
                |--------------------------------------------------------------------------
                */
                /*
                 *Nulo == Nulo 
                 */


                else if (val1.isTypeNulo() && val2.isTypeNulo())
                { 
                    retorno.setValue(true); 
                    


                    println("Si se recoocieron los tipos");
                    println("val1->" + val1.getTipo());
                    println("val2->" + val2.getTipo());

                    return retorno;
                }

                else
                {

                    println("No se recoocieron los tipos");
                    println("val1->" + val1.getTipo());
                    println("val2->" + val2.getTipo());

                    if (val1.valor.Equals(val2.valor))
                        retorno.setValue(true);
                    else
                        retorno.setValue(false);
                    return retorno;

                    //tabla.tablaErrores.insertErrorSemantic("No se pueden operar [" + ambito + "] " + val1.getTipo() + " con " + val2.getTipo(), signo);
                }
            }
            catch (Exception)
            {
                tabla.tablaErrores.insertErrorSemantic("[opRelacional]No se pudo efectuar [" + ambito + " ]", signo);
            }

            return retorno;
        }

        public void println(String mensaje)
        {
           // Console.WriteLine("[igualQue]" + mensaje);
        }


    }
}
