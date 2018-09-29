using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemEntorno
    {
        public token tipo;
        public token nombre;
        public itemValor valor;
        public token visibilidad;
        //public int dimension = 0;
        public List<int> dimension = new List<int>();
        public tablaSimbolos tabla;


        public List<int> lstDimensionesAcceso = new List<int>();

        /*
        public itemEntorno(tablaSimbolos tabla)
        {
            this.tipo = new token("nulo");
            this.nombre = new token("--");
            this.valor = new itemValor();
            valor.setTypeNulo();
            this.visibilidad = new token("privado");
            this.dimension = 0;
            this.tabla = tabla;
        }*/

        public itemEntorno(token nombre, token tipo, itemValor valor, token visibilidad, List<int> dimension, tablaSimbolos tabla)
        {

            //validando si lo que estoy esperando es un arreglo

            if (dimension.Count > 0)
            {
                if (dimension.Count == valor.dimensiones.Count)
                {
                    this.tipo = tipo;
                    this.nombre = nombre;


                    //aqui tengo qee validar los objetos
                    this.valor = valor;
                    itemValor tempIt = new itemValor();
                    String tipoDato1 = tempIt.getTipoApartirDeString(tipo.valLower);

                    if (tipoDato1.Equals("objeto") != valor.isTypeNulo())
                        this.valor.setTypeObjeto(tipo.valLower);


                    this.visibilidad = visibilidad;
                    this.dimension = valor.dimensiones; //asi ya tiene dimensiones definidas

                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("Se esta recibiendo :" + valor.dimensiones.Count + " en la matriz : " + nombre.val + " de dimension:" + dimension.Count, nombre);
                }
            }
            else
            {

                this.tabla = tabla;

                if (valor.dimensiones.Count != 0)
                {
                    tabla.tablaErrores.insertErrorSemantic("Se está intentando guardar en la variable :" + nombre.val + " de tipo " + tipo.valLower + ", una matriz de dimension : " + valor.dimensiones.Count, nombre);
                }
                else if (sePuedeParsear(tipo.valLower, valor))
                {
                    this.tipo = tipo;
                    this.nombre = nombre;


                    //guardar el valor parseado.

                    this.valor = valor;
                    this.valor.valor = valor.getValorParseado(tipo.valLower);


                    itemValor tempIt = new itemValor();
                    String tipoDato1 = tempIt.getTipoApartirDeString(tipo.valLower);
                    if (tipoDato1.Equals("objeto") != valor.isTypeNulo())
                        this.valor.setTypeObjeto(tipo.valLower);



                    this.visibilidad = visibilidad;
                    this.dimension = dimension;
                }
                else if (validandoTipo(tipo.valLower, valor))
                {

                    this.tipo = tipo;
                    this.nombre = nombre;


                    //aqui tengo qee validar los objetos
                    this.valor = valor;
                    itemValor tempIt = new itemValor();
                    String tipoDato1 = tempIt.getTipoApartirDeString(tipo.valLower);
                    if (tipoDato1.Equals("objeto") != valor.isTypeNulo())
                        this.valor.setTypeObjeto(tipo.valLower);



                    this.visibilidad = visibilidad;
                    this.dimension = dimension;
                }
                else
                {
                    tabla.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + nombre.val + " de tipo " + tipo.valLower + ", un valor de tipo " + valor.getTipo(), nombre);

                    //error semantico, se está intentando asiganar un valor diferente al declarado por la variable
                }
            }
        }



        /*public Boolean validandoTipo(String tipo1, String tipo2, itemValor valor2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo"))
            itemValor tempIt = new itemValor();
            String tipoDato1 = tempIt.getTipoApartirDeString(tipo1);

            if (tipoDato1.Equals("objeto") && valor2.isTypeObjeto())
            //validando que sean los mismos tipos
            {
                if (tipo1.Equals(valor2.nombreObjeto))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tipoDato1.Equals(tipo2) || tipo2.Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }*/

        public static Boolean validandoTipo(String tipo1, itemValor valor2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo"))
            itemValor tempIt = new itemValor();
            String tipoDato1 = tempIt.getTipoApartirDeString(tipo1);

            if (valor2.getTipo().Equals("nulo"))
            {
                return true;
            }
            else if (tipoDato1.Equals("objeto") && valor2.isTypeObjeto())
            //validando que sean los mismos tipos
            {
                if (tipo1.Equals(valor2.nombreObjeto))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (tipoDato1.Equals(valor2.getTipo()) || valor2.getTipo().Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Boolean sePuedeParsear(String tipo1, itemValor valor2)
        {

            Object objetoParseado = valor2.getValorParseado(tipo1);
            if (objetoParseado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public void imprimir()
        {
            Console.WriteLine("\tnombre->" + nombre.valLower);
            Console.WriteLine("\t\ttipo->" + tipo.valLower);
            valor.imprimirVariable();
            Console.WriteLine("\t\tvisibilidad->" + visibilidad.valLower);
            Console.WriteLine("\t\tdimension->" + dimension.Count);
            int indice = 0;
            foreach (int ent in dimension)
            {
                Console.WriteLine("\t\t\tdim1: " + indice + "[" + ent + "]");
                indice++;
            }
        }

    }
}
