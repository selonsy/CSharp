using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm
{
    //3.Longest Substring Without Repeating Characters
    //Given a string, find the length of the longest substring without repeating characters.
    //Examples:
    //Given "abcabcbb", the answer is "abc", which the length is 3.
    //Given "bbbbb", the answer is "b", with the length of 1.
    //Given "pwwkew", the answer is "wke", with the length of 3. 

    //Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

    public class LSWRC
    {
        //LeetCode执行超时
        public int LengthOfLongestSubstring(string s ,out string str)
        {
            str = string.Empty;
            int result = 0;
            string ls = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                ls = s[i].ToString();
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (ls.IndexOf(s[j]) == -1)
                    {
                        ls += s[j].ToString();
                    }
                    else
                    {
                        break;
                    }
                }
                if (ls.Length > result)
                {
                    result = ls.Length;
                    str = ls;
                } 
            }            
            return result;
        }

        public int LengthOfLongestSubstring_2(string s)
        {
            //ASCII has 256 characters(扩展版本)
            //BitArray 管理位值的压缩数组，这些值以布尔值的形式表示，其中 true 表示此位为开 (1)，false 表示此位为关 (0)。
            BitArray map = new BitArray(256, false);
            int i = 0, j = 0;
            int max = 0;
            int n = s.Length;

            while (j < n)
            {
                if (map[s[j]])
                {
                    max = Math.Max(max, j - i);
                    //remove all the pervious character from map before duplicate
                    while (s[i] != s[j])
                    {
                        map[s[i]] = false;
                        i++;
                    }
                    i++;
                    j++;
                }
                else
                {
                    map[s[j]] = true;
                    j++;
                }
            }
            max = Math.Max(max, j - i);
            return max;
        }

        public int LengthOfLongestSubstring_3(string s)
        {
            int length = 0;
            for (int start = 0; start < s.Length; start++)
            {
                int i = start;
                var dictionary = new Dictionary<char, int>();
                while (i < s.Length && !dictionary.ContainsKey(s[i]))
                {
                    dictionary.Add(s[i++], 1);
                }
                if (i - start > length)
                {
                    length = i - start;
                }
            }
            return length;
        }

        public int LengthOfLongestSubstring_4(string s)
        {
            int length = 0;
            var dictionary = new Dictionary<char, int>();

            for (int start = 0, i = start; start < s.Length; start++)
            {
                while (i < s.Length && !dictionary.ContainsKey(s[i]))
                {
                    dictionary.Add(s[i++], i - 1);
                }
                if (i - start > length)
                {
                    length = i - start;
                }

                // hash table contains s[i]
                if (i < s.Length)
                {
                    var index = dictionary[s[i]];

                    for (int j = start; j <= index; j++)
                    {
                        dictionary.Remove(s[j]);
                    }

                    start = index;
                }
            }

            return length;
        }

        public int LengthOfLongestSubstring_5(string s)
        {
            var res = 0;
            Dictionary<char,int> dict = new Dictionary<char,int>();
            var start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    start = Math.Max(start, dict[s[i]] + 1);
                    dict[s[i]] = i;
                }
                else
                {
                    dict.Add(s[i], i);
                }

                res = Math.Max(res, i - start + 1);
            }

            return res;
        }
    }
}
