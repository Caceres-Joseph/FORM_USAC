using _COMPI_Proyecto1.Analizador.Tablas.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Listas
{
    class lstValores
    {

        public List<itemValor> listaValores;

        public lstValores()
        {
            listaValores = new List<itemValor>();
        }

        public void insertar(itemValor param)
        {
            listaValores.Add(param);
        }

        public itemValor getItemValor(int i)
        {
            if (listaValores.Count > i)
            {
                return listaValores[i];
            }
            else
            {
                return new itemValor();
            }
        }

        public String getCadenaParam()
        {
            String retorno = "";
            int con = 0;
            foreach (itemValor temp in listaValores)
            {

                String tipo = temp.getTipo();

                if (tipo.Equals("objeto"))
                {
                    tipo = "Objeto."+temp.nombreObjeto;
                }

                if (con == 0)
                {
                    retorno += tipo;
                }
                else
                {
                    retorno += "," + tipo;
                }

                con++;

            }


            return retorno;
        }
    }
}
