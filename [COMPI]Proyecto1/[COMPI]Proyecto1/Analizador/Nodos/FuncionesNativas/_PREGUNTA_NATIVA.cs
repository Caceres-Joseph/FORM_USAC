using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;
using _COMPI_Proyecto1.Analizador.Tablas.Listas;
using _COMPI_Proyecto1.GUI.Preguntas;

namespace _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas
{
    class _PREGUNTA_NATIVA : nodoModelo
    /*
     * PREGUNTA_NATIVA.Rule = tNativo + valId + sAbreParent + LST_VAL + sCierraParent;
     */
    {
        public _PREGUNTA_NATIVA(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }



        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public itemValor getValor(elementoEntorno tablaEntornos)
        /*
        |---------------------------- 
        | EJECUTAR 
        |----------------------------
        | 0 = _entero
        | 1 = _cadena;
        | 2 = _decimal
        | 3 = _rango
        | 4 = _fecha
        | 5 = _hora
        | 6 = _fechaHOra
        | 7 = _seleccionar_1
        | 8 = _seleccionar
        | 9 = _nota
        */

        {


            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            itemValorPregunta param = new itemValorPregunta();
            param.respuesta = retorno;

            String tipo = lstAtributos.getToken(1).valLower;
            if (tipo.Equals("_entero"))
            {
                _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
                lstValores listaValores = temp.getLstValores(tablaEntornos);

                if (listaValores.listaValores.Count != 2)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando dos parametros, limite inferior, y limite superior", lstAtributos.getToken(0));
                    return retorno;
                }


                itemValor limitInf = listaValores.listaValores[0];
                itemValor limitSup = listaValores.listaValores[1];

                Object obj = limitInf.getValorParseado("entero");
                Object obj2 = limitSup.getValorParseado("entero");

                if (obj == null || obj2 == null)
                {
                    frmEntero fdecimal = new frmEntero(param, tablaEntornos, -1, -1);
                    fdecimal.ShowDialog();
                    return retorno;
                }
                else
                {
                    frmEntero fdecimal = new frmEntero(param, tablaEntornos, (int)obj, (int)obj2);
                    fdecimal.ShowDialog();
                    return retorno;
                }
            }

            else if (tipo.Equals("_cadena"))
            {
                frmCadena fCadena = new frmCadena(param, tablaEntornos);
                fCadena.ShowDialog();
                return retorno;
            }
            else if (tipo.Equals("_decimal"))
            {

                _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
                lstValores listaValores = temp.getLstValores(tablaEntornos);

                if (listaValores.listaValores.Count != 2)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando dos parametros, limite inferior, y limite superior", lstAtributos.getToken(0));
                    return retorno;
                }


                itemValor limitInf = listaValores.listaValores[0];
                itemValor limitSup = listaValores.listaValores[1];

                Object obj = limitInf.getValorParseado("entero");
                Object obj2 = limitSup.getValorParseado("entero");

                if (obj == null || obj2 == null)
                {
                    frmDecimal fdecimal = new frmDecimal(param, tablaEntornos, -1, -1);
                    fdecimal.ShowDialog();
                    return retorno;
                }
                else
                {
                    frmDecimal fdecimal = new frmDecimal(param, tablaEntornos, (int)obj, (int)obj2);
                    fdecimal.ShowDialog();
                    return retorno;
                }

            }
            else if (tipo.Equals("_booleano"))
            {

                _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
                lstValores listaValores = temp.getLstValores(tablaEntornos);

                if (listaValores.listaValores.Count != 2)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando dos parametros, uno verdadero, y otro falso", lstAtributos.getToken(0));
                    return retorno;
                }


                itemValor valVerdadero = listaValores.listaValores[0];
                itemValor valFalso = listaValores.listaValores[1];


                if (!(valVerdadero.isTypeCadena() && valFalso.isTypeCadena()))
                {
                    valVerdadero.setValue("Si");
                    valFalso.setValue("No");
                }


                frmBooleano fCadena = new frmBooleano(param, tablaEntornos, valVerdadero.getCadena(), valFalso.getCadena());
                fCadena.ShowDialog();
                return retorno;

                //aquí espero dos parametros de tipo cadena

            }
            else if (tipo.Equals("_nota"))
            {
                frmNota fCadena = new frmNota(param, tablaEntornos);
                fCadena.ShowDialog();
                retorno.setValue("cadena");
                return retorno;

            }
            else if (tipo.Equals("_fecha"))
            {
                frmFecha fFecha = new frmFecha(param, tablaEntornos);
                fFecha.ShowDialog();
                return retorno;
            }
            else if (tipo.Equals("_hora"))
            {
                frmHora fFecha = new frmHora(param, tablaEntornos);
                fFecha.ShowDialog();
                return retorno;
            }
            else if (tipo.Equals("_fechahora"))
            {
                frmFechaHora fFecha = new frmFechaHora(param, tablaEntornos);
                fFecha.ShowDialog();
                return retorno;
            }



            else if (tipo.Equals("_seleccionaruno"))
            {
                _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
                lstValores listaValores = temp.getLstValores(tablaEntornos);

                if (listaValores.listaValores.Count != 1)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando una lista como parametro,pero se recibieron más o menos", lstAtributos.getToken(0));
                    return retorno;
                }


                itemValor itemArreglo = listaValores.listaValores[0];

                if (itemArreglo.dimensiones.Count != 1)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando un arreglo de una dimensión como parametro,pero se recibieron de dimensión diferente de uno.", lstAtributos.getToken(0));
                    return retorno;
                }

                List<String> lstStringEnviar = new List<string>();

                for (int i = 0; i < itemArreglo.dimensiones[0]; i++)
                {

                    Object ol = itemArreglo.arrayValores[i].getValorParseado("cadena");

                    if (ol != null)
                    {
                        lstStringEnviar.Add((String)ol);
                    } 

                }
 

                frmSeleccionarUno fCadena = new frmSeleccionarUno(param, tablaEntornos, lstStringEnviar);
                fCadena.ShowDialog();
                return retorno;
            }

            else if (tipo.Equals("_seleccionarvarios"))
            {
                _LST_VAL temp = (_LST_VAL)getNodo("LST_VAL");
                lstValores listaValores = temp.getLstValores(tablaEntornos);

                if (listaValores.listaValores.Count != 1)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando una lista como parametro,pero se recibieron más o menos", lstAtributos.getToken(0));
                    return retorno;
                }


                itemValor itemArreglo = listaValores.listaValores[0];

                if (itemArreglo.dimensiones.Count != 1)
                {
                    tablaSimbolos.tablaErrores.insertErrorSemantic("Se estan esperando un arreglo de una dimensión como parametro,pero se recibieron de dimensión diferente de uno.", lstAtributos.getToken(0));
                    return retorno;
                }

                List<String> lstStringEnviar = new List<string>();

                for (int i = 0; i < itemArreglo.dimensiones[0]; i++)
                {

                    Object ol = itemArreglo.arrayValores[i].getValorParseado("cadena");

                    if (ol != null)
                    {
                        lstStringEnviar.Add((String)ol);
                    }

                }


                frmSeleccionarVarios fCadena = new frmSeleccionarVarios(param, tablaEntornos, lstStringEnviar);
                fCadena.ShowDialog();
                return retorno;
            }

            return retorno;
        }


    }
}
