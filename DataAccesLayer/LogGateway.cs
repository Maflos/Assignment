﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public class LogGateway : DataGateway
    {
        public LogGateway() : base()
        {
        }

        public void Insert(Log log)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO log(logDate, employeeID, report)" +
                   " VALUES(@date, @id, @report)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@date", log.LogDate);
                cmd.Parameters.AddWithValue("@id", log.EmployeeID);
                cmd.Parameters.AddWithValue("@report", log.Report);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Log> GetReport(int reportDay, int employeeID)
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr = null;
            List<Log> report = new List<Log>();

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM log WHERE DAYOFMONTH(logDate)=@day AND employeeID=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@day", reportDay);
                cmd.Parameters.AddWithValue("@id", employeeID);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Log l = new Log(rdr.GetDateTime(0), rdr.GetInt32(1), rdr.GetString(2));
                    report.Add(l);
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return report;
        }
    }
}
