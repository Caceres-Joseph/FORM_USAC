using Microsoft.VisualStudio.TestTools.UnitTesting;
using _COMPI_Proyecto1.Analizador.Arbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Arbol.Tests
{
    [TestClass()]
    public class arbolTests
    {
        [TestMethod()]
        public void iniciarAnalisisTest()
        {
            Boolean tal = 3.0 == 3;
            Console.WriteLine(tal);

            Console.WriteLine("Salida");
            var el = !(Math.Pow(23, 2) * 34 - 34 + 23 > 434 || false != !true || 23 < 23 && 23 == 21 || 34 != 35 || 34 >= 34 && 34 <= 34 % 32 * 34 + 34);
            Console.WriteLine(el);

            /*
            arbol tree = new arbol();
            string entrada = System.IO.File.ReadAllText(@"entrada.txt");
            bool salida = tree.iniciarAnalisis(entrada);

            
             */
            carro hola = new carro
            {
                nombre = "mazda"
            };
            llenando(hola);
            Console.WriteLine(hola);
            Assert.AreEqual("honda", hola.nombre);

            int a = 0;
        }


        String llenando(String carro)
        {
            return "dasdf";
        }

        void llenando(carro dato)
        {

            int a = 0;
            if (true)
            {
                a = 12;
            }
            Console.WriteLine(a);
            dato.nombre = "honda";

        }

        public int a = 0;
        void operar()
        {
            var tal1 = Math.Pow(23, 2) * 34 - 34 + 23 > 434 || false != !true || 23 < 23 && 23 == 21 || 34 != 35 || 34 >= 34 && 34 <= 34 % 32 * 34 + 34;
        }

    }

    class carro
    {

        // carro siguiente=new carro();
        public String nombre = "";


        public carro()
        {

        }
    }


}