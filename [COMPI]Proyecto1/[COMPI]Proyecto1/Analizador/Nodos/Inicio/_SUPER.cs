using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Inicio
{
    class _SUPER : nodoModelo
    /*
     * SUPER.Rule = sAbreParent + LST_VAL + sCierraParent + sPuntoComa;
     */
    {
        public _SUPER(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
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



            nodoModelo nodoTemp = getNodo("LST_VAL");
            _LST_VAL lstParametros = (_LST_VAL)nodoTemp;

            // lstValores parametros, elementoEntorno tablaEntorno, token linea
            tablaEntornos.este.ejecutarConstructorHeredado(lstParametros.getLstValores(tablaEntornos), tablaEntornos, lstAtributos.getToken(0));
             
            return retorno;
             
        }
 


    }
}
