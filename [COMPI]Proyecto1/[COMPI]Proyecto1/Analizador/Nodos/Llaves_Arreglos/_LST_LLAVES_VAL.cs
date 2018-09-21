using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _LST_LLAVES_VAL : nodoModelo
    /*
    |--------------------------------------------------------------------------
    |  LST_LLAVES_VAL.Rule = MakePlusRule(LST_LLAVES_VAL, sComa, LLAVES_VAL_P);
    |-------------------------------------------------------------------------- 
    */
    {

        public List<int> lstDimensiones = new List<int>();
        public Dictionary<int, itemValor> diccionario = new Dictionary<int, itemValor>();
        private object tabla;

        public _LST_LLAVES_VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }


        public void getArray(token tipo, elementoEntorno elemEntor)
        {


            if (hayErrores())
                return;

            Dictionary<int, itemValor> diccionario = new Dictionary<int, itemValor>();
            List<int> dimensioenes = new List<int>();
            int dimensionActual = 0;

            foreach (nodoModelo temp in hijos)
            {
                _LLAVES_VAL_P llaves = (_LLAVES_VAL_P)temp;
                llaves.getArray(diccionario, dimensioenes, tipo, dimensionActual, elemEntor);

            }

            //this.imprimiendoLstInt(dimensioenes);



            this.diccionario = diccionario;
            this.lstDimensiones = dimensioenes;

        }

        public void imprimiendoLstInt(List<int> lstDimensiones)
        {
            println("imprimienodLStInt");
            foreach (int entero in lstDimensiones)
            {
                println(entero.ToString());
            }
        }


        public void getArray2(Dictionary<int, itemValor> diccionario, List<int> dimensioenes, token tipo, int dimensionActual, elementoEntorno elemEntor)
        {
            if (hayErrores())
                return;
            //hay que contar cuántos hijos tiene, esa es una dimensión

            foreach (nodoModelo temp in hijos)
            {
                _LLAVES_VAL_P llaves = (_LLAVES_VAL_P)temp;

                if (dimensionActual > dimensioenes.Count)
                //voy a corroborar si ya hay un indice ingresado
                {
                    dimensioenes.Add(hijos.Count);
                }
                else
                //indica que el indice ya esta, hay que corroborar si tiene la misma cantidad de hijos
                // dimensionActual-1
                {
                    if (dimensioenes[dimensionActual - 1] != hijos.Count)
                    //hay problema con la cantidad de hijos
                    {

                        tablaSimbolos.tablaErrores.insertErrorSemantic("No coincide el tamaño de la dimension: " + dimensionActual + " en la matriz de tipo: " + tipo.val, tipo);
                    }

                }

                llaves.getArray(diccionario, dimensioenes, tipo, dimensionActual, elemEntor);

            }



            return;
        }




    }
}
