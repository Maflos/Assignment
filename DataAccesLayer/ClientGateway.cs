using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public class ClientGateway : GenericDataGateway<Client>
    {
        public ClientGateway(string myConnectionString) : base(myConnectionString)
        {
        }

        public override bool Insert(Client entity)
        {
            bool isInserted = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO client(name, idCardNumber, code, address)" +
                   " VALUES(@name, @id, @code, @address)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@id", entity.IdCardNumber);
                cmd.Parameters.AddWithValue("@code", entity.Code);
                cmd.Parameters.AddWithValue("@address", entity.Address);
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
                cmd.CommandText = "DELETE FROM client WHERE clientID=@id";
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

        public override bool Update(int id, Client newEntity)
        {
            bool isUpdated = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE client SET name=@name," +
                    " idCardNumber=@idC, code=@code, address=@address" +
                    " WHERE clientID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", newEntity.Name);
                cmd.Parameters.AddWithValue("@idC", newEntity.IdCardNumber);
                cmd.Parameters.AddWithValue("@code", newEntity.Code);
                cmd.Parameters.AddWithValue("@address", newEntity.Address);
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

        public override Client Find(int id)
        {
            Client client = null;
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM client WHERE clientID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    client = new Client(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2),
                        rdr.GetString(3), rdr.GetString(4));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return client;
        }

        public override List<Client> FindAll()
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;
            List<Client> result = new List<Client>();

            try
            {
                string stm = "SELECT * FROM client";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Client c = new Client(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2),
                        rdr.GetString(3), rdr.GetString(4));
                    result.Add(c);
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
