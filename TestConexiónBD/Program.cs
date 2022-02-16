using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConexiónBD
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnect.Conectar bd = new SqlConnect.Conectar();

            Console.WriteLine(bd.confUser("telmoesnaolaa@gmail.com", 871173));

            //Console.WriteLine(bd.getConfNum("telmoesnaolaa@gmail.com"));

            Console.ReadLine();
        }
    }
}
