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
        public int dimension = 0;
        public tablaSimbolos tabla;

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

        public itemEntorno(token nombre, token tipo, itemValor valor, token visibilidad, int dimension, tablaSimbolos tabla)
        {

            this.tabla = tabla;
            if (validandoTipo(tipo.valLower, valor.getTipo()))
            {

                this.tipo = tipo;
                this.nombre = nombre;
                this.valor = valor;
                this.visibilidad = visibilidad;
                this.dimension = dimension;
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + nombre.val + " de tipo " + tipo.valLower + ", un valor de tipo " + valor.getTipo(), nombre);

                //error semantico, se está intentando asiganar un valor diferente al declarado por la variable
            }
        }



        public Boolean validandoTipo(String tipo1, String tipo2)
        {

            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo"))
            if (getTipo(tipo1).Equals(tipo2) || tipo2.Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public String getTipo(String tipo)
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
            else
            {
                return "objeto";
            }


        }



        public void imprimir()
        {
            Console.WriteLine("\tnombre->" + nombre.valLower);
            Console.WriteLine("\t\ttipo->" + tipo.valLower);
            valor.imprimirVariable();
            Console.WriteLine("\t\tvisibilidad->" + visibilidad.valLower);
            Console.WriteLine("\t\tdimension->" + dimension);
        }

    }
}
