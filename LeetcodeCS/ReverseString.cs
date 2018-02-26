using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm
{

    //LeetCode:344 Reverse String
    //Write a function that takes a string as input and returns the string reversed.
    //Example:
    //Given s = "hello", return "olleh".


    //第一次做的需要注意的地方:
    //1.placeholder里面的东西不要动,包括类名和方法名.
    //2.先点击Run Code试运行程序,确认OK了再点击Submit提交.

    public class ReverseString
    {
        public string MyReverseString_1(string s)
        {
            // Time Limit Exceeded
            char[] arr = s.ToCharArray();
            string result = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                result = arr[i] + result;
            }
            return result;
        }

        public string MyReverseString_2(string s)
        {
            // Time Limit Exceeded      
            string result = string.Empty;
            foreach (var item in s)
            {
                result = item + result;
            }
            return result;
        }

        public string MyReverseString_3(string s)
        {
            // Time Limit Exceeded
            string result = string.Empty;
            IEnumerable<char> charArray = s.Reverse<char>();
            foreach (var item in charArray)
            {
                result += item.ToString();
            }
            return result;
        }

        public string MyReverseString_4(string s)
        {
            // Time Limit Exceeded
            StringBuilder result = new StringBuilder();
            foreach (var item in s)
            {
                result.Insert(0, item.ToString(), 1);
            }
            return result.ToString();
        }

        public string Others_ReverseString_1(string s)
        {
            // Accepted
            // RunTime:140ms
            // Beats 58.94% csharper
            if (s == null || s.Length <= 0)
            {
                return s;
            }
            int length = s.Length;
            StringBuilder resultBuilder = new StringBuilder();
            for (int i = length - 1; i >= 0; i--)
            {
                resultBuilder.Append(s[i]);
            }
            return resultBuilder.ToString();
        }
    }

}
