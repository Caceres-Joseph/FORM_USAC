using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Sentencias.Si_simplificado
{
    class _SI_SIMPLIFICADO : nodoModelo
    /*
        SI_SIMPLIFICADO.Rule = VALOR + sCierraInterrogante + E + sDosPuntos + E + sPuntoComa;
     */
    {
        public _SI_SIMPLIFICADO(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }





        /*
        |-------------------------------------------------------------------------------------------------------------------
        | Funciones ope Tipo
        |-------------------------------------------------------------------------------------------------------------------
        |  
        */
         
        public  itemValor getValor(elementoEntorno elem)
        {

            itemValor retorno = new itemValor();
            retorno.setTypeNulo();

            if (hayErrores())
                return retorno;

            if (hijos.Count != 3)
                return retorno;




            _VALOR nodoE = (_VALOR)hijos[0];
            itemValor valE = nodoE.getValor(elem,new token(""));
            Object objetoValor = valE.getValorParseado("booleano");
            Boolean condicion = false;

            if (objetoValor != null)
            {
                condicion = (Boolean)objetoValor;

            }
            else
            {
                tablaSimbolos.tablaErrores.insertErrorSemantic("La condición devulelta no es de tipo booleano,es de tipo:" + valE.getTipo(), lstAtributos.getToken(0));
                return retorno;
            }


             
            _E nodoE2 = (_E)hijos[1];
            _E nodoE3 = (_E)hijos[2];

            if (hayErrores())
                return retorno;
             

            itemValor itemVerdadero = nodoE2.getValor(elem);   
            itemValor itemFalso = nodoE3.getValor(elem); 



            

            if (condicion)
            {
                return itemVerdadero;
            }
            else
            {
                return itemFalso;
            }


             
        }

    }
}
