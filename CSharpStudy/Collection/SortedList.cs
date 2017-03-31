using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    public class MySortedList
    {
        /*
         * SortedList 类代表了一系列按照键来排序的键/值对，这些键值对可以通过键和索引来访问。
         * 排序列表是数组和哈希表的组合。它包含一个可使用键或索引访问各项的列表。
         * 如果您使用索引访问各项，则它是一个动态数组（ArrayList），
         * 如果您使用键访问各项，则它是一个哈希表（Hashtable）。
         * 集合中的各项总是按键值排序。
         */
        public void Test()
        {
            SortedList sl = new SortedList();

            sl.Add("001", "Zara Ali");
            sl.Add("002", "Abida Rehman");
            sl.Add("003", "Joe Holzner");
            sl.Add("004", "Mausam Benazir Nur");
            sl.Add("005", "M. Amlan");
            sl.Add("006", "M. Arif");
            sl.Add("007", "Ritesh Saikia");

            if (sl.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                sl.Add("008", "Nuha Ali");
            }

            // 获取键的集合 
            ICollection key = sl.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + sl[k]);
            }
            
            //输出:
            //001: Zara Ali
            //002: Abida Rehman
            //003: Joe Holzner
            //004: Mausam Banazir Nur
            //005: M.Amlan
            //006: M.Arif
            //007: Ritesh Saikia
            //008: Nuha Ali
        }
    }
}
