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
            LogGateway lg = new LogGateway();

            lg.Insert(new Log(new DateTime(2015, 3, 3, 5, 4, 51), 3, "been tere done that"));

            foreach(Log l in lg.GetReport(22, 1))
            {
                Console.WriteLine(l.ToString());
            }
        }
    }
}
