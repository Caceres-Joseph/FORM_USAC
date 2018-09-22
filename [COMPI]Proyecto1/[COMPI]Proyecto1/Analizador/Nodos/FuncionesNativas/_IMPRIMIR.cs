using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _IMPRIMIR : nodoModelo
    {
        public _IMPRIMIR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno tablaEntornos)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */
        {
            itemRetorno retorno = new itemRetorno(0);

            //ya estoy recibiendo la tabla donde debo trabajar prro
            if (hayErrores())
                return retorno;



            _VALOR val = getNodoVALOR();
            if (val != null)
            {
                //se estan guardando valores en la variable
              //  println("Ejecutando el imprimir que tiene un hijo de valore ejejejejejejejejej");

                itemValor temp = val.getValor(tablaEntornos, new token());

                if (temp.isTypeNulo())
                {
                    tablaSimbolos.consola.insertar("nulo");
                }
                else
                {
                    if (tablaSimbolos.consola!=null)
                    {

                        if (temp.valor != null)
                        {
                            try
                            {
                                tablaSimbolos.consola.insertar(temp.valor.ToString());
                            }
                            catch (Exception e)
                            {
                                tablaSimbolos.consola.insertar(e.ToString());
                            }
                        }
                            //tablaSimbolos.consola.insertar("imprimiendo");
                    }
                    else
                    {
                        println("tablaSimblo.consola is null");
                    }
                    //
                }

            }
            else
            {
                tablaSimbolos.consola.insertar("");
            }

            return retorno;
        }

        public _VALOR getNodoVALOR()
        {
            nodoModelo temp = getNodo("VALOR");
            if (temp != null)
            {
                return (_VALOR)temp;
            }
            else
            {
                return null;
            }

        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Para cargar las variables globales prro
        |-------------------------------------------------------------------------------------------------------------------
        |
        */



    }
}
