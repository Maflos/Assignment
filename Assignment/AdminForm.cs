using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BusinessLayer;
using DataAccesLayer;

namespace Assignment
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        //insert employee
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<EmployeeGateway, Employee> repo = new CrudRepository<EmployeeGateway, Employee>();
            LogRepository log = new LogRepository();
            string name = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string isAdmin = textBox5.Text;
            int adm;

            try
            {
                adm = int.Parse(isAdmin);

                if (name != "" && username != "" && password != ""
                    && (adm == 0 || adm == 1))                
                {
                    Employee emp = new Employee(0, name, username, password, adm);

                    if (repo.Insert(emp))
                    {
                        MessageBox.Show("Succesfully inserted!");
                    }
                    else
                    {
                        MessageBox.Show("Not inserted!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //delete employee
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<EmployeeGateway, Employee> repo = new CrudRepository<EmployeeGateway, Employee>();
            string id = textBox1.Text;
            int eID;

            try
            {
                eID = int.Parse(id);

                if(repo.Delete(eID))
                {
                    MessageBox.Show("Succesfully deleted!");
                }
                else
                {
                    MessageBox.Show("Not deleted!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //update employee
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<EmployeeGateway, Employee> repo = new CrudRepository<EmployeeGateway, Employee>();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string isAdmin = textBox5.Text;
            int eID, adm;

            try
            {
                eID = int.Parse(id);
                adm = int.Parse(isAdmin);

                if (name != "" && username != "" && password != ""
                    && (adm == 0 || adm == 1))
                {
                    Employee emp = new Employee(eID, name, username, password, adm);

                    if (repo.Update(eID, emp))
                    {
                        MessageBox.Show("Succesfully updated!");
                    }
                    else
                    {
                        MessageBox.Show("Not updated!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //find employee
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<EmployeeGateway, Employee> repo = new CrudRepository<EmployeeGateway, Employee>();
            string id = textBox1.Text;
            int eID;

            try
            {
                eID = int.Parse(id);
                Employee client = (Employee)repo.Find(eID);

                if (client != null)
                {
                    richTextBox1.ResetText();
                    richTextBox1.Text += client.ToString();
                }
                else
                {
                    MessageBox.Show("Not Found!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //find all employees
        private void findAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<EmployeeGateway, Employee> repo = new CrudRepository<EmployeeGateway, Employee>();
            richTextBox1.ResetText();

            foreach (Employee emp in repo.FindAll())
            {
                richTextBox1.Text += emp.ToString() + "\n";
            }
        }

        //log info by day
        private void byDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogRepository logRepo = new LogRepository();
            string empID = textBox1.Text;
            string dayStr = textBox6.Text;
            int id, day;

            try
            {
                id = int.Parse(empID);
                day = int.Parse(dayStr);

                richTextBox1.ResetText();

                foreach (Log log in logRepo.GetDaylyReport(day, id))
                {
                    richTextBox1 .Text += log.ToString() + "\n";
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        private void byMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogRepository logRepo = new LogRepository();
            string empID = textBox1.Text;
            string monthStr = textBox6.Text;
            int id, month;

            try
            {
                id = int.Parse(empID);
                month = int.Parse(monthStr);

                richTextBox1.ResetText();

                foreach (Log log in logRepo.GetMonthlyReport(month, id))
                {
                    richTextBox1.Text += log.ToString() + "\n";
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //---------------------------------------------------------------------------
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
