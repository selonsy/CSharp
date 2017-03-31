using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    class Array
    {

        #region 数组

        /// <summary>
        /// 数组练习
        /// </summary>
        public static void MyArray()
        {

            #region 一维数组

            //声明一维数组，没有初始化，等于null 
            int[] intArray1;

            //初始化已声明的一维数组 
            intArray1 = new int[3];  //数组元素的默认值为0 
            intArray1 = new int[3] { 1, 2, 3 };
            intArray1 = new int[] { 1, 2, 3 };

            //声明一维数组，同时初始化 
            int[] intArray2 = new int[3] { 1, 2, 3 };
            int[] intArray3 = new int[] { 4, 3, 2, 1 };
            int[] intArray4 = { 1, 2, 3, 4 };
            string[] strArray1 = new string[] { "One", "Two", "Three" };
            string[] strArray2 = { "This", "is", "an", "string", "Array" };

            #endregion

            #region 二维数组

            //声明二维数组，没有初始化 
            short[,] sArray1;

            //初始化已声明的二维数组 
            sArray1 = new short[2, 2];
            sArray1 = new short[2, 2] { { 1, 1 }, { 2, 2 } };
            sArray1 = new short[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            //声明二维数组，同时初始化 
            short[,] sArray2 = new short[1, 1] { { 100 } };
            short[,] sArray3 = new short[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            short[,] sArray4 = { { 1, 1, 1 }, { 2, 2, 2 } };

            //声明三维数组，同时初始化 
            byte[,,] bArray1 = { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };

            #endregion

            #region 交错数组

            //声明交错数组，没有初始化 
            int[][] JagIntArray1;

            //初始化已声明的交错数组 
            JagIntArray1 = new int[2][] {
                new int[]{1,2},
                new int[]{3,4,5,6}
             };
            JagIntArray1 = new int[][]{
                new int[]{1,2}, 
                // new int[]{3,4,5}, 
                intArray2 //使用int[]数组变量 
            };

            //声明交错数组，同时初始化 
            int[][] JagIntArray2 = {
                new int[]{1,1,1},
                new int[]{2,2}, 
                //intArray1 
             };

            #endregion

            #region 数组的常见属性

            //数组名.Length ：返回一个整数，该整数表示该数组的所有维数中元素的总数。
            //数组名.Rank ：返回一个整数，该整数表示该数组的维数。
            //数组名.GetLength（int dimension） ：返回一个整数，该整数表示该数组的指定维(由参数dimension指定，维度从零开始)中的元素个数。
            Console.WriteLine(sArray4.Length);
            Console.WriteLine(sArray4.Rank);
            Console.WriteLine(sArray4.GetLength(1));
            Console.ReadKey();

            #endregion

            #region 数组的遍历 

            int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
            foreach (int i in numbers)
            {
                Console.WriteLine(i);  //值为4,5,6,1,2,3，-2，-1,0
            }

            int[,] numbers1 = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            foreach (int i in numbers1)
            {
                Console.Write("{0} ", i); //值为9 99 3 33 5 55
            }

            #endregion
        }

        #endregion
    }
}
