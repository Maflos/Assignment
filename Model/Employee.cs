using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Employee: Entity
    {
        private int employeeID;
        private string name;
        private string username;
        private string password;
        private string isAdmin;

        public Employee(int employeeID, string name, string username, 
            string password, string isAdmin)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.username = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }


        public int EmployeeID
        {
            get { return employeeID; }
            set {  employeeID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set {  password = value; }
        }

        public string IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
    }
}
