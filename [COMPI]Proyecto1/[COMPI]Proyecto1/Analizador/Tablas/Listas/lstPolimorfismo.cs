using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Elementos;
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


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN DE PRINCIPAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
         
        

        public void guardarParametrosEnLaTabla(Dictionary<llaveParametro, elementoParametro> lstParametros, lstValores lstParametros2, elementoEntorno elementoEntor)
        {

            if (lstParametros.Count == lstParametros2.listaValores.Count)
            {
                int i = 0;
                foreach (var dic in lstParametros)
                {
                    itemValor parametro2 = lstParametros2.getItemValor(i);
                


                    //Console.WriteLine("------------------------");
                    //Console.WriteLine("dic.key.dimension-> " + dic.Key.dimension);
                    //Console.WriteLine("parametro2.dimensiones->" + parametro2.dimensiones.Count);

                    if ((dic.Key.dimension == parametro2.dimensiones.Count) && (dic.Value.tipo.valLower.Equals(parametro2.getTipo())))
                    {
                        token tNombre = new token(dic.Key.nombre);
                        token tTipo = new token(dic.Value.tipo.valLower);
                        token tVisibilidad = new token("privado");

                        //listado de enteros


                        List<int> listaEntero = new List<int>();

                        for (int j = 0; i < dic.Key.dimension; i++)
                        {
                            listaEntero.Add(-1);
                        }

                        itemEntorno varParametro = new itemEntorno(tNombre, tTipo, parametro2, tVisibilidad, listaEntero, tabla);
                        elementoEntor.insertarEntorno(varParametro);
                    }
                    else
                    {
                        Console.WriteLine("[lstPolimorfismo]guardarParametrosEnLaTabla_Son de diferentes en tipo, o en dimensiones, aunque esto ya se tuvo que validar :/");
                    }

                    i++;
                }

            }
            else
            {
                Console.WriteLine("[lstPolimorfismo]guardarParametrosEnLaTabla_Son de diferentes dimensiones, aunque esto ya se tuvo que validar :/");
            }

        }





        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Busca el elemento polimorfo
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public elementoPolimorfo getElementoPolimorfo2(token nombre, lstValores listaValores)
        {


            foreach (elementoPolimorfo temp in listaPolimorfa)
            {
                if (nombre.valLower.Equals(temp.nombre.valLower))
                {
                    //ahora hay que validar los parametros


                    if (temp.compararParametrosLstValores(listaValores))
                    {
                        return temp;
                    }
                    //ahora hay que comprobar las llaves de los atributos
                }
            }

            tabla.tablaErrores.insertErrorSemantic("No se encuentra " + nombre.val + "(" + listaValores.getCadenaParam() + ")", nombre);
            return null;
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Busca el elemento polimorfo
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public elementoPolimorfo getElementoPolimorfoNoSirve(token nombre, lstValores listaValores)
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

            tabla.tablaErrores.insertErrorSemantic("No se encuentra " + nombre.val + "(" + listaValores.getCadenaParam() + ")", nombre);
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
