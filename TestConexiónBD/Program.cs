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
            InsertUserDB.Insert insert = new InsertUserDB.Insert();

            Console.WriteLine(insert.Insertar("tesnaola001@ikasle.ehu.eus"));

            Console.ReadLine();
        }
    }
}
