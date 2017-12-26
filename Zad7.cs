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

			var id = fs.BeginRead(buffer, 0, buffer.Length, null, new object[] { fs, buffer });
			int ile = fs.EndRead(id);


			string s = Encoding.UTF8.GetString(buffer, 0, ile);
			Console.WriteLine(s);


			Thread.Sleep(10000);
		}
    
	}
}