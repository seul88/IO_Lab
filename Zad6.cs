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


                static void Main(string[] args)
                {


                    string name = "plik.txt";
                    FileStream fs = File.OpenRead(name);
                    byte[] buffer = new byte[1024];
                    fs.BeginRead(buffer, 0, buffer.Length, myAsyncCallback, new object[] { fs, buffer });

                    Thread.Sleep(10000);
                }




                static void myAsyncCallback(IAsyncResult state)
                {
                    object[] args = state.AsyncState as object[];
                    FileStream fs = args[0] as FileStream;
                    byte[] buffer = args[1] as byte[];
                    int len = fs.EndRead(state);
                    string s = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.WriteLine(s);
                }

           



	}
}