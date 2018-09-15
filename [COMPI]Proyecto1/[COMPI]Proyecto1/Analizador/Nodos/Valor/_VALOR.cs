using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VALOR : nodoModelo
    {

        public elementoEntorno elemEntorno;
        public itemEntorno itEntorno;


        

        public _VALOR(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        public override void ejecutar(elementoEntorno elem, itemEntorno item)
        {

            if (hayErrores())
                return;

            this.elemEntorno = elem;
            this.itEntorno = item;


            //ejecutarHijos(elem, item);

            //this.elemEntorno = elem;
            //this.itEntorno = item;
            //elem es la tabla de simbolos
            //item es donde tengo que guardar el valor prro

            reconocerProduccion();


        }



        public void reconocerProduccion()
        {

            if (hijos.Count > 0)
            {
                nodoModelo hijo = hijos[0];
                switch (hijo.nombre)
                {
                    case "LST_VAL":
                        println(itEntorno.nombre.valLower+"-> tNuevo + valId + sAbreParent + LST_VAL + sCierraParent");

                        break;
                    case "TIPO":
                        println(itEntorno.nombre.valLower + "-> tNuevo + TIPO + LST_CORCHETES_VAL");
                        break;
                    case "LST_LLAVES_VAL":
                        println(itEntorno.nombre.valLower + "->sIgual + LST_LLAVES_VAL");
                        break;
                    case "E":
                        //me tiene que retornar un valor jejeje

                       // println(itEntorno.nombre.valLower + "->E");
                        _E ope =(_E)hijo;
                        itemValor te= ope.getValor();
                        itEntorno.valor = te;

                        println(itEntorno.nombre.valLower+"->"+itEntorno.tipo.valLower);
                        te.imprimirVariable();
                        ///aquí ya trea nombre la variable
                        ///


                       // println("\tResultado:"+te.getTipo());
                        //ejecutarHijos(elemEntorno, itEntorno);
                        break;


                    default:
                        println(itEntorno.nombre.valLower + "->No se reconoció la producción :(");
                        break;
                }

            }
            else
            {
                println(itEntorno.nombre.valLower + "->sIgual + tNulo");
            }

        }


    }
}