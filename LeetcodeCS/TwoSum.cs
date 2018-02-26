using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm
{
    //LeetCode:1 Two Sum
    //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    //You may assume that each input would have exactly one solution.

    //Example:
    //Given nums = [2, 7, 11, 15], target = 9,

    //Because nums[0] + nums[1] = 2 + 7 = 9,
    //return [0, 1].

    public class TwoSum
    {
        //首先,使用最简单(动脑最少)的办法,即双重for循环
        public int[] MyTwoSum_1(int[] nums, int target)
        {
            // Accepted
            // RunTime:632ms
            // Beats 19.33% csharper
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        public int[] MyTwoSum_4(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length ; i++)
            {
                if (nums[i] > target) continue;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] > target) continue;
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }
            return null;
        }
    }
}
