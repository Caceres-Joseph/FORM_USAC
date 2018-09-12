using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class lstAtributos
    {

        public List<token> listaAtributos;
        public tablaSimbolos tabla;
        public lstAtributos(tablaSimbolos tabla)
        {
            this.tabla = tabla;
            listaAtributos = new List<token>();
        }

        public void insertar(token tok)
        {

            listaAtributos.Add(tok);

            
        }
        public String getValItem(int indice)
        {
            String retorno = "";
            if (listaAtributos.Count < indice)
            {
                tabla.tablaErrores.insertErrorSemantic("[lsAtributos]getItem", 0, 0, "Indice fuera del rango");
                //Console.WriteLine("Indice fuera de rango");
            }
            else
            {
                retorno = listaAtributos[indice].val;
            }

            return retorno;
        }

        public token getToken(int indice)
        {
            token retorno = new token("", 0, 0, "---");
            if (listaAtributos.Count < indice)
            {
                tabla.tablaErrores.insertErrorSemantic("[lsAtributos]getItem", 0, 0, "Indice fuera del rango");
                //Console.WriteLine("Indice fuera de rango");
            }
            else
            {
                retorno = listaAtributos[indice];
            }

            return retorno;
        }

        /*
        public void insertarP(String llave, token tok, int inicio)
        {

            if (listaAtributos.ContainsKey(llave))
            {
                insertarP(llave, tok, inicio + 1);
            }
            else
            {
                listaAtributos.Add(llave, tok);
            }

        }



        public void imprimirAtributos()
        {
          

            int i = 0;
            foreach (KeyValuePair<string, token> kvp in listaAtributos)
            {
                token temp= kvp.Value;
                println("\t[" + i + "] val:" + temp.val + "\tlinea:" + temp.linea + "\ttcol:" + temp.columna);
                //Console.WriteLine("Key = {0}, Value = {1}",
                //    kvp.Key, kvp.Value);
                i++;
            }
 

        }
        */


        public void imprimir()
        {

            int i = 0;
            foreach (token temp in listaAtributos)
            {
                println("\t[" + i + "] val:" + temp.val + "\tlinea:" + temp.linea + "\ttcol:" + temp.columna+"\tamb:"+temp.archivo);
                i++;
            }
        }

        public void println(String mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
