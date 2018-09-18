using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemValor
    {
        /*
        |--------------------------------------------------------------------------
        | Tipos que soporta el lenguaje
        |--------------------------------------------------------------------------
        | cadena
        | booleano
        | entero
        | decimal
        | fecha
        | fechahora
        | hora
        | nulo
        | objeto
        | vacio
        */


        string tipo;
        public string tipo2 = "";
        public Object valor;
        public int dimension = 0;
        public String nombreObjeto = "";

        public itemValor()
        {
            this.tipo = "nulo";
            setTypeNulo();
            dimension = 0;
            this.valor = new object();
        }




        public void convertirCadena(String cadena)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            //parseando a fecha/hora
            //parseando a fecha
            //paresando a hora
            try
            {
                this.tipo = "fechahora";
                //DateTime oDate = DateTime.ParseExact(cadena, "dd/MM/yyyy hh:mm:ss ", System.Globalization.CultureInfo.InvariantCulture);

                DateTime oDate = DateTime.ParseExact(cadena, "dd/MM/yyyy hh:mm:ss", enUS, DateTimeStyles.None);

                this.valor = oDate;
            }
            catch (FormatException e)
            {
                //  Console.WriteLine("[itemValor]No es fechaHora"+e);
                try
                {
                    this.tipo = "fecha";
                    DateTime oDate = DateTime.ParseExact(cadena, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    this.valor = oDate;
                }
                catch (FormatException e2)
                {
                    //  Console.WriteLine("[itemValor]No es fecha" + e2);
                    try
                    {
                        this.tipo = "hora";
                        DateTime oDate = DateTime.ParseExact(cadena, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        this.valor = oDate;
                    }
                    catch (FormatException e3)
                    {
                        // Console.WriteLine("[itemValor]No es hora" + e3);
                        this.tipo = "cadena";
                        this.valor = cadena;
                    }
                }
                //de ultimo es un string alv 
            }
        }



        public void convertirCadena2(String cadena)
        {
            cadena = cadena.Replace("‘", "");
            cadena = cadena.Replace("‘", "’");
            convertirCadena(cadena);
            //parseando a fecha/hora
            //parseando a fecha
        }

        /*
        |--------------------------------------------------------------------------
        | Obteniendo los tipos
        |--------------------------------------------------------------------------
        | cadena
        | booleano
        | entero
        | decimal
        | fecha
        | fechahora
        | hora
        | nulo
        | objeto
        | vacio
        */
        public Boolean getBooleano()
        {
            try
            {
                return (Boolean)valor;
            }
            catch (FormatException e)
            {
                Console.WriteLine("[itemValor]getBooleano_No se puede parser el booleano");
                return false;
            }
        }


        public int getEntero()
        {

            try
            {
                return (int)valor;
            }
            catch (FormatException e)
            {
                Console.WriteLine("[itemValor]getEntero_No se puede parser el booleano");
                return 0;
            }
        }

        public double getDecimal()
        {
            try
            {
                return (Double)valor;
            }
            catch (FormatException e)
            {
                Console.WriteLine("[itemValor]getDecimal_No se puede parser el booleano");
                return 0.0;
            }
        }
        public DateTime getFechaHora()
        {

            try
            {
                return (DateTime)valor;
            }
            catch (FormatException e)
            {
                Console.WriteLine("[itemValor]getFechaHora_No se puede parser el booleano");
                return new DateTime();
            }
        }

        public String getCadena()
        {

            try
            {
                return valor.ToString();
            }
            catch (FormatException e)
            {
                Console.WriteLine("[itemValor]getString_No se puede parser el booleano");
                return "";
            }
        }


        /*
        |--------------------------------------------------------------------------
        | Imprimiendo la variable
        |--------------------------------------------------------------------------
        */



        public void imprimirVariable()
        {
            if (isTypeCadena())
            {

                println(getCadena());
            }
            else if (isTypeBooleano())
            {
                println(getBooleano());
            }
            else if (isTypeEntero())
            {
                println(getEntero());
            }
            else if (isTypeDecimal())
            {
                println(getDecimal());
            }
            else if (isTypeFecha())
            {
                println(getFechaHora());
            }
            else if (isTypeFechaHora())
            {
                println(getFechaHora());
            }
            else if (isTypeHora())
            {
                println(getFechaHora());
            }
            else if (isTypeNulo())
            {
                println("nulo");
            }
            else if (isTypeObjeto())
            {
                println("objeto");
            }
            else if (isTypeVacio())
            {
                println("vacio");
            }
            else
            {
                println("no se reconoce el tipo:" + tipo);
            }
        }


        /*
        |--------------------------------------------------------------------------
        | Enviando el tipo
        |--------------------------------------------------------------------------
        */
        public void setTypeCadena()
        {
            this.tipo = "cadena";
        }
        public void setTypeBooleano()
        {
            this.tipo = "booleano";
        }
        public void setTypeEntero()
        {
            this.tipo = "entero";
        }
        public void setTypeDecimal()
        {
            this.tipo = "decimal";
        }
        public void setTypeFecha()
        {
            this.tipo = "fecha";
        }
        public void setTypeFechaHora()
        {
            this.tipo = "fechahora";
        }
        public void setTypeHora()
        {
            this.tipo = "hora";
        }
        public void setTypeNulo()
        {
            this.tipo = "nulo";
        }
        public void setTypeObjeto()
        {
            this.tipo = "objeto";
        }

        public void setTypeVacio()
        {
            this.tipo = "vacio";
        }
        /*
      |--------------------------------------------------------------------------
      | Set Value
      |--------------------------------------------------------------------------
      */
        public void setValue(String cadena)
        {
            this.tipo = "cadena";
            this.valor = cadena;
        }
        public void setValue(Boolean valor)
        {
            this.tipo = "booleano";
            this.valor = valor;
        }
        public void setValue(int entrada)
        {
            this.tipo = "entero";
            this.valor = entrada;
        }
        public void setValue(double entrada)
        {
            this.tipo = "decimal";
            this.valor = entrada;
        }
        public void setValueFecha(DateTime fecha)
        {
            this.tipo = "fecha";
            this.valor = fecha;
        }
        public void setValueFechaHora(DateTime fecha)
        {
            this.tipo = "fechahora";
            this.valor = fecha;
        }
        public void setValueHora(DateTime hora)
        {
            this.tipo = "hora";
            this.valor = hora;
        }
        public void setValueNulo()
        {
            this.tipo = "nulo";
        }
        public void setValue(Object o, String nombreObjeto)
        {
            this.tipo = "objeto";
            this.nombreObjeto = nombreObjeto;
            this.valor = o;
        }





        /*
        |--------------------------------------------------------------------------
        | Validando el tipo
        |--------------------------------------------------------------------------
        */
        public Boolean isTypeCadena()
        {
            if (this.tipo.Equals("cadena"))
                return true;
            else
                return false;
        }
        public Boolean isTypeBooleano()
        {
            if (this.tipo.Equals("booleano"))
                return true;
            else
                return false;
        }
        public Boolean isTypeEntero()
        {
            if (this.tipo.Equals("entero"))
                return true;
            else
                return false;
        }
        public Boolean isTypeDecimal()
        {
            if (this.tipo.Equals("decimal"))
                return true;
            else
                return false;
        }
        public Boolean isTypeFecha()
        {
            if (this.tipo.Equals("fecha"))
                return true;
            else
                return false;
        }
        public Boolean isTypeFechaHora()
        {
            if (this.tipo.Equals("fechahora"))
                return true;
            else
                return false;
        }
        public Boolean isTypeHora()
        {
            if (this.tipo.Equals("hora"))
                return true;
            else
                return false;
        }
        public Boolean isTypeNulo()
        {
            if (this.tipo.Equals("nulo"))
                return true;
            else
                return false;
        }
        public Boolean isTypeObjeto()
        {
            if (this.tipo.Equals("objeto"))
                return true;
            else
                return false;
        }
        public Boolean isTypeVacio()
        {
            if (this.tipo.Equals("vacio"))
                return true;
            else
                return false;
        }



        /*
        |--------------------------------------------------------------------------
        | Get Type
        |--------------------------------------------------------------------------
        */

        public String getTipo()
        {
            return tipo;
        }


        public void println(Object ob)
        {
            Console.WriteLine("\t\t[itemValor]" + tipo + "->" + ob.ToString());

        }
    }
}
