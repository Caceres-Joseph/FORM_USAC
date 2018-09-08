using Microsoft.VisualStudio.TestTools.UnitTesting;
using _COMPI_Proyecto1.Analizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _COMPI_Proyecto1.Analizador.Tests
{
    [TestClass()]
    public class syntacticTests
    {
        
        /*public void analizarTest()
        {
            Assert.Fail();
        }*/

        [TestMethod()]
        public void testAnalizar()
        {
            syntactic sin = new syntactic();
            bool da=sin.analizar("importar (analizar.xform);"); 
            Assert.AreEqual(true,da);
        }


        [TestMethod()]
        public void testAnalizar2()
        {
            syntactic sin = new syntactic();
            bool da = sin.analizar("importar (analizar.xform);importar (analizar.xform);importar (analizar.xform);");
         
            Assert.AreEqual(true, da);
        }
        
        [TestMethod()]
        public void testAnalizar3()
        {
            syntactic sin = new syntactic();
            string entrada= System.IO.File.ReadAllText(@"entrada.txt");
            bool da = sin.analizar( entrada);
         
            Assert.AreEqual(true, da);
        }



    }
}