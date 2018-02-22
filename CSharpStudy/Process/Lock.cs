// <summary>  
// Copyright：Sichen International Co. Ltd.
// Author：Devin
// <summary>  
// Copyright：Sichen International Co. Ltd.
// Author：Devin
// Date：2016-10-10
// Modifyed：selonsy  
// ModifyTime：2016-10-10  
// Desc：
// 死锁测试类
// </summary> 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    
    //多个用户同时从同一个账户里面取钱,考虑并发并加锁
    public class Account
    {
        private Object thisLock = new Object();
        int balance;
        Random r = new Random();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="initial">初始余额</param>
        public Account(int initial)
        {
            balance = initial;
        }

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="amount">金额</param>
        /// <returns></returns>
        int Withdraw(int amount)
        {
            // This condition will never be true unless the lock statement
            // is commented out:
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }

            // Comment out the next line to see the effect of leaving out 
            // the lock keyword:
            lock (thisLock)
            {
                if (balance >= amount)
                {
                    Console.WriteLine("Balance before Withdrawal :  " + balance);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    balance = balance - amount;
                    Console.WriteLine("Balance after Withdrawal  :  " + balance);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }

        /// <summary>
        /// 1-100随机取钱
        /// </summary>
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
    public class AccountTest
    {
        public static void Test()
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }


    public class C1
    {
        private bool deadlocked = true;
        
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (this)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine("Foo: I am locked :(");
                    Thread.Sleep(500);
                }
            }
        }

        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("I am not locked :)");
        }
    }
    public class C1Test
    {
        public static void Test()
        {
            C1 c1 = new C1();
            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c1.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c1
            lock (c1)
            {
                //调用没有被lock的方法
                c1.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c1.LockMe(false);
            }
        }
    }
    //在t1线程中，LockMe调用了lock(this), 也就是Main函数中的c1，这时候在主线程中调用lock(c1)时，必须要等待t1中的lock块执行完毕之后才能访问c1，
    //即所有c1相关的操作都无法完成，于是我们看到连c1.DoNotLockMe()都没有执行。


    class C2
    {
        private bool deadlocked = true;
        private object locker = new object();
        
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            lock (locker)
            {
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    Console.WriteLine("Foo: I am locked :(");
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("I am not locked :)");
        }
    }
    public class C2Test
    {
        public static void Test()
        {
            C2 c2 = new C2();
            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c2.LockMe);
            t1.Start(true);
            Thread.Sleep(100);
            //在主线程中lock c1
            lock (c2)
            {
                //调用没有被lock的方法
                c2.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c2.LockMe(false);
            }
        }
    }
    //这次我们使用一个私有成员作为锁定变量(locker)，在LockMe中仅仅锁定这个私有locker，而不是整个对象。这时候重新运行程序，可以看到虽然t1出现了死锁，
    //DoNotLockMe()仍然可以由主线程访问；LockMe()依然不能访问，原因是其中锁定的locker还没有被t1释放。

}

