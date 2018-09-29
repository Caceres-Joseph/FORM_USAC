using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    class lstMetodo_funcion : lstPolimorfismo
    {
        public lstMetodo_funcion(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN DE METODO 
        |-------------------------------------------------------------------------------------------------------------------
        |
        */


        public itemValor getMetodoFuncion(token nombre, lstValores parametros, elementoEntorno tablaEntorno, String nombreAmbitoEntorno)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeVacio();

            //aqui es donde tengo que buscar si existe 
            Console.WriteLine("ejecutando Metodo:" + nombre.val);
            elementoPolimorfo temp = getElementoPolimorfo2(nombre, parametros);
            if (temp != null)
            //neuvo entorno
            {

                elementoEntorno hijo1 = new elementoEntorno(tablaEntorno, tabla, nombreAmbitoEntorno, tablaEntorno.este);
                guardarParametrosEnLaTabla(temp.lstParametros, parametros, hijo1);


                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                /*
                |---------------------------- 
                |  Ejecutando el cuerpo del metodo
                */

                /*
                |---------------------------- 
                | EJECUTAR 
                |----------------------------
                | 0 = normal
                | 1 = return;
                | 2 = break
                | 3 = continue
                | 4 = errores
                */

                {


                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;

                    itemRetorno result = val.ejecutar(hijo1);

                    if (temp.tipo.valLower.Equals("vacio"))
                    {
                        if (result.isNormal())//que es el normal
                        {

                        }
                        else if (result.isRetorno())
                        {
                            if (result.valor.isTypeVacio())
                            //fue el return normla, sin expresion
                            {

                            }
                            else
                            {
                                tabla.tablaErrores.insertErrorSemantic("El metodo :" + temp.nombre.val + " está declarado como vacio, pero se retorno una expresión", temp.nombre);
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    /* 
                    | 0 = normal
                    | 1 = return;
                    | 2 = break
                    | 3 = continue
                    | 4 = errores
                    */
                    {

                        if (result.isNormal())
                        {
                            tabla.tablaErrores.insertErrorSemantic("El metodo :" + temp.nombre.val + " debe de retorar un valor", temp.nombre);

                        }
                        else if (result.isRetorno())
                        {
                            if (temp.dimension == result.valor.dimensiones.Count)
                            {

                                //para los tipos
                                if (itemEntorno.validandoTipo(temp.tipo.valLower, result.valor))
                                {
                                    return result.valor;
                                } 
                                else
                                {
                                    tabla.tablaErrores.insertErrorSemantic("El metodo :" + temp.nombre.val + " es de tipo :" + temp.tipo.val + " sin embargo tiene un retorno de tipo: " + result.valor.getTipo(), temp.nombre);
                                    return retorno;
                                } 
                            }
                            else
                            {
                                tabla.tablaErrores.insertErrorSemantic("El metodo :" + temp.nombre.val + " es de dimensión :" + temp.dimension + " sin embargo tiene un retorno de dimensión: " + result.valor.dimensiones.Count, temp.nombre);
                                return retorno;
                            }
                        }
                        else
                        {

                        }
                    }

                    ///hay que comparar el retorno con el tipo definido

                }

                //Console.WriteLine("---------------------------Imprimiendo el metodo Funcion-------------------------");
                //hijo1.imprimir();

            }

            return retorno;
        }
    }
}
