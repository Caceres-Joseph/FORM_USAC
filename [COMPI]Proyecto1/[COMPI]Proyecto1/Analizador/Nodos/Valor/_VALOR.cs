using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using _COMPI_Proyecto1.Analizador.Tablas.Objetos;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VALOR : nodoModelo
    {




        public _VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public itemValor getValor(elementoEntorno elementoEntor)
        { 
            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            if (hayErrores())
                return retorno;
             
            if (lstAtributos.listaAtributos.Count > 1)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                if (item1.Equals("nuevo") && item2.Equals("valId"))
                {

                    /*
                    |--------------------------------------------------------------------------
                    | =new Objeto()
                    |--------------------------------------------------------------------------
                    | tNuevo + valId + sAbreParent + LST_VAL + sCierraParent
                    | tengo que crear una nueva clase y cargar los valores globales con sus metdos, funciones, y validar constructores
                    | hay que buscar la clase primero
                    |
                    */


                    elementoClase temp = tablaSimbolos.getClase(lstAtributos.getToken(1));
                    if (temp != null)
                    {
                        objetoClase ObjClase = new objetoClase(temp, tablaSimbolos);
                        lstValores  lstValores2 = new lstValores();
                        //ahora tengo que llamar al constructor, pero digamos que no tiene, jejejeje


                        if (hijos.Count > 0)
                        {
                            nodoModelo hijo = hijos[0];
                            _LST_VAL lstval = (_LST_VAL)hijo;
                            lstValores2 = lstval.getLstValores(elementoEntor);
                            //me tiene que devolver una lista de valores,

                        }

                        ObjClase.ejecutarGlobales();//cargando sus valores globales 
                       // jlk
                        ObjClase.ejecutarConstructor(lstAtributos.getToken(1), 0, lstValores2, ObjClase.tablaEntorno.raiz);


                        retorno.setValue(ObjClase,lstAtributos.getToken(1).valLower);
                        retorno.setTypeObjeto();
                        println("Es un objeto");

                        return retorno;
                    }


                    return retorno;
                }

            }
             
            if (hijos.Count > 0)
            {
                nodoModelo hijo = hijos[0];

                switch (hijo.nombre)
                {

                    case "TIPO":
                        /*
                        |--------------------------------------------------------------------------
                        | ARREGLO
                        |--------------------------------------------------------------------------
                        | Estoy definiendo las dimensiones del arreglo
                        | tNuevo + TIPO + LST_CORCHETES_VAL
                        |
                        */

                        //println(itEntorno.nombre.valLower + "-> tNuevo + TIPO + LST_CORCHETES_VAL");
                        return retorno;

                    case "LST_LLAVES_VAL":

                        /*
                        |--------------------------------------------------------------------------
                        | ARREGLO
                        |--------------------------------------------------------------------------
                        | Le estoy enviando directamente los valores al arreglo
                        | LST_LLAVES_VAL
                        |
                        */
                        return retorno;

                    case "E":

                        /*
                        |--------------------------------------------------------------------------
                        | E
                        |--------------------------------------------------------------------------
                        */
                        _E ope = (_E)hijo;
                        return ope.getValor(elementoEntor);

                    default:
                        println(hijo.nombre + "->No se reconoció la producción :(");
                        return retorno;

                }

            }
            else
            {
                /*
                |--------------------------------------------------------------------------
                | return nulo
                |--------------------------------------------------------------------------
                | tNulo
                */

                return retorno;
            }

        }


    }
}