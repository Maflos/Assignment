﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    class EmployeeGateway : GenericDataGateway<Employee>
    {
        public EmployeeGateway(string myConnectionString) : base(myConnectionString)
        {
        }

        public override bool Insert(Employee entity)
        {
            bool isInserted = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO employee(employeeID, name, username, password, isAdmin)" +
                   " VALUES(@eID, @name, @uname, @pass, @admin";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@eID", entity.EmployeeID);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Parameters.AddWithValue("@uname", entity.Username);
                cmd.Parameters.AddWithValue("@pass", entity.Password);
                cmd.Parameters.AddWithValue("@admin", entity.IsAdmin);
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
                cmd.CommandText = "DELETE FROM employee WHERE employeeID=@id";
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

        public override bool Update(int id, Employee newEntity)
        {
            bool isUpdated = false;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE employee SET employeeID=@eID, name=@name," +
                    " username=@uname, password=@password, isAdmin=@isAdmin" +
                    " WHERE employeeID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@eID", newEntity.EmployeeID);
                cmd.Parameters.AddWithValue("@name", newEntity.Name);
                cmd.Parameters.AddWithValue("@uname", newEntity.Username);
                cmd.Parameters.AddWithValue("@pass", newEntity.Password);
                cmd.Parameters.AddWithValue("@admin", newEntity.IsAdmin);
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

        public override Employee Find(int id)
        {
            Employee employee = null;
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM employee WHERE clientID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", id);
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

        public override List<Employee> FindAll(int id)
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;
            List<Employee> result = new List<Employee>();

            try
            {
                string stm = "SELECT * FROM employee";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   Employee e = new Employee(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),
                        rdr.GetString(3), rdr.GetInt32(4));
                    result.Add(e);
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
