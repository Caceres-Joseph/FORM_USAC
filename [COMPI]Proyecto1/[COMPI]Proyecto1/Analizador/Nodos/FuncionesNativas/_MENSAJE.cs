using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.GUI.gui_Mensaje;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _MENSAJE : nodoModelo
    /*
        MENSAJE.Rule = tMensaje + sAbreParent + E + sCierraParent
            | tMensaje + sAbreParent + sCierraParent;
     */
    {
        public _MENSAJE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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

            //validar que solo vengan en formulario y pregutnas, y grupos


            itemRetorno retorno = new itemRetorno(0);

            //ya estoy recibiendo la tabla donde debo trabajar prro
            if (hayErrores())
                return retorno;



            _E val = getNodoE();
            if (val != null)
            {
                //se estan guardando valores en la variable
                //  println("Ejecutando el imprimir que tiene un hijo de valore ejejejejejejejejej");

             


                itemValor temp = val.getValor(tablaEntornos);

                if (temp.isTypeNulo())
                {


                    mostrarMensaje("Mensaje");

                }
                else
                {
                    if (tablaSimbolos.consola != null)
                    {

                        if (temp.valor != null)
                        {
                            try
                            {

                                mostrarMensaje(temp.valor.ToString());
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
                mostrarMensaje("");

            }

            return retorno;
        }

        public _E getNodoE()
        {
            nodoModelo temp = getNodo("E");
            if (temp != null)
            {
                return (_E)temp;
            }
            else
            {
                return null;
            }

        }


        public void mostrarMensaje(String mensaje)
        {
            gMensaje testDialog = new gMensaje();

            testDialog.mensaje(mensaje);
            testDialog.Show();


            //Para detener la ejecución
            //testDialog.ShowDialog();
 
        }

    }
}
