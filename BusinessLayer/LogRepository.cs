using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccesLayer;

namespace BusinessLayer
{
    public class LogRepository
    {
        private LogGateway myGateway;

        public LogRepository()
        {
            myGateway = new LogGateway();
        }

        public void InsertLog(int id, string report)
        {
            DateTime currentDate = DateTime.Now;
            Log log = new Log(currentDate, id, report);
            myGateway.Insert(log);
        }

        public List<Log> GetReport(int day, int employeeID)
        {
            return myGateway.GetReport(day, employeeID);
        }
    }


   
}
