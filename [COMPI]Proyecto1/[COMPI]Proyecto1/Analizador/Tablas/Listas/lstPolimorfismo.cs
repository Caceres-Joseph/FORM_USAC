using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Llaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    /*
     * Esta lista cotinene metodos con diferentes parametros
     */
    class lstPolimorfismo
    {
        public List<elementoPolimorfo> listaPolimorfa;
        public tablaSimbolos tabla;
        public String nombre;

        public lstPolimorfismo(tablaSimbolos tabla, String nombre)
        {
            this.tabla = tabla;
            listaPolimorfa = new List<elementoPolimorfo>();
            this.nombre = nombre;
        }

        public void insertarElemento(elementoPolimorfo elem)
        {
            //tengo que verificar si ya existe validando los parametros

            if (siExiste(elem))//Si existe
            {
                tabla.tablaErrores.insertErrorSyntax("El metodo/funcion  :" + elem.nombre.val + " ya está declarada con los mismos parámetros.", elem.nombre);
            }
            else
            {
                listaPolimorfa.Add(elem);
            }

        }

        public Boolean siExiste(elementoPolimorfo elem)
        {

            Boolean retorno = false;
            foreach (elementoPolimorfo temp in listaPolimorfa)
            {
                if (elem.nombre.valLower.Equals(temp.nombre.valLower))
                {
                    if (elem.compararParametros(temp.getListaLlaves()))
                    {
                        return true;
                    }
                    //ahora hay que comprobar las llaves de los atributos
                }
            }

            return retorno;
        }

        public void prueba(int a)
        {

        }


        public virtual void ejecutar(elementoEntorno elem)
        {


        }


        public virtual  void ejecutarMetodo(token nombre, int diemension, lstValores lista2, elementoEntorno tablaEntorno)
        {
            //aqui es donde tengo que buscar si existe 
            elementoPolimorfo temp = getElementoPolimorfo(nombre, lista2);
            if (temp!=null)
            {
                //tengo que crear un nuevo entorno

                elementoEntorno hijo1 = new elementoEntorno(tablaEntorno, tabla, "main");

                

                Console.WriteLine("ejecutando el metodo " + nombre.val + "(" + lista2.getCadenaParam() + ")");
            }
        }


        public elementoPolimorfo getElementoPolimorfo(token nombre,  lstValores listaValores)
        {
             

            foreach (elementoPolimorfo temp in listaPolimorfa)
            {
                if (nombre.valLower.Equals(temp.nombre.valLower))
                {
                    //ahora hay que validar los parametros


                    if (temp.compararParametros(listaValores))
                    {
                        return temp;
                    }
                    //ahora hay que comprobar las llaves de los atributos
                }
            }

            tabla.tablaErrores.insertErrorSemantic("No se encuentra "+nombre.val+"("+listaValores.getCadenaParam()+")", nombre);
            return null;
        }
        public String convertirlstValores_toString(List<itemValor> lstValores)
        {
            String retorno = "";


            return retorno;
        }


        public int getCount()
        {
            return listaPolimorfa.Count();
        }

        public void imprimir()
        {

            //Console.WriteLine("[lstPolimorfismo]\t\t"+nombre+":");
            if (listaPolimorfa.Count > 0)
            {
                Console.WriteLine("\t\t" + nombre + ":");

                foreach (elementoPolimorfo temp in listaPolimorfa)
                {
                    temp.imprimir();
                }
            }
        }




    }
}
