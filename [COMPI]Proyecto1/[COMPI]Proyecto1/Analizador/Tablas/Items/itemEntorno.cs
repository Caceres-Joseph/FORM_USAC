using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemEntorno
    {
        public token tipo;
        public token nombre;
        public itemValor valor;
        public token  visibilidad;
        public int dimension = 0;

        public itemEntorno()
        {
            this.tipo = new token("vacio");
            this.nombre = new token("--");
            this.valor = new itemValor();
            valor.setTypeNulo();
            this.visibilidad = new token("privado");
            this.dimension = 0;
        }

        public itemEntorno(token nombre, token tipo, itemValor valor, token visibilidad, int dimension)
        {

            if (validandoTipo(tipo.valLower,valor.getTipo()))
            {

                this.tipo = tipo;
                this.nombre = nombre;
                this.valor = valor;
                this.visibilidad = visibilidad;
                this.dimension = dimension;
            }
            else
            {
                //error semantico, se está intentando asiganar un valor diferente al declarado por la variable
            }
        }

        public Boolean validandoTipo(String tipo1, String tipo2)
        {

            //el null se puede igualar a cualquier valor
            return true;
        }
    }
}
