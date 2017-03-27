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

            LoginRepository loginRepo = new LoginRepository();
            Employee emp = loginRepo.Login("adm1", "12345");

            if (emp == null)
            {
                Console.WriteLine("Wrong username or password");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }
    }
}
