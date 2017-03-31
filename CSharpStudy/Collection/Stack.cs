using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    /*
     * 堆栈（Stack）代表了一个后进先出的对象集合。当您需要对各项进行后进先出的访问时，则使用堆栈。
     * 当您在列表中添加一项，称为推入元素，当您从列表中移除一项时，称为弹出元素。
     * 
     */
    public class MyStack
    {
        public void Test()
        {
            Stack st = new Stack();

            st.Push('A');
            st.Push('M');
            st.Push('G');
            st.Push('W');

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            st.Push('V');
            st.Push('H');
            Console.WriteLine("The next poppable value in stack: {0}",
            st.Peek());
            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Removing values ");
            st.Pop();
            st.Pop();
            st.Pop();

            Console.WriteLine("Current stack: ");
            foreach (char c in st)
            {
                Console.Write(c + " ");
            }
            Console.ReadKey();

            /* 
                结果:
                Current stack: 
                W G M A
                The next poppable value in stack: H
                Current stack: 
                H V W G M A
                Removing values
                Current stack: 
                G M A 
             */
        }
    }
}
