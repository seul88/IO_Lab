
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    class Zad1
    {
        
        static void Main(string[] args)
        {

                ThreadPool.QueueUserWorkItem(ThreadProc, 500);      
             ThreadPool.QueueUserWorkItem(ThreadProc, 500);  
           
            Thread.Sleep(2000);
 
        }
        
        static void ThreadProc(Object StateInfo)
        {
            int czas = (int)StateInfo;
            Thread.Sleep(czas);
            Console.WriteLine(czas);
        }
        
       
    }
}

