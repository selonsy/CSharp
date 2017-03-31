using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Devin;
using System.Threading;

namespace MyCsharpGo
{
    /// <summary>
    /// C#的异步
    /// 关键词：异步,async,await
    /// </summary>
    public class MyAsync
    {
        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();

        /// <summary>
        /// 同步测试
        /// </summary>
        /// <returns></returns>
        public static bool Test4Sync()
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/selonsy/";

            //两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）
            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            LogHelper.WriteDebug($"{url1} 的字符个数：{result1}");
            LogHelper.WriteDebug($"{url2} 的字符个数：{result2}");
                                  
            return true;
        }

        /// <summary>
        /// 异步测试
        /// </summary>
        /// <returns></returns>
        public static bool Test4ASync()
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/selonsy/";

            //两次调用 CountCharactersAsync 方法（异步下载某网站内容，并统计字符的个数）
            Task<int> t1 = CountCharactersAsync(1, url1);
            Task<int> t2 = CountCharactersAsync(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }

            //控制台输出
            LogHelper.WriteDebug($"{url1} 的字符个数：{t1.Result}");
            LogHelper.WriteDebug($"{url2} 的字符个数：{t2.Result}");
            
            return true;
        }
        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static int CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            LogHelper.WriteDebug($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = wc.DownloadString(address);
            LogHelper.WriteDebug($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharactersAsync(int id, string address)
        {
            var wc = new WebClient();
            LogHelper.WriteDebug($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = await wc.DownloadStringTaskAsync(address);
            LogHelper.WriteDebug($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");

            return result.Length;
        }


        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            LogHelper.WriteDebug($"id = {id} 的 ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");            
        }
    }

    /// <summary>
    /// Task_Study
    /// </summary>
    public class MyTask
    {
        public void MyMethodA(ref string s)
        {
            for (int i = 0; i < 50; i++)
            {
                s +=i.ToString();
            }
        }
        public void MyMethodB(ref string s)
        {
            for (int i = 0; i < 50; i++)
            {
                s += (-i).ToString();
            }
        }
        public void MyMethodC()
        {
        }

        /// <summary>
        /// 线程池,异步执行
        /// </summary>
        public string ThreadPoolOneByOne()
        {
            string testStr = string.Empty;
            using (ManualResetEvent m1 = new ManualResetEvent(false))
            using (ManualResetEvent m2 = new ManualResetEvent(false))
            {                
                ThreadPool.QueueUserWorkItem(delegate
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Console.WriteLine(i);
                    }
                    m1.Set();
                    Console.WriteLine("M1 end !");
                });
                ThreadPool.QueueUserWorkItem(delegate
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Console.WriteLine(-i);
                    }
                    m2.Set();
                    Console.WriteLine("M2 end !");
                });
                WaitHandle.WaitAll(new WaitHandle[] { m1, m2, });
            }
            return testStr;
        }

        /// <summary>
        /// Task类,异步执行
        /// </summary>
        public void TaskTogether1()
        {
            Task t1 = new Task(delegate
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(i);
                }
            });
            Task t2 = new Task(delegate {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(-i);
                }
            });
            t2.Start();
            t1.Start();
            Task.WaitAll(t1, t2);
            //输出 正负数间隔 无明显规律
        }
        public void TaskTogether2()
        {

            Task t1 = Task.Factory.StartNew(delegate {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(i);
                }
            });
            Task t2 = Task.Factory.StartNew(delegate {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(-i);
                }
            });

            //Task.WaitAll(t1, t2);//输出 正负数间隔 无明显规律
            t1.Wait();
            t2.Wait(); //输出 正负数间隔 无明显规律
        }
        public string TaskTogether3()
        {
            string testStr = string.Empty;
            Task t1 = Task.Factory.StartNew(delegate { MyMethodA(ref testStr); });
            Task t2 = Task.Factory.StartNew(delegate { MyMethodB(ref testStr); });
            t1.Wait();
            t2.Wait();
            return testStr;
        }        
        public string TaskTogether4()
        {
            string testStr = string.Empty;
            Task t1 = Task.Factory.StartNew(delegate { MyMethodA(ref testStr); });
            Task t2 = Task.Factory.StartNew(delegate { MyMethodB(ref testStr); });
            Task.WaitAll(t1, t2);
            return testStr;
        }
       
        /// <summary>
        /// 创建Task
        /// </summary>
        public void CreateTask()
        {
            Task t1 = new Task(MyMethodC);

            //Task.Factory 是对Task进行管理，调度管理这一类的.
            Task t2 = Task.Factory.StartNew(MyMethodC);
        }

        /// <summary>
        /// 异步运行
        /// </summary>
        static string MyMethod1(ref string s)
        {
            for (int i = 0; i < 5; i++)
            {
                s += i.ToString();                
                Thread.Sleep(1000);
            }
            return s;
        }
        public string TaskAsync()
        {
            string testStr = string.Empty;
            //Task t1 = new Task(delegate { MyMethod1(ref testStr); }); //无返回值
            Task<string> t1 = new Task<string>(delegate { return MyMethod1(ref testStr); }); //有返回值
            t1.Start();
            testStr += "主线程代码运行结束"; //这句话先输出来.因为我们没有调用Wait 所以是异步执行的~
            t1.Wait(); //等待Task完成执行过程,不加这句话的话,就直接跑了,等不到 MyMethod1 执行完毕.            
            //return testStr; //输出:主线程代码运行结束01234
            return testStr + t1.Result; //输出:主线程代码运行结束01234主线程代码运行结束01234
        }

        /// <summary>
        /// 异常测试
        /// </summary>
        static void MyMethod2()
        {
            throw new Exception("Task异常测试");
        }
        public void ExceptionTest()
        {
            Task t1 = new Task(MyMethod2);
            t1.Start();
            t1.Wait();       //这里执行会报错,因为Task的异常还会重新抛到Wait和AllWait中，我们可以进行方便的捕获这些异常.
            Console.WriteLine("主线程代码运行结束");
            Console.ReadLine();
        }

        /// <summary>
        /// Task返回值
        /// </summary>
        public void TaskReturn()
        {
            //返回值可以是任意的类型，因为是个泛型嘛
            Task<string> t1 = Task.Factory.StartNew(() => "测试"); //异步的方法必须要有返回值
            t1.Wait();
            Console.WriteLine(t1.Result); //输出 "测试";
            Console.ReadLine();
        }
    }    
}
