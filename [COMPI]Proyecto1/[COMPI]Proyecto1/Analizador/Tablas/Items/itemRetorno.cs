using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tablas.Items
{
    class itemRetorno 
    /*
    |--------------------------------------------------------------------------
    | itemRetorno
    |--------------------------------------------------------------------------
    | 0= normal
    | 1 = return;
    | 2 = break
    | 3 = continue
    | 4 = errores
    */
    {
        public int tipoRetorno = 0;
        public itemValor valor = new itemValor();

        public itemRetorno(int tipoRetorno)
        {
            this.tipoRetorno = tipoRetorno;

            valor.setTypeVacio();

        }


        /*
        |--------------------------------------------------------------------------
        | Validando tipos
        |--------------------------------------------------------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */

        public Boolean isNormal()
        {
            if (tipoRetorno == 0)
                return true;
            else
                return false;
        }

        public Boolean  isRetorno()
        {
            if (tipoRetorno == 1)
                return true;
            else
                return false;
        }

        public Boolean isRomper()
        {
            if (tipoRetorno == 2)
                return true;
            else
                return false;
        }

        public Boolean isContinuar()
        {
            if (tipoRetorno == 3)
                return true;
            else
                return false;
        }


        /*
        |--------------------------------------------------------------------------
        | Set TIPOS
        |--------------------------------------------------------------------------
        | 0= normal
        | 1 = return;
        | 2 = break
        | 3 = continue
        | 4 = errores
        */



        public void setValueRetorno(itemValor item)
        {
            tipoRetorno = 1;
            this.valor = item;


        }

    }
}
