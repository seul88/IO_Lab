using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

 
namespace Lab1
{
    class Zad2
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
            TcpListener server = new TcpListener(IPAddress.Any, 1024);
            server.Start();
         //   Console.WriteLine("Serwer");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, 1024);
                client.GetStream().Write(buffer, 0, buffer.Length);
               
            }
        }

        static void ThreadProc2(Object StateInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));
            byte[] message = new ASCIIEncoding().GetBytes("wiadomosc");
            client.GetStream().Write(message, 0, message.Length);
       //     Console.WriteLine("Klient");
        }

        
    }
}

