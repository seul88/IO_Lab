using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IO_lab2
{
    class Program
    {





        delegate int DelegateType(int arguments);

        static DelegateType delegateName1;
        static DelegateType delegateName2;

        // silnia iteracyjnie
		
        static int s1(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }


        // silnia rekurencyjnie
		
        static int s2(int i)
        {
            if (i < 1)
                return 1;
            else
                return i * s2(i - 1);

        }










        static void Main(string[] args)
        {
            delegateName1 = new DelegateType(s1);
            IAsyncResult ar = delegateName1.BeginInvoke(10, null, null);
            int result = delegateName1.EndInvoke(ar);
            Console.WriteLine("Iteracyjnie: " + result);


            delegateName2 = new DelegateType(s2);
            IAsyncResult ar2 = delegateName1.BeginInvoke(10, null, null);
            int result2 = delegateName1.EndInvoke(ar2);


            Console.WriteLine("Rekurencyjnie: " + result2);
          

            Thread.Sleep(10000);
        }
        // DIAGNOSTIC STOP_WATCH
        }

}