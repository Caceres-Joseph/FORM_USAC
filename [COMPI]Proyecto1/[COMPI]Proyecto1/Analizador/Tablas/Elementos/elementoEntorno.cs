using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class elementoEntorno
    {
        public Dictionary<String, itemEntorno> lstEntorno;
        public elementoEntorno anterior;
        public tablaSimbolos tabla;
        public String nombre;

        public elementoEntorno(elementoEntorno anterior, tablaSimbolos tabla, String nombre)
        {
            this.nombre = nombre;
            this.tabla = tabla;
            this.anterior = anterior;
            lstEntorno = new Dictionary<string, itemEntorno>();
        }


        public void insertarEntorno(itemEntorno param)
        {
            if (tabla.hayErrores("elementoEntorno"))
                return;

            String llave = param.nombre.valLower;
            if (!lstEntorno.ContainsKey(llave))
            {
                lstEntorno.Add(llave,param);
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("La variable " + param.nombre.val +" ya se encuentra declarada en el mismo ambito.", param.nombre);
            }
        }

        public void imprimir()
        {
            Console.WriteLine("+--------------------+");
            Console.WriteLine("| Entorno ["+nombre+"]");
            Console.WriteLine("+--------------------+");
            foreach (var el in lstEntorno)
            {
                Console.WriteLine("\tkey->"+el.Key);
                el.Value.imprimir();
            }

            if (anterior!=null)
            {
                anterior.imprimir();
            }
        }

         public itemEntorno getItemValor(String idVariable)
        {
            itemEntorno retorno = null;




            if (lstEntorno.ContainsKey(idVariable))
            {
                itemEntorno el = lstEntorno[idVariable];
                return el;
            }
            else
            {

                if (anterior != null)
                {
                    return  anterior.getItemValor(idVariable);
                }
            }


            return retorno;
        }

    }
}
