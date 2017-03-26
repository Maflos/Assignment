using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccesLayer;

namespace BusinessLayer
{
    public class LoginRepository
    {
        private LoginGateway myGateway;

        public LoginRepository()
        {
            myGateway = new LoginGateway();
        }

        public Employee Login(string username, string password)
        {
            return myGateway.Login(username, password);
        }
    }
}
