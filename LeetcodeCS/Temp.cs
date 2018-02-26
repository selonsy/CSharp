using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithmStudy
{
    public class TempTest
    {
        /// <summary>
        /// 求值，递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MyTest(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return n * MyTest(--n);
            }
        }

        /// <summary>
        /// 1+x+x^2+x^3+...+x^n
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MyTest1(int x, int n)
        {
            int temp = x + 1;
            for (int i = 0; i < n - 1; i++)
            {
                temp = temp * x + 1;
            }
            return temp;
        }
    }

    public class RandHelper
    {
        /// <summary>
        /// 私有种子
        /// </summary>

        private Random seed;
        #region 构造函数

        public RandHelper()
        {
            seed = new Random(new Random().Next(10000));
        }

        #endregion

       

        /// <summary>
        /// 原始字符串 
        /// </summary>
        private string originalStr = @"0123456789abcdefghigklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 随机类型
        /// </summary>
        public enum RandType
        {
            数字 = 1,
            小写字母 = 2,
            大写字母 = 3,
            大小写字母 = 4,
            小写字母加数字 = 5,
            大写字母加数字 = 6,
            大小写字母加数字 = 7
        }

        /// <summary>
        /// 获取随机值
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetMix(Random rnd, RandType type)
        {
            string result = string.Empty;

            switch (type)
            {
                case RandType.数字:
                    result = rnd.Next(10).ToString();
                    break;
                case RandType.小写字母:
                    result = originalStr.Substring(10 + rnd.Next(26), 1);
                    break;
                case RandType.大写字母:
                    result = originalStr.Substring(36 + rnd.Next(26), 1);
                    break;
                case RandType.大小写字母:
                    result = originalStr.Substring(10 + rnd.Next(52), 1);
                    break;
                case RandType.小写字母加数字:
                    result = originalStr.Substring(0 + rnd.Next(36), 1);
                    break;
                case RandType.大写字母加数字:
                    result = originalStr.Substring(0 + rnd.Next(36), 1).ToUpper();
                    break;
                case RandType.大小写字母加数字:
                    result = originalStr.Substring(0 + rnd.Next(61), 1);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取指定长度的随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="type">随机类型</param>
        /// <returns></returns>
        public string GetRandStr(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(GetMix(seed, RandType.大小写字母加数字));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取指定长度的随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="num">数字占的个数</param>
        /// <returns></returns>
        public string GetRandStr(int length, int num)
        {
            //参数校验
            StringBuilder sb = new StringBuilder();            
            string result = string.Empty;
            for (int i = 0; i < num; i++)
            {
                result = result + GetMix(seed, RandType.数字)+','; 
            }
            for (int i = 0; i < length-num; i++)
            {
                result = result+ GetMix(seed, RandType.大小写字母) + ',';
            }
            string[] tempArray = ArrayLuanXu(result.TrimEnd(',').Split(','));

            return string.Join("",tempArray);
        }

        /// <summary>
        /// 数组乱序
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[] ArrayLuanXu(string[] array)
        {
            byte[] keys = new byte[array.Length];
            (new Random()).NextBytes(keys); //用随机数填充指定字节数组的元素
            Array.Sort(keys, array);
            return array;
        }

        #region else

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="strLength">字符串长度</param>
        /// <param name="Seed">随机函数种子值</param>
        /// <returns>指定长度的随机字符串</returns>
        public static string GetRandCode(int strLength, params int[] Seed)
        {
            string strSep = ",";
            char[] chrSep = strSep.ToCharArray();
            string strChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z"
             + ",A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] aryChar = strChar.Split(chrSep, strChar.Length);
            string strRandom = string.Empty;
            Random Rnd;
            if (Seed != null && Seed.Length > 0)
            {
                Rnd = new Random(Seed[0]);
            }
            else
            {
                Rnd = new Random();
            }
            //生成随机字符串
            for (int i = 0; i < strLength; i++)
            {
                strRandom += aryChar[Rnd.Next(aryChar.Length)];
            }
            return strRandom;
        }

        #endregion
    }
}
