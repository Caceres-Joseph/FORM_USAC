using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.Valor.Operelacional;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.Caso
{
    class _CUERPO_CASE : nodoModelo
    /*
            CUERPO_CASE.Rule = E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave + CUERPO_CASE
                   | E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave
                   | tDefecto + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave;
     */
    {
        public _CUERPO_CASE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */
        public override itemRetorno ejecutar(elementoEntorno elementoEntor)
        {
            itemRetorno retorno = new itemRetorno(0);
            return retorno;

        }

        public itemRetorno ejecutar(elementoEntorno elementoEntor, itemValor expresion)
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
            itemRetorno retorno = new itemRetorno(0);
            if (hayErrores())
                return retorno;



            if (hijos.Count == 3)
            /*
            |---------------------------- 
            |  E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave + CUERPO_CASE
            */
            {
                _E nodoE = (_E)getNodo("E");
                itemValor valE = nodoE.getValor(elementoEntor);

                IgualQue igual = new IgualQue(new _E("temp1", tablaSimbolos), new _E("temp2", tablaSimbolos), tablaSimbolos, new token("="));
                itemValor resultado = igual.opIgualacion(expresion, valE, "IGUALACION", elementoEntor);

                Object objetoValor = resultado.getValorParseado("booleano");
                Boolean condicion = false;

                if (objetoValor != null)
                {
                    condicion = (Boolean)objetoValor;
                    if (condicion)
                    {
                        _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                        itemRetorno break1 = nodoCuerpo.ejecutar(elementoEntor);
                        //voy a revisar si no hay break prro
                        if (break1.isRomper())
                        {
                            println("es romper");
                            itemRetorno ret2 = new itemRetorno(0);
                            //asi retorno un normal
                            return ret2;
                            //aquí rompo prro
                        }
                        else
                        {
                            println("no es romper");
                            _CUERPO_CASE cuerpoCase = (_CUERPO_CASE)getNodo("CUERPO_CASE");
                            return cuerpoCase.ejecutar(elementoEntor, expresion);
                        }

                    }
                    else
                    {
                        println("ejecutando cuerpo clase");
                        _CUERPO_CASE sino_si = (_CUERPO_CASE)getNodo("CUERPO_CASE");
                        return sino_si.ejecutar(elementoEntor, expresion);
                    }
                }
                else
                {
                    println("E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave + CUERPO_CASE->  No se retorno un boolenano en la igualación");
                    return retorno;
                }


            }
            else if (hijos.Count == 2)
            /*
            |---------------------------- 
            |   E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave
            */
            {
                _E nodoE = (_E)getNodo("E");
                itemValor valE = nodoE.getValor(elementoEntor);

                IgualQue igual = new IgualQue(new _E("temp1", tablaSimbolos), new _E("temp2", tablaSimbolos), tablaSimbolos, new token("="));
                itemValor resultado = igual.opIgualacion(expresion, valE, "IGUALACION", elementoEntor);

                Object objetoValor = resultado.getValorParseado("booleano");
                Boolean condicion = false;

                if (objetoValor != null)
                {
                    condicion = (Boolean)objetoValor;
                    if (condicion)
                    {
                        _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                        return nodoCuerpo.ejecutar(elementoEntor);

                    }
                    else
                    {
                        return retorno;
                    }
                }
                else
                {
                    println(" E + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave ->  No se retorno un boolenano en la igualación");
                    return retorno;
                }
            }
            else if (hijos.Count == 1)
            /*
            |---------------------------- 
            |  tDefecto + sDosPuntos + sAbreLlave + LST_CUERPO + sCierraLlave;
            */
            {
                 
                _LST_CUERPO nodoCuerpo = (_LST_CUERPO)getNodo("LST_CUERPO");
                return nodoCuerpo.ejecutar(elementoEntor);

            }
            else
            {
                return retorno;
            }


        }
    }
}
