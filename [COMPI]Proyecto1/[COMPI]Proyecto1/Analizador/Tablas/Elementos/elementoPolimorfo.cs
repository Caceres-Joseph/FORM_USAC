using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Elementos;
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
        public int dimensiones = 0;

        public void elementoPolimorfo3(tablaSimbolos tabla)
        {
            this.tablaSimbolos = tabla;
            this.tipo = new token();
            this.lstParametros = new Dictionary<llaveParametro, elementoParametro>();
            this.retorno = new object();
            this.LST_CUERPO = new nodoModelo("", tabla);
            this.nombre = new token();
        }

        public elementoPolimorfo(tablaSimbolos tabla,token tipo, token nombre, nodoModelo LST_CUERPO)
        {
            this.tablaSimbolos = tabla;
            this.tipo = tipo;
            this.nombre = nombre;
            this.lstParametros = new Dictionary<llaveParametro, elementoParametro>();
            this.retorno = new object();
            this.LST_CUERPO = LST_CUERPO;
        }


        public void insertarParametro(token idParametro, token tipoParametro, int dimensiones)
        {
            llaveParametro key = new llaveParametro(idParametro.valLower, tipoParametro.valLower);
            if (lstParametros.ContainsKey(key))
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("El parametro:" + idParametro.val + " ya se encuentra declarado.", idParametro);
            }
            else
            {
                elementoParametro param = new elementoParametro(tipoParametro, dimensiones);
                lstParametros.Add(key, param);
            } 
            //tengo que validar si ya existe 
        }

        public void imprimir()
        {
            println("\t\t\tnombre:"+this.nombre.valLower+"  tipo:"+this.tipo.valLower);
            imprimirParametros();
        }

        public void imprimirParametros()
        {
            if (lstParametros.Count>0)
            {
                println("\t\t\t\tParametros:");
            }
            foreach (var item in lstParametros)
            {
                elementoParametro temp = item.Value;
                println("\t\t\t\t\tNombre:" + item.Key+"  Dimension:"+temp.dimensiones+"  Tipo:"+temp.tipo.valLower);
            } 
        }

        public void println(String mensaje)
        {
            Console.WriteLine(mensaje);
        }

    }
}
