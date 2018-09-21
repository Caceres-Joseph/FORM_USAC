using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Elementos;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using _COMPI_Proyecto1.Analizador.Tablas.Llaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class elementoPolimorfo
    {
        public token tipo;
        public Dictionary<llaveParametro, elementoParametro> lstParametros;
        public token nombre;
        public Object retorno;
        public tablaSimbolos tablaSimbolos;
        public nodoModelo LST_CUERPO;
        public token visibilidad;
        public int dimension = 0;


        public List<int> getDimension()
        {
            List<int> retorno = new List<int>();
            for(int i=0; i < dimension; i++)
            {
                retorno.Add(-1);
            }
            
            return retorno;
            
        }



        public void elementoPolimorfo3(tablaSimbolos tabla)
        {
            this.tablaSimbolos = tabla;
            this.tipo = new token();
            this.lstParametros = new Dictionary<llaveParametro, elementoParametro>();
            this.retorno = new object();
            this.LST_CUERPO = new nodoModelo("", tabla);
            this.nombre = new token();
            this.visibilidad = new token("publico");
        }

        public elementoPolimorfo(token visibilidad, tablaSimbolos tabla, token tipo, token nombre, nodoModelo LST_CUERPO, int dimension)
        {
            this.dimension = dimension;
            this.tablaSimbolos = tabla;
            this.tipo = tipo;
            this.nombre = nombre;
            this.lstParametros = new Dictionary<llaveParametro, elementoParametro>();
            this.retorno = new object();
            this.LST_CUERPO = LST_CUERPO;
            this.visibilidad = visibilidad;
        }


        public void insertarParametro(token idParametro, token tipoParametro, int dimensiones)
        {
            llaveParametro key = new llaveParametro(idParametro.valLower, tipoParametro.valLower, dimensiones);


            foreach (var temp in lstParametros)
            {
                if (key.nombre.Equals(temp.Key.nombre))
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("El parametro:" + idParametro.val + " ya se encuentra declarado.", idParametro);
                    return;
                }
            }


            elementoParametro param = new elementoParametro(tipoParametro, dimensiones);
            lstParametros.Add(key, param);

            //tengo que validar si ya existe 
        }

        public void imprimir()
        {
            println("\t\t\tnombre:" + this.nombre.valLower + "  tipo:" + this.tipo.valLower + "  visibilidad:" + this.visibilidad.valLower + "  dimension:" + this.dimension);
            imprimirParametros();
        }

        public void imprimirParametros()
        {
            if (lstParametros.Count > 0)
            {
                println("\t\t\t\tParametros:");
            }
            foreach (var item in lstParametros)
            {
                elementoParametro temp = item.Value;
                println("\t\t\t\t\tNombre:" + item.Key.nombre + "  Dimension:" + item.Key.dimension + "  Tipo:" + temp.tipo.valLower);
            }
        }

        public List<llaveParametro> getListaLlaves()
        {
            List<llaveParametro> retorno = new List<llaveParametro>();
            foreach (var a in lstParametros)
            {
                retorno.Add(a.Key);
            }
            return retorno;
        }

        public Boolean compararParametros(List<llaveParametro> lsParametros2)
        {
            Boolean retorno = false;
            if (lstParametros.Count == lsParametros2.Count)
            {
                retorno = true;


                for (int i = 0; i < lstParametros.Count; i++)
                {

                    llaveParametro lst1 = getListaLlaves()[i];
                    llaveParametro lst2 = lsParametros2[i];

                    if (lst1.tipo.Equals(lst2.tipo))
                    {
                        if (lst1.dimension != lst2.dimension)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }

                return retorno;
            }
            else
            {
                return false;
            }

        }



        public Boolean compararParametros(lstValores lsParametros)
        {
            Boolean retorno = false;
            if (lstParametros.Count == lsParametros.listaValores.Count)
            {
                retorno = true;

                for (int i = 0; i < lstParametros.Count; i++)
                {

                    llaveParametro lst1 = getListaLlaves()[i];
                    itemValor lst2 = lsParametros.getItemValor(i);

                    //El priemro es para comprobar los tipos
                    //el segundo es para comparar objetos
                    if (lst1.tipo.Equals(lst2.getTipo()) || lst1.tipo.Equals(lst2.nombreObjeto))
                    {
                        if (lst1.dimension != lst2.dimensiones.Count)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }

                return retorno;
            }
            else
            {
                return false;
            }

        }


        public void println(String mensaje)
        {
            Console.WriteLine(mensaje);
        }

    }
}
