using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net;
using System.Text;
using System.Threading;


namespace Lab1
{
    class Zad5
    {

        private static Object theLock = new Object();
        private static AutoResetEvent[] autoResetEvent;
        private static int sumResult;


        public static int oneThreadSum(int[] tab)
        {
            int res = 0;
            foreach (int value in tab)
                res += value;
            return res;
        }

        public static int[] generateTable(int tabSize)
        {

                int[] tab = new int[tabSize];
                Random rand = new Random();

                for (int i = 0; i < tabSize; i++)
                {
                    tab[i] = rand.Next(0, 100);
                }

          return tab;
        }


    static void callback(Object stateInfo)
        {
            var table = (int[])((object[])stateInfo)[0];
            var index = (int)((object[])(stateInfo))[1];
            sumThread(table, index);
        }

        static void sumThread(int[] table, int index)
        {         
            lock (theLock)
            {
                foreach (int item in table)
                    Program.sumResult += item;
            }
            autoResetEvent[index].Set();
        }


        static void Main(string[] args)
        {
            Program.sumResult = 0;
            int tabSize = 100000;
            int blockNum = 10000;
           

            generateTable(tabSize);

            int[] tab = generateTable(tabSize);

            int[] blockData = new int[blockNum];

            autoResetEvent = new AutoResetEvent[tabSize / blockNum];


            
            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();

            stopWatch1.Start();
          
             for (int i = 0; i < tabSize / blockNum; i++)
             {
                 for (int j = 0; j < blockNum; j++)
                 {
                     blockData[j] = tab[i * blockNum + j];
                 }

                 autoResetEvent[i] = new AutoResetEvent(false);
                 ThreadPool.QueueUserWorkItem(callback, new object[] { blockData, i });

                 blockData = new int[blockNum];
             }


             WaitHandle.WaitAll(autoResetEvent);

             Console.WriteLine("[Wiele watkow] suma: " + Program.sumResult);

             stopWatch1.Stop();

             var time1 = stopWatch1.Elapsed;

             Console.WriteLine("[Wiele watkow] czas: " + time1 + "ms");



            
            stopWatch2.Start();
            int oneThreadSumValue;
            oneThreadSumValue = oneThreadSum(tab);   
            stopWatch2.Stop();
            Console.WriteLine("[Jeden watek] suma: " + oneThreadSumValue);
            var time2 = stopWatch2.Elapsed;
            Console.WriteLine("[Jeden watek] czas: " + time2 + "ms");


        }

    }
}