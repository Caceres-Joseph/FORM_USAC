using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.IdVar_func;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.OpeAritmetica;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Asignar_Valor
{
    class _ASIG_VALOR : nodoModelo

    /*
    
            ASIG_VALOR.Rule = ID_VAR_FUNC + VAL
                | ID_VAR_FUNC + sMas + sMas
                | ID_VAR_FUNC + sMenos + sMenos
                | ID_VAR_FUNC + LST_CORCHETES_VAL + VAL
                ;
    */

    {
        public _ASIG_VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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
            if (hayErrores())
                return retorno;



            if (hijos.Count == 2)
            /*
            |---------------------------- 
            |  ID_VAR_FUNC + VAL
            */

            {
                //PUNTERO DONDE VOY A GUARDAR EL VALOR
                _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
                itemEntorno destino = nodoFunc.getDestino(tablaEntornos);


                //AHORA OBTENGO EL VALOR 
                _VAL nodoVal = (_VAL)getNodo("VAL");
                if (nodoVal != null)
                {
                    if (destino != null)
                    {
                        itemValor valor = nodoVal.getValor(tablaEntornos, destino.tipo);
                        if (destino.lstDimensionesAcceso.Count > 0)
                        //viene la posición de un arreglo
                        {
                            asignarValorMatriz(destino, valor);
                        }
                        else
                        {
                            asignarValor(destino, valor);
                        }
                    }
                    else
                    {
                        println("Me retorno un itemEntorno vacio, no podré asignar la variable prro");
                    }
                }
                else
                {
                    println("no tiene nodo VAl");
                }




            }

            else if (hijos.Count == 1)
            {

                if (lstAtributos.getToken(0).valLower.Equals("+"))
                /*
                |---------------------------- 
                |  ID_VAR_FUNC + sMas + sMas
                */
                {
                    if (hayErrores())
                        return retorno;

                    _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
                    itemEntorno destino = nodoFunc.getDestino(tablaEntornos);



                    if (destino.lstDimensionesAcceso.Count > 0)
                    //viene la posición de un arreglo
                    {

                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede incrementar la matriz " + destino.nombre.val + " de tipo: " + destino.tipo.valLower, destino.nombre);
                    }
                    else
                    {
                        itemValor valor = nodoFunc.getValor(tablaEntornos);
                        itemValor valor2 = new itemValor();
                        valor2.setValue(1);

                        suma sumatoria = new suma(new _E("hijo1", tablaSimbolos), new _E("hijo2", tablaSimbolos), tablaSimbolos, lstAtributos.getToken(0));

                        itemValor resultado = sumatoria.opSumaExterna(tablaEntornos, valor, valor2);

                        Object ObjParseado = resultado.getValorParseado(destino.tipo.valLower);
                        if (ObjParseado != null)
                        {
                            destino.valor.valor = ObjParseado;
                            return retorno;

                        }
                        else
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede asignar un tipo :" + sumatoria.GetType() + " a la variable " + destino.nombre.val + " de tipo: " + destino.tipo.valLower, destino.nombre);
                            return retorno;
                        }
                    } 
                    
                }
                else
                /*
                |---------------------------- 
                |  ID_VAR_FUNC + smenos + smenos
                */
                {

                    if (hayErrores())
                        return retorno;

                    _ID_VAR_FUNC nodoFunc = (_ID_VAR_FUNC)getNodo("ID_VAR_FUNC");
                    itemEntorno destino = nodoFunc.getDestino(tablaEntornos);



                    if (destino.lstDimensionesAcceso.Count > 0)
                    //viene la posición de un arreglo
                    {

                        tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede incrementar la matriz " + destino.nombre.val + " de tipo: " + destino.tipo.valLower, destino.nombre);
                    }
                    else
                    {
                        itemValor valor = nodoFunc.getValor(tablaEntornos);
                        itemValor valor2 = new itemValor();
                        valor2.setValue(1);

                        resta sumatoria = new resta(new _E("hijo1", tablaSimbolos), new _E("hijo2", tablaSimbolos), tablaSimbolos, lstAtributos.getToken(0));

                        itemValor resultado = sumatoria.opRestaExterna(tablaEntornos, valor, valor2);

                        Object ObjParseado = resultado.getValorParseado(destino.tipo.valLower);
                        if (ObjParseado != null)
                        {
                            destino.valor.valor = ObjParseado;
                            return retorno;

                        }
                        else
                        {
                            tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede asignar un tipo :" + sumatoria.GetType() + " a la variable " + destino.nombre.val + " de tipo: " + destino.tipo.valLower, destino.nombre);
                            return retorno;
                        }
                    }

                }

            }

            return retorno;
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        /* public void asignarValor(itemValor destino, itemValor valor, token tokIgual)
         {

             if (destino.dimensiones.Count > 0)
             {
                 if (destino.dimensiones.Count == valor.dimensiones.Count)
                 {
                     if (validandoTipo(destino.getTipo(), valor.getTipo()))
                     {

                         //aquí se hace la asignación
                         destino = valor;
                     }
                     {
                         tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en una variable de tipo " + destino.getTipo() + ", un valor de tipo " + valor.getTipo(), tokIgual);

                     } 
                 }
                 else
                 {
                     tablaSimbolos.tablaErrores.insertErrorSemantic("Se esta recibiendo una dimensión :" + valor.dimensiones.Count + " para asignarlo a la matriz :  de dimension:" + destino.dimensiones.Count, tokIgual);
                 }
             }
             else
             { 
                 if (valor.dimensiones.Count != 0)
                 {
                     tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en la variable  de tipo " + destino.getTipo() + ", una matriz de dimension : " + valor.dimensiones.Count, tokIgual);
                 }
                 else if (validandoTipo(destino.getTipo(), valor.getTipo()))
                 {

                     //aquí se hace la asignación
                     destino = valor; 
                 }
                 else
                 { 
                     tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en una variable de tipo " + destino.getTipo() + ", un valor de tipo " + valor.getTipo(), tokIgual);
                 }
             }

         }*/


        public void asignarValor(itemEntorno destino, itemValor valor)
        {

            //validando si lo que estoy esperando es un arreglo

            if (destino.dimension.Count > 0)
            {
                if (destino.dimension.Count == valor.dimensiones.Count)
                {

                    if (validandoTipo(destino.tipo.valLower, valor.getTipo()))
                    {

                        //aquí le asigno el valor
                        destino.valor = valor;

                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", un valor de tipo " + valor.getTipo(), destino.nombre);
                    }
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se esta recibiendo :" + valor.dimensiones.Count + " en la matriz : " + destino.nombre.val + " de dimension:" + destino.dimension.Count, destino.nombre);
                }
            }
            else
            {
                if (valor.dimensiones.Count != 0)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en la variable :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", una matriz de dimension : " + valor.dimensiones.Count, destino.nombre);
                }
                else if (validandoTipo(destino.tipo.valLower, valor.getTipo()))
                {

                    //aquí le asigno el valor

                    destino.valor = valor;
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", un valor de tipo " + valor.getTipo(), destino.nombre);

                    //error semantico, se está intentando asiganar un valor diferente al declarado por la variable
                }
            }
        }

        public void asignarValorMatriz(itemEntorno destino, itemValor valor)
        {

            //validando si lo que estoy esperando es un arreglo

            if (destino.dimension.Count > 0)
            {
                if (destino.dimension.Count == destino.lstDimensionesAcceso.Count)
                {

                    if (validandoTipo(destino.tipo.valLower, valor.getTipo()))
                    {

                        int indiceFinal = indiceMapeado(destino.dimension, destino.lstDimensionesAcceso, destino.nombre);
                        if (indiceFinal > -1)
                        {


                            if (indiceFinal < destino.valor.arrayValores.Count)
                            {

                                destino.valor.arrayValores[indiceFinal] = valor;

                            }
                            else
                            {
                                tablaSimbolos.tablaErrores.insertErrorSemantic("No se puede acceder a la posición  de la matriz: " + destino.nombre.val, destino.nombre);

                            }
                        }

                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando guardar en :" + destino.nombre.val + " de tipo " + destino.tipo.valLower + ", un valor de tipo " + valor.getTipo(), destino.nombre);
                    }
                }
                else
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se esta recibiendo :" + valor.dimensiones.Count + " en la matriz : " + destino.nombre.val + " de dimension:" + destino.dimension.Count, destino.nombre);
                }
            }
            else
            {

                tablaSimbolos.tablaErrores.insertErrorSemantic("Se está intentando acceder a una matriz  en una variable  :" + destino.nombre.val + "que no lo es.", destino.nombre);


            }
        }



        public Boolean validandoTipo(String tipo1, String tipo2)
        {
            //aquí también hay que verificar las dimensiones


            //if (tipo1.Equals(tipo2) || tipo2.Equals("nulo"))
            itemValor tempIt = new itemValor();
            if (tempIt.getTipoApartirDeString(tipo1).Equals(tipo2) || tipo2.Equals("nulo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public int indiceMapeado(List<int> limites, List<int> indices, token nombreMatriz)
        {

            if (limites.Count == indices.Count)
            {

                int indiceFinal = 1;
                //validando si no se salió de los indices
                for (int i = 0; i < limites.Count; i++)
                {
                    if (indices[i] < limites[i])
                    {

                        if (i == 0)
                        //inicilizo la lista
                        {
                            indiceFinal = indices[i];
                        }
                        else
                        {
                            indiceFinal = indiceFinal * limites[i] + indices[i];
                        }
                    }
                    else
                    {
                        tablaSimbolos.tablaErrores.insertErrorSemantic("El índice está fuera de rango de la matriz: " + nombreMatriz.val + " , rango máximo permitido para la dimensión:" + i + " es " + (limites[i] - 1), nombreMatriz);
                        return -1;
                    }
                }

                return indiceFinal;
            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("No coinciden las dimensiones en la matriz: " + nombreMatriz.val + " para acceder a ella", nombreMatriz);
                return -1;
            }

        }



    }
}
