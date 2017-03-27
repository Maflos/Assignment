using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public class AccountGateway : GenericDataGateway<Account>
    {
        public AccountGateway() : base()
        {
        }

        public override bool Insert(Account entity)
        {
            bool isInserted = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO account(clientID, type, balance, creationDate)" + 
                   " VALUES(@cID, @type, @balance, @cd)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@cID", entity.ClientID);
                cmd.Parameters.AddWithValue("@type", entity.Type);
                cmd.Parameters.AddWithValue("@balance", entity.Balance);
                cmd.Parameters.AddWithValue("@cd", entity.CreationDate);
                cmd.ExecuteNonQuery();
                isInserted = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return isInserted;
        }

        public override bool Delete(int id)
        {
            bool isDeleted = true;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM account WHERE accountID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                isDeleted = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return isDeleted;
        }

        public override bool Update(int id, Account newEntity)
        {
            bool isUpdated = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE account SET clientID=@cID," +
                    " type=@type, balance=@balance, creationDate=@cd" + 
                    " WHERE accountID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@cID", newEntity.ClientID);
                cmd.Parameters.AddWithValue("@type", newEntity.Type);
                cmd.Parameters.AddWithValue("@balance", newEntity.Balance);
                cmd.Parameters.AddWithValue("@cd", newEntity.CreationDate);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
      
            return isUpdated;
        }

        public override Account Find(int id)
        {
            Account account = null;
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM account WHERE accountID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    account = new Account(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2),
                        rdr.GetDouble(3), rdr.GetDateTime(4));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                rdr.Close();
            }

            return account;
        }

        public override List<Account> FindAll()
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;
            List<Account> result = new List<Account>();

            try
            {
                string stm = "SELECT * FROM account";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Account a = new Account(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2),
                        rdr.GetDouble(3), rdr.GetDateTime(4));
                    result.Add(a);
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
    }
}
