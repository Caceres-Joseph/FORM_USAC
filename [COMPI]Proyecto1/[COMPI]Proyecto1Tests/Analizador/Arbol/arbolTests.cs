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
        String hola;

        [TestMethod()]
        public void dowhilte()
        {
            int x = 0;
            do
            {
                Console.WriteLine(x);
                x++;
            } while (x < 10);


       

        }

        
        public void iniciarAnalisisTest()
        {

            switch (1)
            {
                case 1:

                    /*switch (2)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                    }*/
                    

                case 2:
                    break;

                default:

                    break;
            }

            int[] arr2 = { 3, 2 };
            int[][] arr = { arr2, arr2};

            int aess= arr.GetLength(0);
            Console.WriteLine("dimension1:" + aess);
            Console.WriteLine("dimension2:" + arr[0].GetLength(0));


            Dictionary<int, String> dictou = new Dictionary<int, string>();
            List<int> lista = new List<int>();
        carro car0 = new carro();

            dict(lista);
            Console.WriteLine("diccionario->" + lista[1]);
    
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

            asdf()[1] = "23";
            int indi = 0;
         
        }

        public String[] asdf()
        {
            String[] temp = { "uno", "dos" };
            return temp;
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

        void dict(List<int> lista)
        {
            lista.Add( 34);
            lista.Add(34);
        }
    }


    class carro
    {

        // carro siguiente=new carro();
        public String nombre = "";
        public Dictionary<int, String> dicto = new Dictionary<int, string>();

        public carro()
        {
            //dicto.Add(0, "holadicto_carro");
        }
    }


}