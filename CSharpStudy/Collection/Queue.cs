using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    /*
     * 队列（Queue）代表了一个先进先出的对象集合。
     * 当您需要对各项进行先进先出的访问时，则使用队列。
     * 当您在列表中添加一项，称为入队，当您从列表中移除一项时，称为出队。
     */
    public class MyQueue
    {
        public void Test()
        {
            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            q.Enqueue('V');
            q.Enqueue('H');
            Console.WriteLine("Current queue: ");
            foreach (char c in q)
                Console.Write(c + " ");
            Console.WriteLine();
            Console.WriteLine("Removing some values ");
            char ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            ch = (char)q.Dequeue();
            Console.WriteLine("The removed value: {0}", ch);
            Console.ReadKey();

            /*
             结果:
            Current queue: 
            A M G W 
            Current queue: 
            A M G W V H 
            Removing values
            The removed value: A
            The removed value: M
             */
        }
    }
}
