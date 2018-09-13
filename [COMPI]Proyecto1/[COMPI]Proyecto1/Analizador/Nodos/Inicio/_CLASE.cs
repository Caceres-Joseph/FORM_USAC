using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _COMPI_Proyecto1.Analizador.Tablas;
using _COMPI_Proyecto1.Analizador.Tablas.Items;

namespace _COMPI_Proyecto1.Analizador.Nodos
{
    class _CLASE : nodoModelo
    {
        public _CLASE(string nombre, tablaSimbolos tabla) : base(nombre, tabla)
        {
        }

        //Tengo que alamacenar la clase en la tabla de simbolos
        public override void ejecutar()
        {

            //aqui tengo qu crear una clase real


            if (hayErrores())
                return;




            token nombreClase = getNombre();
            token extender = getExtender();
            token visibilidad = getVisibilidad(); 
             
            elementoClase nuevaClase = new elementoClase(nombreClase,visibilidad,extender, hijos,tablaSimbolos);
            ejecutarHijos(nuevaClase); //aqui cargo ele elmento clase 
            //ahora lo ingreso a la tabla de simbolos
            tablaSimbolos.lstClases.Add(nuevaClase);

        }
         

        public token getVisibilidad()
        {

            token retorno = new token();


            nodoModelo tempNodo = getNodo("VISIBILIDAD");
            if (tempNodo != null)
            {
                _VISIBILIDAD temp = (_VISIBILIDAD)tempNodo;
                retorno = temp.getVisibilidad();
            }
            else
            {
                retorno = new token("privado");
            }


            return retorno;
        }

       

        public token getExtender()
        {

            token retorno = new token();

            nodoModelo tempNodo = getNodo("EXTENDER");
            if (tempNodo != null)
            {
                _EXTENDER temp = (_EXTENDER)tempNodo;
                retorno = temp.getExtender();
            }
            else
            {
                retorno = new token("");
            } 

            return retorno;
        }

        public token getNombre()
        {

            token retorno = lstAtributos.getToken(1);


            return retorno;
        }
    }
}
