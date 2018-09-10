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
            arbol tree = new arbol();
            string entrada = System.IO.File.ReadAllText(@"entrada.txt");
            bool salida = tree.iniciarAnalisis(entrada);

            Assert.AreEqual(true, salida);
             
        }
    }
}