using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    /*
     * 说明:
     * 它代表了可被单独索引的对象的有序集合。
     * 它基本上可以替代一个数组。但是，与数组不同的是，您可以使用索引在指定的位置添加和移除项目，动态数组会自动重新调整它的大小。
     * 它也允许在列表中进行动态内存分配、增加、搜索、排序各项。                        
    */
    public class MyArrayList
    {
        public void Test()
        {
            ArrayList al = new ArrayList();
            al.Capacity = 5;
            Console.WriteLine("Capacity: {0} ", al.Capacity); //Capacity: 5

            Console.WriteLine("Adding some numbers:");
            al.Add(45);
            al.Add(78);
            al.Add(33);
            al.Add(56);
            al.Add(12);
            al.Add(23);
            al.Add(9);

            Console.WriteLine("Capacity: {0} ", al.Capacity); //Capacity: 10
            Console.WriteLine("Count: {0}", al.Count);        //Count: 7

            Console.Write("Content: ");
            foreach (int i in al)
            {
                Console.Write(i + " ");                       //Content: 45 78 33 56 12 23 9
            }
            Console.WriteLine();
            Console.Write("Sorted Content: ");
            al.Sort();
            foreach (int i in al)
            {                                
                Console.Write(i + " ");                       //Content: 9 12 23 33 45 56 78    
            }
            Console.WriteLine();
            Console.ReadKey();


            //总结:
            //Capacity表示ArrayList可包含的元素,默认为0,可以设置默认值,当插入的数据大于其值时,会自动翻倍.不设置的话,会随插入的数据递增,比count大1.
            //Count表示ArrayList里面实际包含的元素的个数.
        }
    }
}
