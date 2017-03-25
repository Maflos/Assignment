using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessLayer;
using DataAccesLayer;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "";

            try
            {
                connection = System.IO.File.ReadAllText("connection.txt");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            ClientGateway cg = new ClientGateway(connection);

        }
    }
}
