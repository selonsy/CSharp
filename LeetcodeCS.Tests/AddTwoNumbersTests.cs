using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tests
{
    [TestClass()]
    public class AddTwoNumbersTests
    {
        [TestMethod()]
        public void MyAddTwoNumbersTest()
        {
            int[] input1 = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            ListNode node1 = AddTwoNumbers.GetListNode(input1);
            int[] input2 = { 1 };
            ListNode node2 = AddTwoNumbers.GetListNode(input2);

            int[] output = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            ListNode expected = AddTwoNumbers.GetListNode(output);

            ListNode actual = new AddTwoNumbers().MyAddTwoNumbers(node1, node2);

            bool tempStr = true;
            while (expected != null && actual != null)
            {
                if (expected.val == actual.val)
                {
                    expected = expected.next;
                    actual = actual.next;
                    continue;
                }
                else
                {
                    tempStr = false;
                    break;
                } 
            }
            Assert.IsTrue(tempStr);
        }
    }

    [TestClass]
    public class zhiAyinyong
    {
        [TestMethod]
        public void ZhiTest()
        {
            int a = 10;
            Zhi(a);
            Assert.AreEqual(11, a);
        }
        public void Zhi(int a)
        {
            a++;
        }

        [TestMethod]
        public void YinyongTest()
        {
            List<int> list = new List<int>();
            Yinyong(list);
            Assert.AreEqual(1, list[0]);
        }
        public void Yinyong(List<int> list)
        {
            list.Add(1);
        }
    }
}