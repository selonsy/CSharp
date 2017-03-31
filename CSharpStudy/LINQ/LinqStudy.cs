using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsharpGo
{
    #region Linq介绍以及C#3.0的语言功能


    /// <summary>
    /// Linq
    /// </summary>
    public class LinqStudy
    {

        /// <summary>
        /// Linq学习
        /// </summary>
        public void LinqTest()
        {
            string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };

            //获取所有长度大于等于4的名字
            IEnumerable<string> filteredNames_0 = System.Linq.Enumerable.Where(
                words, n => n.Length >= 4);

            IEnumerable<string> filteredNames_1 = words.Where(n => n.Length >= 4);

            var filteredNames_2 = words.Where(n => n.Length >= 4);

            IEnumerable<string> filteredNames_4 = from n in words
                                                  where n.Length >= 4
                                                  select n;

            // 匿名类
            // 构造一个匿名对象表示一个雇员
            var worker = new { FirstName = "Vincent", LastName = "Ke", Level = 2 };
            // 显示并输出
            Console.WriteLine("Name: {0}, Level: {1}", worker.FirstName + "" + worker.LastName, worker.Level);
        }

        /// <summary>
        /// 匿名类型的比较
        /// </summary>
        static void AnonymousTypeEqualityTest()
        {
            // 构建两个匿名类型，拥有相同的名称/值对
            var worker1 = new { FirstName = "Harry", SecondName = "Folwer", Level = 2 };
            var worker2 = new { FirstName = "Harry", SecondName = "Folwer", Level = 2 };

            // Equals测试
            if (worker1.Equals(worker2))
                Console.WriteLine("worker1 equals worker2"); //OK
            else
                Console.WriteLine("worker1 not equals worker2");

            // ==测试
            if (worker1 == worker2)
                Console.WriteLine("worker1 == worker2");
            else
                Console.WriteLine("worker1 != worker2"); //OK

            // Type Name测试
            if (worker1.GetType().Name == worker2.GetType().Name)
                Console.WriteLine("we are both the same type"); //OK
            else
                Console.WriteLine("we are different types");
        }

    }

    /// <summary>
    /// 扩展类和扩展方法
    /// 当定义一个扩展方法时，第一个限制就是必须把方法定义在静态类中，因此每一个扩展方法也必须声明为静态的。第二个限制是扩展方法要用this关键字对第一个参数进行修饰，这个参数也就是我们希望进行扩展的类型。
    /// 比如下面的扩展方法允许.NET基类库中的所有对象都拥有全新的方法DisplayDefiningAssembly()。当然,受制于所处的命名空间.
    /// </summary>
    static class MyExtensions
    {
        // 本方法允许任何对象显示它所处的程序集
        public static void DisplayDefiningAssemlby(this object obj)
        {
            Console.WriteLine("{0} is defined in: \n\t {1}\n",
                obj.GetType().Name,
                System.Reflection.Assembly.GetAssembly(obj.GetType()));
        }
    }

    /// <summary>
    /// Lambda表达式
    /// </summary>
    public class LambdaStudy
    {

        #region 传统的委托方式

        // 传统的委托使用方式会为委托目标定义一个单独的方法
        public static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 5, 10, 20, 33 });

            //使用传统委托语法调用FindAll
            Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            List<int> evenNumbers = list.FindAll(callback);

            foreach (int num in evenNumbers)
                Console.Write("{0}\t", num);
            //Output:   10    20
        }
        // Predicate<>委托的目标
        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        #endregion

        #region 匿名方法取代显示的委托方式

        public static void AnonymousMethodSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 5, 10, 20, 33 });

            //使用匿名方法
            List<int> evenNumbers = list.FindAll(
                delegate (int i)
                {
                    return (i % 2) == 0;
                });

            foreach (int num in evenNumbers)
                Console.Write("{0}\t", num);
            //Output:   10    20
        }

        #endregion

        #region Lambda表达式

        public static void LambdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 5, 10, 20, 33 });

            //使用Lambda表达式
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            //可以显示定义参数的类型，效果一样
            //List<int> evenNumbers = list.FindAll((int i) => (i % 2) == 0);

            //使用语句块编写Lambda表达式
            //List<int> evenNumbers = list.FindAll((int i) =>
            //{
            //    Console.WriteLine("processing value: {0}", i);
            //    bool isEven = (i % 2) == 0;
            //    return isEven;
            //});

            foreach (int num in evenNumbers)
                Console.Write("{0}\t", num);
            //Output:   10    20
        }

        #endregion

    }

    public class Point
    {
        public Point() { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }
    }
    /// <summary>
    /// 对象初始化器
    /// 以一种非常简洁的方式来创建对象和为对象的属性赋值
    /// </summary>
    public class TestObjectInit
    {
        //使用初始化语法调用构造函数
        static void ObjectInitSyntax()
        {
            // 手动初始化各属性
            Point aPoint = new Point();
            aPoint.X = 10;
            aPoint.Y = 20;

            // 使用新的对象初始化语法进行初始化 ，默认构造函数被隐式调用
            Point bPoint = new Point { X = 10, Y = 20 };

            // 我们也可以显示调用默认构造函数
            Point cPoint = new Point() { X = 10, Y = 20 };

            // 我们还可以调用自定义的构造函数，只是这里1, 2会被10, 20覆盖
            Point dPoint = new Point(1, 2) { X = 10, Y = 20 };
        }

        //初始化内部类型
        static void CompareObjectInitMethods()
        {
            // 传统初始化方法
            Rectangle r = new Rectangle();
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            r.TopLeft = p1;
            Point p2 = new Point();
            p2.X = 20;
            p2.Y = 20;
            r.BottomRight = p2;

            // 对象初始化语法
            Rectangle r2 = new Rectangle
            {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 20, Y = 20 }
            };
        }

        //集合的初始化
        static void CollectionInitSyntax()
        {
            // 初始化标准数组
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 初始化一个ArrayList
            ArrayList list = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 初始化一个List<T>泛型容器
            List<int> list2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 如果容器存放的是非简单对象
            List<Point> pointList = new List<Point>
            {
                new Point { X = 2, Y = 2},
                new Point { X = 3, Y = 3}
            };

            // 使用恰当的缩进和嵌套的大括号会使代码易于阅读，同时节省我们的输入时间
            // 想想如果不使用初始化语法构造如下的List，将需要多少行代码
            List<Rectangle> rectList = new List<Rectangle>
            {
                new Rectangle { TopLeft = new Point { X = 1, Y = 1},
                    BottomRight = new Point { X = 2, Y = 2}},
                new Rectangle { TopLeft = new Point { X = 3, Y = 3},
                    BottomRight = new Point { X = 4, Y = 4}},
                new Rectangle { TopLeft = new Point { X = 5, Y = 5},
                    BottomRight = new Point { X = 6, Y = 6}}
            };
        }
    }


    #endregion

    #region Linq方法语法

    //两种语法:方法语法（Fluent Syntax）和查询语法（Query Expression）

    //链接查询运算符

    public class LinqFluentSyntax
    {
        //查询出所有含有字母”a”的姓名，按长度进行排序，然后把结果全部转换成大写格式。

        //当链接使用查询运算符时，一个运算符的输出sequence会成为下一个运算符的输入sequence，其结果形成了一个sequence的传输链.
        public void Test1()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query = names
                .Where(n => n.Contains("a"))
                .OrderBy(n => n.Length)
                .Select(n => n.ToUpper());

            foreach (string name in query) Console.WriteLine(name);

            // Result:
            //JAY
            //MARY
            //HARRY

            // static methods lose query's fluency
            IEnumerable<string> query2 =
                Enumerable.Select(
                    Enumerable.OrderBy(
                        Enumerable.Where(names, n => n.Contains("a")
                        ), n => n.Length
                    ), n => n.ToUpper()
                );


            int[] numbers = { 10, 9, 8, 7, 6 };
            //元素(element)运算符,会从输入sequence中获取单个元素
            int firstNumber = numbers.First();                  // 10
            int lastNumber = numbers.Last();                    // 6
            int secondNumber = numbers.ElementAt(1);            // 9
            int lowestNumber = numbers.OrderBy(n => n).First(); // 6

            //集合(aggregation) 运算符返回一个标量值，通常是数值类型
            int count = numbers.Count();    // 5
            int min = numbers.Min();        // 6

            //判断运算符返回一个bool值
            bool hasTheNumberNine = numbers.Contains(9);    // true
            bool hasElements = numbers.Any();               // true
            bool hasAnOddElement = numbers.Any(n => (n % 2) == 1);  //true
                                                                    //注意: 因为这些运算符并不是返回一个sequence，所以我们不能再这些运算符之后链接其他运算符，换句话讲，他们一般出现在查询的最后面。

            //Concat把一个sequence添加到另外一个sequence后面；
            //Union与Concat类似，但是会去除相同的元素：
            int[] seq1 = { 1, 2, 2, 3 };
            int[] seq2 = { 3, 4, 5 };
            IEnumerable<int> concat = seq1.Concat(seq2);    // { 1, 2, 2, 3, 3, 4, 5 }
            IEnumerable<int> union = seq1.Union(seq2);      // { 1, 2, 3, 4, 5 }
        }
    }

    #endregion

    #region Linq查询表达式

    //也叫查询语法,查询表达式的产生并不是建立在SQL之上，而是建立在函数式编程语言如LISP和Haskell中的list comprehensions(列表解析)功能之上.

    //查询表达式总是以from子句开始，以select或者group子句结束。

    public class LinqQueryExpression
    {
        //获取所有包含字母”a”的姓名，按长度排序并将结果转为大写。下面是与之等价的查询表达式语法：


        //对于没有对应查询表达式关键字的查询运算符，我们就只能选择方法语法了。
        //下面是存在对应查询表达式关键字的运算符：
        //Where、Select、SelectMany、OrderBy、ThenBy、OrderByDescending、ThenByDescending、GroupBy、Join、GroupJoin。


        public void Test1_LinqQueryExpression()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query =
                from n in names
                where n.Contains("a")       // Filter elements
                orderby n.Length            // Sort elements, （orderby n 改为 orderby n.Length, 感谢网友搏击的小船发现该处错误）
                select n.ToUpper();         // Translate each element
            //详解如下:
            IEnumerable<string> query2 =
               from n in names          //n是我们定义的范围变量
                where n.Contains("a")   //n直接来自names array
                orderby n.Length        //n来自filter之后的subsequent
                select n.ToUpper();     //n来自OrderBy之后的subsequent

            //等价于:
            //编译器会在程序编译时把查询表达式转换为方法语法，即对扩展方法的调用.这样讲的话,貌似方法语法的性能要好一点哦.
            IEnumerable<string> query1 = names
              .Where(n => n.Contains("a"))  //n直接来自names array
              .OrderBy(n => n.Length)       //n来自filter之后的subsequent
              .Select(n => n.ToUpper());    //n来自OrderBy之后的subsequent
            //然后，应用编译器对于方法语法的处理规则，上面的Where, OrderBy, Select查询运算符会绑定到Enumerable类中的相应扩展方法。
            foreach (string name in query)
                Console.WriteLine(name);





            //组合查询语法
            string[] names1 = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            // 计算包含字母”a”的姓名总数
            int matches = (from n in names1 where n.Contains("a") select n).Count();     // 3
            // 按字母顺序排序的第一个名字
            string first = (from n in names1 orderby n select n).First();     // Dick

            //
            int matches1 = names1.Where(n => n.Contains("a")).Count();    // 3
            string first1 = (names1.OrderBy(n => n)).First();     // Dick 
        }
    }

    #endregion
}
