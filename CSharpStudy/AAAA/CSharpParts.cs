using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    public class CSharpParts
    {

        public static void Test()
        {
            UseParams(1, 2, 3);
            UseParams2(1, 'a', "test");
            // An array of objects can also be passed, as long as
            // the array type matches the method being called.
            int[] myarray = new int[3] { 10, 11, 12 };
            UseParams(myarray);
        }
        
        #region params
        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();
        }
        #endregion    
    }
}
