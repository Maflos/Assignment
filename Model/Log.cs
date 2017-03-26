using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Log : Entity
    {
        private DateTime logDate;
        private int employeeID;
        private string report;

        public Log (DateTime logDate, int employeeID, string report)
        {
            this.logDate = logDate;
            this.employeeID = employeeID;
            this.report = report;
        }

        public override string ToString()
        {
            return logDate.ToString() + " -> " + employeeID + " -> " + report;
        }

        public DateTime LogDate
        {
            get { return logDate; }
            set { logDate = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string Report
        {
            get { return report; }
            set { report = value; }
        }
    }
}
