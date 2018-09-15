using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _VAL : nodoModelo
    {
         
        public _VAL(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {

        }


        public override void ejecutar(elementoEntorno elem)
        {
            base.ejecutar(elem);
        }


        public override void ejecutar(elementoEntorno elem, itemEntorno item)
        {



            ejecutarHijos(elem, item);

            //this.elemEntorno = elem;
            //this.itEntorno = item;
            //elem es la tabla de simbolos
            //item es donde tengo que guardar el valor prro

            //reconocerProduccion();

        }







    }
}
