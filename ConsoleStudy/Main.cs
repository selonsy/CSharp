using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                int a = 0;
                for (int i = 0; i < 30; i++)
                {
                    a = i;
                    try
                    {
                        new HttpHelperTest().Excute(i);
                    }
                    catch (Exception)
                    {
                        continue;                       
                    }                    
                }
                Console.WriteLine(a);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }                                  
        }
    }
}
