using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Nodos;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    class lstConstructores : lstPolimorfismo
    {
        public lstConstructores(tablaSimbolos tabla, string nombre) : base(tabla, nombre)
        {
        }

        /*
        |-------------------------------------------------------------------------------------------------------------------
        | EJECUCIÓN DE METODO  CONSTRUCTOR
        |-------------------------------------------------------------------------------------------------------------------
        |
        */

        public void ejecutarMetodo(token nombre, lstValores parametros, elementoEntorno tablaEntorno)
        {
            //aqui es donde tengo que buscar si existe 
            Console.WriteLine("ejecutando Metodo:" + nombre.val);
            elementoPolimorfo temp = getElementoPolimorfo2(nombre, parametros);
            if (temp != null)
            //neuvo entorno
            {
                elementoEntorno hijo1 = new elementoEntorno(tablaEntorno, tabla, "main", tablaEntorno.este);
                guardarParametrosEnLaTabla(temp.lstParametros, parametros, hijo1);


                if (temp.LST_CUERPO.nombre.Equals("LST_CUERPO"))
                /*
                |---------------------------- 
                |  Ejecutando el cuerpo del metodo
                |-----------------------
                | Los constructores no retornan nada
                */
                {
                    _LST_CUERPO val = (_LST_CUERPO)temp.LST_CUERPO;
                    val.ejecutar(hijo1);

                }

            }
        }

    }
}
