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

namespace Assignment
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginRepository loginRepo = new LoginRepository();
            Employee emp = loginRepo.Login(textBox1.Text, textBox2.Text);

            if(emp == null)
            {
                MessageBox.Show("Wrong username or password!");
            }
            else if(emp.IsAdmin == 1)
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                //Hide();
            }
            else
            {
                EmployeeForm empForm = new EmployeeForm();
                empForm.Show();
                //Hide();
            }
        }
    }
}
