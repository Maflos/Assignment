using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public class LoginGateway : DataGateway
    {
        public LoginGateway() : base()
        {

        }
 
        public Employee Login(string username, string password)
        {
            Employee employee = null;
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM employee WHERE username=@uname AND password=@pass";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pass", password);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee = new Employee(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),
                        rdr.GetString(3), rdr.GetInt32(4));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return employee;
        }
    }
}
