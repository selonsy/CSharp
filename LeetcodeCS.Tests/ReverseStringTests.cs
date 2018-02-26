using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tests
{
    [TestClass()]
    public class ReverseStringTests
    {
        [TestMethod()]
        public void MyReverseString_1Test()
        {
            ReverseString test = new ReverseString();
            string result = test.MyReverseString_1("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod()]
        public void MyReverseString_2Test()
        {
            ReverseString test = new ReverseString();
            string result = test.MyReverseString_2("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod()]
        public void MyReverseString_3Test()
        {
            ReverseString test = new ReverseString();
            string result = test.MyReverseString_3("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod()]
        public void MyReverseString_4Test()
        {
            ReverseString test = new ReverseString();
            string result = test.MyReverseString_4("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod()]
        public void Others_ReverseString_1Test()
        {
            ReverseString test = new ReverseString();
            string result = test.Others_ReverseString_1("hello");
            Assert.AreEqual("olleh", result);
        }
    }
}