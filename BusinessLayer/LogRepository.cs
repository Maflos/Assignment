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

        public void InsertLog(int id, string name, string report)
        {
            DateTime currentDate = DateTime.Now;
            Log log = new Log(currentDate, id, name, report);
            myGateway.Insert(log);
        }

        public List<Log> GetDaylyReport(int day, int employeeID)
        {
            return myGateway.GetDaylyReport(day, employeeID);
        }

        public List<Log> GetMonthlyReport(int month, int employeeID)
        {
            return myGateway.GetMonthlyReport(month, employeeID);
        }
    }
}
