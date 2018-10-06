using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos.FuncionesNativas;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Formulario
{
    class _LLAMADA_FORMULARIO : nodoModelo
    /*
        LLAMADA_FORMULARIO.Rule = tNuevo + valId + sAbreParent + LST_VAL + sCierraParent + sPunto + tPagina + sPuntoComa
            | tNuevo + valId + sAbreParent + LST_VAL + sCierraParent + sPunto + tTodo + sPuntoComa
            | tNuevo + valId + sAbreParent + LST_VAL + sCierraParent + sPunto + tCuadriculo + sPuntoComa;
     */

    {
        public _LLAMADA_FORMULARIO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }




        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN FINAL
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public override itemRetorno ejecutar(elementoEntorno elementoEntorno)
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

            nodoModelo nodoTemp = getNodo("LST_VAL");
            _LST_VAL lstParametros = (_LST_VAL)nodoTemp;

            token nombre = lstAtributos.getToken(1);

            _ESCRIBIR_ARCHIVO.resetVariables(nombre.val);
            elementoEntorno.este.ejecutarFormulario(nombre, lstParametros.getLstValores(elementoEntorno), elementoEntorno.este.tablaEntorno.raiz);
            

            return retorno;
        }


    }
}
