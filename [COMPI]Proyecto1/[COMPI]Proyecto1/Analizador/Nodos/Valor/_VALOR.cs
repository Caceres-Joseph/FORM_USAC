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

    /*
     * VALOR.Rule = tNuevo + valId + sAbreParent + LST_VAL + sCierraParent //aqui tengo que reconocer el-> nuevo opciones()
     *           | tNuevo + TIPO + LST_CORCHETES_VAL
     *           | LST_LLAVES_VAL
     *           | tNulo
     *           | tEste   //para el this solamente
     *           | E; 
     */
    {




        public _VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        public itemValor getValor(elementoEntorno elementoEntor, token tipo)
        {

            


            itemValor retorno = new itemValor();
            retorno.setTypeNulo();


            if (hayErrores())
                return retorno;

            if (lstAtributos.listaAtributos.Count == 4)
            {

                String item1 = lstAtributos.listaAtributos[0].nombretoken;
                String item2 = lstAtributos.listaAtributos[1].nombretoken;
                if (item1.Equals("nuevo") && item2.Equals("valId"))
                /*
                |---------------------------- 
                |   tNuevo + valId + sAbreParent + LST_VAL + sCierraParent 
                */
                {

                    /*
                    |--------------------------------------------------------------------------
                    | nuevo Objeto()
                    | nuevo valId()
                    |--------------------------------------------------------------------------
                    | tNuevo + valId + sAbreParent + LST_VAL + sCierraParent
                    | tengo que crear una nueva clase y cargar los valores globales con sus metdos, funciones, y validar constructores
                    | hay que buscar la clase primero
                    |
                    */

                    //token tokId = lstAtributos.getToken(1);
                    token tokInstancia = lstAtributos.getToken(1);
                    elementoClase temp = tablaSimbolos.getClase(tokInstancia);
                    if (temp != null)
                    {
                        objetoClase ObjClase = new objetoClase(temp, tablaSimbolos);
                        lstValores lstValores2 = new lstValores();
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
                        //println("ejecutando constructor de la claes, new objeto()");

                        retorno.setValue(ObjClase, lstAtributos.getToken(1).valLower);
                        retorno.setTypeObjeto(tokInstancia.valLower);
                        //println("Es un objeto");

                        return retorno;
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede  instanaciar la clase:" + tokInstancia.valLower + ", para crear el objeto, debido a que no se existe la clase ", tokInstancia);
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
                        if (hayErrores())
                            return retorno;
                        /*
                        |--------------------------------------------------------------------------
                        | ARREGLO
                        |--------------------------------------------------------------------------
                        | Hay que mapear las variables para inicializar el array valores de item
                        | Estoy definiendo las dimensiones del arreglo
                        | tNuevo + TIPO + LST_CORCHETES_VAL
                        |
                        |
                        | String[][] hola = new String[3][2];
                        |
                        | String[] jejej = new String[12];
                        | int[][] jeje = { new int[12], { 2, 2 } };
                        |
                        | int[][][] numeros = {{3,3,3},{2,2,2},{1,1,1}, {4,4,4},{5,5,5},{6,6,6}}; 
                        | hola = jejej;*/
                        nodoModelo tempTipo = getNodo("TIPO");
                        _TIPO nodoTipo = (_TIPO)tempTipo;
                        retorno.setType(nodoTipo.getTipo().valLower);

                        token item1 = lstAtributos.listaAtributos[0].tok;
                        nodoModelo temp1 = getNodo("LST_CORCHETES_VAL");
                        if (temp1 != null)
                        {
                            _LST_CORCHETES_VAL lstVal = (_LST_CORCHETES_VAL)temp1;
                            List<int> tempLstInt = lstVal.getLstInt(elementoEntor, item1);

                            println("dimension lista lst-corchetes:" + tempLstInt.Count);
                            int dimensionMaxima = 1;
                            foreach (int elemento in tempLstInt)
                            {
                               // println("dimen: " + elemento);
                                if (elemento != 0)
                                    dimensionMaxima = dimensionMaxima * elemento;
                                else
                                {
                                    tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede inicializar una matriz con tamaño 0", item1);
                                }
                            }


                            //llenando la lista de nulos


                            Dictionary<int, itemValor> diccionario = new Dictionary<int, itemValor>();

                            for (int i = 0; i < dimensionMaxima; i++)
                            {
                                diccionario.Add(i, new itemValor());
                            }

                             
                            
                            retorno.setArrayTipo(tempLstInt, diccionario, tipo.valLower);



                            //println("La dimensión mapeada -> indice máximo es " + retorno.arrayValores.Count);
                            //tengo que mapear 
                            //  sf

                        }




                        //println(itEntorno.nombre.valLower + "-> tNuevo + TIPO + LST_CORCHETES_VAL");
                        return retorno;

                    case "LST_LLAVES_VAL":

                        /*
                        |--------------------------------------------------------------------------
                        | ARREGLO
                        |--------------------------------------------------------------------------
                        | Le estoy enviando directamente los valores al arreglo
                        | LST_LLAVES_VAL esto retorna=Dictionary<int, itemValor>
                        |
                        */
                        nodoModelo tempLstLlaves = getNodo("LST_LLAVES_VAL");
                        _LST_LLAVES_VAL nodoLstLlaves = (_LST_LLAVES_VAL)tempLstLlaves;


                        nodoLstLlaves.getArray(tipo, elementoEntor);
                        int arrayLengthMapeado = getDimensionMapeada(nodoLstLlaves.lstDimensiones, tipo);
                        if (arrayLengthMapeado==nodoLstLlaves.diccionario.Count)
                        //se puede agregar correctamente
                        {

                            itemValor retorno2 = new itemValor();
                            retorno2.setType(tipo.valLower);
                            retorno2.arrayValores = nodoLstLlaves.diccionario;
                            retorno2.dimensiones = nodoLstLlaves.lstDimensiones;
                            return retorno2;
                             
                        }
                        else
                        {
                            println("Hay problema en las dimensiones del arreglo" + tipo.linea);
                        }



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
            /*
            |---------------------------- 
            |   tNulo
            |   tEste  
            */
            {
                 
                String item1 = lstAtributos.listaAtributos[0].nombretoken;

                if (item1.Equals("tEste"))
                {

                    itemValor it = new itemValor();
                    it.setTypeObjeto(elementoEntor.este.cuerpoClase.nombreClase.valLower);
                    it.setValue(elementoEntor.este, elementoEntor.este.cuerpoClase.nombreClase.valLower);

                    return it;
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



        public int getDimensionMapeada(List<int> lista, token tipo)
        {
            int indice = 1;
            foreach (int temp in lista)
            {
                if (indice == 0)
                //no puede haber un tamaño cero
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("No puede definir una dimensión de tamaño cero en la matriz de tipo: " + tipo.val, tipo);
                    return indice;
                }
                else
                {
                    indice = indice * temp;
                }
            }

            return indice;
        }

    }
}