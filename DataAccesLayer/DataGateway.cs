using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DataGateway
    {
        protected MySql.Data.MySqlClient.MySqlConnection conn;

        public DataGateway()
        {
            string myConnectionString = "";

            try
            {
                myConnectionString = System.IO.File.ReadAllText("connection.txt");
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nope! { 0 }", ex.ToString());
            }
        }
    }
}
