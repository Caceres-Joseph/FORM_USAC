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
        List<elementoPolimorfo> listaPolimorfa;
        tablaSimbolos tablaSimbolos;
        String nombre;

        public lstPolimorfismo(tablaSimbolos tabla, String nombre)
        {
            this.tablaSimbolos = tabla;
            listaPolimorfa = new List<elementoPolimorfo>();
            this.nombre = nombre;
        }

        public void insertarElemento(elementoPolimorfo elem)
        {
            //tengo que verificar si ya existe validando los parametros
             
            if (siExiste(elem))//Si existe
            {
                tablaSimbolos.tablaErrores.insertErrorSyntax("El metodo/funcion  :"+ elem.nombre.val+" ya está declarada con los mismos parámetros.",elem.nombre);
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
