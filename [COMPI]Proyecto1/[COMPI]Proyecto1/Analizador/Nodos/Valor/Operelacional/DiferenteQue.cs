using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos.Valor.Operelacional
{
    class DiferenteQue : opModelo
    {
        public DiferenteQue(nodoModelo hijo1, nodoModelo hijo2, tablaSimbolos tabla, token signo) : base(hijo1, hijo2, tabla, signo)
        {
        }

        public itemValor opDiferenciacion(String ambito)
        {
            IgualQue dif = new IgualQue(hijo1, hijo2, tabla, signo);

            itemValor retorno = dif.opIgualacion(ambito);
            if (retorno.isTypeBooleano())
            {
                if (retorno.getBooleano())
                {
                    retorno.setValue(false);
                    return retorno;
                }
                else
                {
                    retorno.setValue(true);
                    return retorno;
                }
            }
            else
            {
                tabla.tablaErrores.insertErrorSemantic("No se recibió un booleano en" + ambito, signo);
                return retorno;
            }

        }

    }
}
