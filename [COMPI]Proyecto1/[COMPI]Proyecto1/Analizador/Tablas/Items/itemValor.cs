using _COMPI_Proyecto1.Analizador.Tablas.Objetos;
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
       // public string tipo2 = "";
        public Object valor;
        public List<int> dimensiones;
        public String nombreObjeto = "";
        public Dictionary<int, itemValor> arrayValores = new Dictionary<int, itemValor>();


        //esto sirve para el tipo del metodo/funcion
        public token tipoFuncionMetodo = new token();

        //esto sirve para el nombre de la pregunta
        public token nombrePregunta = new token();

     


        public itemValor()
        {
            tipoFuncionMetodo = new token("vacio");
            this.tipo = "nulo";
            setTypeNulo();
            dimensiones = new List<int>();
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
            catch (Exception e)
            {
                //  Console.WriteLine("[itemValor]No es fechaHora"+e);
                try
                {
                    this.tipo = "fecha";
                    DateTime oDate = DateTime.ParseExact(cadena, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    this.valor = oDate;
                }
                catch (Exception e2)
                {
                    //  Console.WriteLine("[itemValor]No es fecha" + e2);
                    try
                    {
                        this.tipo = "hora";
                        DateTime oDate = DateTime.ParseExact(cadena, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        this.valor = oDate;
                    }
                    catch (Exception e3)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getEntero_No se puede parser el getEntero");
                return 0;
            }
        }

        public double getDecimal()
        {
            try
            {
                return (Double)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getDecimal_No se puede parser el getDecimal");
                return 0.0;
            }
        }
        public DateTime getFechaHora()
        {

            try
            {
                return (DateTime)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getFechaHora_No se puede parser el DateTime");
                return new DateTime();
            }
        }

        public String getCadena()
        {

            try
            {
                return valor.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getString_No se puede parser el getCadena");
                return "";
            }
        }

        public objetoClase getObjeto()
        {

            try
            {
                return (objetoClase)valor;
            }
            catch (Exception e)
            {
                Console.WriteLine("[itemValor]getObjeto_No se puede parser a objetoClase");
                return null;
            }
        }


        /*
        |--------------------------------------------------------------------------
        | Imprimiendo la variable
        |--------------------------------------------------------------------------
        */


        public void imprimirVariable()
        {

            imprimirVariable2();
            int i = 0;
            foreach(int inte in dimensiones)
            {
                println("dimen" + i +": "+inte);
                i++;
            }


        }

        public void imprimirVariable2()
        {



            if (arrayValores.Count > 0)
            {
                /* foreach(int dim in dimensiones)
                 {
                     println("dimension: " + dim);
                 }*/


                foreach (var tem in arrayValores)
                {
                    println("[" + tem.Key + "] :");
                    tem.Value.imprimirVariable();
                }
            }
            else
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
                    println("objeto."+nombreObjeto);

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
        }




        /*
        |--------------------------------------------------------------------------
        | Obtiene un tipo de valor en especifico
        |--------------------------------------------------------------------------
        */



        public object getValorParseado(String tipo)
        {

            switch (tipo)
            {
                case "cadena":
                    return getCadena(); 

                case "booleano":
                    if (isTypeBooleano())
                    {
                        return getBooleano();
                    }
                    else if (isTypeEntero())
                    {
                        int entero = getEntero();
                        if (entero == 0)
                        {
                            return false;
                        }
                        else if (entero == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return null;
                        }

                    }else if (isTypeCadena())
                    {
                        if (getCadena().ToLower().Equals("vardadero")|| getCadena().ToLower().Equals("true"))
                        {
                            return true;
                        }else if (getCadena().ToLower().Equals("falso") || getCadena().ToLower().Equals("false"))
                        {
                            return false;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                case "entero":

                    
                    if (isTypeEntero())
                    {
                        return getEntero();
                    }
                    else if (isTypeBooleano())
                    {
                        if (getBooleano())
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (isTypeDecimal())
                    {
                        return Convert.ToInt32(getDecimal());
                    }
                    else if (isTypeFechaHora()||isTypeFecha()||isTypeHora())
                    {


                        int ret= unchecked((int)getFechaHora().Ticks);
                        return ret;
                    }
                    else
                    {
                        try
                        {
                            int el = Convert.ToInt32(valor);
                            return el;
                        }
                        catch (Exception e)
                        {
                            println("error al parsear a entrero"+e.ToString());
                            return null;
                        }
                    }

                case "decimal":
                    if (isTypeDecimal())
                    {
                        return getDecimal();
                    }
                    else if (isTypeEntero())
                    {
                        return Convert.ToDouble(getEntero());
                    }
                    else if (isTypeBooleano())
                    {
                        if (getBooleano())
                        {
                            return 1.0;
                        }
                        else
                        {
                            return 0.0;
                        }
                    }
                    else
                    {
                        return null;
                    }

                case "fecha":
                    if (isTypeFecha())
                    {
                        return getFechaHora();
                    }
                    else
                    {
                        return null;
                    }

                case "fechahora":
                    if (isTypeFechaHora())
                    {
                        return getFechaHora();
                    }
                    else
                    {
                        return null;
                    }

                case "hora":
                    if (isTypeHora())
                    {
                        return getFechaHora();
                    }
                    else
                    {
                        return null;
                    }

                case "nulo":
                    //tengo que validar el tipo antes prro
                    return null;
                /*case "objeto":


                    setTypeObjeto();
                    break;*/
                default:
                    if (this.nombreObjeto == tipo)
                    {
                        return valor;
                    }
                    else
                    {
                        return null;
                    }
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
        public void setTypeObjeto(String nombreObjeto)
        {
            this.tipo = "objeto";
            this.nombreObjeto = nombreObjeto;
        }

        public void setTypeVacio()
        {
            this.tipo = "vacio";
        }


        public void setArrayTipo(List<int> dimensiones, Dictionary<int, itemValor> arrayItems, String tipo)
        {
            this.dimensiones = dimensiones;
            this.arrayValores = arrayItems;
            this.setType(tipo);
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
      | getTipoApartirDeString
      |--------------------------------------------------------------------------
      */

        public String getTipoApartirDeString(String tipo)
        {



            if (tipo.Equals("entero"))
            {
                return tipo;
            }
            else if (tipo.Equals("cadena"))
            {
                return tipo;
            }
            else if (tipo.Equals("decimal"))
            {
                return tipo;
            }
            else if (tipo.Equals("booleano"))
            {
                return tipo;
            }
            else if (tipo.Equals("fecha"))
            {
                return tipo;
            }
            else if (tipo.Equals("hora"))
            {
                return tipo;
            }
            else if (tipo.Equals("fechahora"))
            {
                return tipo;
            }
            else if (tipo.Equals("pregunta"))
            {

                return tipo;
            }
            else if (tipo.Equals("formulario"))
            {
                return tipo;
            }
            else if (tipo.Equals("respuesta"))
            {
                return tipo;
            }
            else if (tipo.Equals("vacio"))
            {
                return tipo;
            }
            else if (tipo.Equals("nulo"))
            {
                return tipo;
            }
            else
            {
                return "objeto";
            }

        }


        /*
      |--------------------------------------------------------------------------
      | Set Value
      |--------------------------------------------------------------------------
      */
        public void setType(String cadena)
        {
            switch (cadena)
            {
                case "cadena":
                    setTypeCadena();
                    break;
                case "booleano":
                    setTypeBooleano();
                    break;
                case "entero":
                    setTypeEntero();
                    break;
                case "decimal":
                    setTypeDecimal();
                    break;
                case "fecha":
                    setTypeFecha();
                    break;
                case "fechahora":
                    setTypeFechaHora();
                    break;
                case "hora":
                    setTypeHora();
                    break;
                case "nulo":
                    setTypeNulo();
                    break;
                case "vacio":
                    setTypeVacio();
                    break;
                //tipo objeto
                default:
                    setTypeObjeto(tipo);
                    break;

            }

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
