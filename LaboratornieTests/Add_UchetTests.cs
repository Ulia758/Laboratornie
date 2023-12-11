using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratornie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornie.Tests
{
    [TestClass()]
    public class Add_UchetTests
    {
        [TestMethod()]
        public void ChekTest()
        {
            Uchetnaya s = new Uchetnaya() { Tabelnyi_nomer = 1 };
            bool excpect = true;
            bool result = Add_Uchet.Chek(s);
            Assert.AreEqual(excpect, result);
        }
    }
}