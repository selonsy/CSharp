using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin;

namespace MyAlgorithm.Tests
{
    [TestClass()]
    public class TwoSumTests
    {
        [TestMethod()]
        public void MyTwoSum_1Test()
        {
            TwoSum temp = new TwoSum();
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] excepted = new int[] { 0, 1 };
            int[] actual = temp.MyTwoSum_1(nums, target);
            Assert.IsTrue(Utils.compareArr_1(excepted, actual));
        }

        [TestMethod()]
        public void MyTwoSum_4Test()
        {
            TwoSum temp = new TwoSum();
            int[] nums = new int[] {0,4,3,0};
            int target = 0;
            int[] excepted = new int[] { 0, 3 };
            int[] actual = temp.MyTwoSum_4(nums, target);
            Assert.IsTrue(Utils.compareArr_1(excepted, actual));
        }
    }
}