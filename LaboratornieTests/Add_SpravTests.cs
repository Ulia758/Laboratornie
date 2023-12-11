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
    public class Add_SpravTests
    {
        [TestMethod()]
        public void CheckTest()
        {
            Spravochnaya s = new Spravochnaya() { Familia = "asd" };
            bool excpect = true;
            bool result = Add_Sprav.Check(s);
            Assert.AreEqual(excpect, result);
        }
        [TestMethod()]

        public void CheckNullTest()
        {
            Spravochnaya s = new Spravochnaya() { Familia = "" };
            bool excpect = false;
            bool result = Add_Sprav.Check(s);
            Assert.AreEqual(excpect, result);
        }
    }
}