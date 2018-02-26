using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm
{

    //You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

    //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    //Output: 7 -> 0 -> 8

    //中文翻译版:假设有两个数字，分别是342和465。这两个数字加起来是807.然而存储的时候是以逆序存储的。比如342以链表存储为2→4→3,465以链表存储为5→6→4。
    /**
    * Definition for singly-linked list.
    * public class ListNode {
    *     public int val;
    *     public ListNode next;
    *     public ListNode(int x) { val = x; }
    * }
    */

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class AddTwoNumbers
    {

        public ListNode MyAddTwoNumbers(ListNode l1, ListNode l2)
        {
            StringBuilder tempStr1 = new StringBuilder();
            StringBuilder tempStr2 = new StringBuilder();
            while (l1 != null)
            {
                tempStr1.Insert(0, l1.val);
                l1 = l1.next;
                continue;
            }
            while (l2 != null)
            {
                tempStr2.Insert(0, l2.val);
                l2 = l2.next;
                continue;
            }

            double sum1 = 0;
            double sum2 = 0;
            double.TryParse(tempStr1.ToString(), out sum1);
            double.TryParse(tempStr2.ToString(), out sum2);
            double sum3 = sum1 + sum2;

            char[] strSums = sum3.ToString("0").Reverse().ToArray();
            ListNode result = new ListNode(-1);
            ListNode temp = result;
            for (int i = 0; i < strSums.Length; i++)
            {
                result.val = Convert.ToInt32(strSums[i].ToString());
                if (i != strSums.Length - 1)
                {
                    ListNode B = new ListNode(-1);
                    result.next = B;
                    result = B;
                }
            }
            return temp;
        }

        /// <summary>
        /// 转换输入
        /// </summary>
        /// <param name="strSums"></param>
        /// <returns></returns>
        public static ListNode GetListNode(int[] strSums)
        {
            ListNode result = new ListNode(-1);
            ListNode temp = result;
            for (int i = 0; i < strSums.Length; i++)
            {
                result.val = Convert.ToInt32(strSums[i].ToString());
                if (i != strSums.Length - 1)
                {
                    ListNode B = new ListNode(-1);
                    result.next = B;
                    result = B;
                }
            }
            return temp;
        }
    }
}
