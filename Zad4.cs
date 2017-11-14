using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*

namespace Lab1
{
    class Zad4
    {
         

        static void Main(string[] args)
        {

            // serwer
            ThreadPool.QueueUserWorkItem(ThreadProc);

            // klienci
            ThreadPool.QueueUserWorkItem(ThreadProc2);
            ThreadPool.QueueUserWorkItem(ThreadProc2);

            Thread.Sleep(5000);
        }



        static void ThreadProc(Object StateInfo)
        {
            Object thislock = new Object();
            TcpListener server = new TcpListener(IPAddress.Any, 1024);
            server.Start();

           

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, 1024);

                lock (thislock) { 
                
                    var kolor = Encoding.UTF8.GetString(buffer);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("po stronie serwera - ODEBRANO: " + kolor);
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
            }
        }

        static void ThreadProc2(Object StateInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));
            byte[] message = new ASCIIEncoding().GetBytes("wiadomosc");
            var kolor = Encoding.UTF8.GetString(message);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("po stronie klienta - WYSŁANO: " + kolor);
            client.GetStream().Write(message, 0, message.Length);

        }

    }
}

*/