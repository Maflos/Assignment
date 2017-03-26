using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public abstract class GenericDataGateway<TEntity> where TEntity : Entity
    {
        protected MySql.Data.MySqlClient.MySqlConnection conn;

        public GenericDataGateway(string myConnectionString)
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Nope! { 0 }", ex.ToString());
            }
        }

        public abstract bool Insert(TEntity entity);

        public abstract bool Delete(int id);

        public abstract bool Update(int id, TEntity newEntity);

        public abstract TEntity Find(int id);

        public abstract List<TEntity> FindAll();

        public MySql.Data.MySqlClient.MySqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

    }
}
