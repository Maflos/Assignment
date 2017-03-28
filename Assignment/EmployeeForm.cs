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
    public partial class EmployeeForm : Form
    {
        public Employee currentUser;

        public EmployeeForm(Employee currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
            textBox11.Text += currentUser.Name;
        }

        //insert client
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            LogRepository logRepo = new LogRepository();
            string name = textBox1.Text;
            string idCardNr = textBox2.Text;
            string code = textBox3.Text;
            string address = textBox4.Text;
            int idNr = 0;

            try
            {
                idNr = int.Parse(idCardNr);
                if (name != "" && code != "" && address != "")
                {
                    Client client = new Client(0, name, idNr, code, address);

                    if (repo.Insert(client))
                    {
                        logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "inserted a client");
                        MessageBox.Show("Succesfully Inserted!");
                    }
                    else
                    {
                        MessageBox.Show("Not Inserted!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input");
            }
        }

        //find client
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            LogRepository logRepo = new LogRepository();
            string id = textBox9.Text;
            int cID;

            try
            {
                cID = int.Parse(id);
                Client client = (Client)repo.Find(cID);

                if (client != null)
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "searched for a client");
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
                MessageBox.Show("Not Found!");
            }
        }

        //delete client
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            LogRepository logRepo = new LogRepository();
            string id = textBox9.Text;
            int cID;

            try
            {
                cID = int.Parse(id);

                if (repo.Delete(cID))
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "deleted a client");
                    MessageBox.Show("Succesfully Deleted!");
                }
                else
                {
                    MessageBox.Show("Not Found!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong Input!");
            }
        }

        //update client
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            LogRepository logRepo = new LogRepository();
            string name = textBox1.Text;
            string idCardNr = textBox2.Text;
            string code = textBox3.Text;
            string address = textBox4.Text;
            string id = textBox9.Text;
            int idNr, cID;

            try
            {
                idNr = int.Parse(idCardNr);
                cID = int.Parse(id);

                if (name != "" && code != "" && address != "")
                {
                    Client client = new Client(cID, name, idNr, code, address);

                    if (repo.Update(cID, client))
                    {
                        logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "updated a client");
                        MessageBox.Show("Succesfully Updated!");
                    }
                    else
                    {
                        MessageBox.Show("Not Updated!");
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

        //find all clients
        private void findAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            LogRepository logRepo = new LogRepository();
            richTextBox1.ResetText();

            foreach (Client c in repo.FindAll())
            {
                richTextBox1.Text += c.ToString() + "\n";
            }
            logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "listed clients");
        }

        //insert account
        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            LogRepository logRepo = new LogRepository();
            string clientID = textBox5.Text;
            string type = textBox6.Text;
            string balance = textBox7.Text;
            int cID;
            double bal;
            DateTime creationDate = DateTime.Now;

            try
            {
                cID = int.Parse(clientID);
                bal = double.Parse(balance);

                if (type != "")
                {
                    Account acc = new Account(0, cID, type, bal, creationDate);

                    if (repo.Insert(acc))
                    {
                        logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "inserted an account");
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

        //find account
        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            LogRepository logRepo = new LogRepository();
            string id = textBox10.Text;
            int aID;

            try
            {
                aID = int.Parse(id);

                Account acc = (Account)repo.Find(aID);

                if (acc != null)
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "searched for an account");
                    richTextBox1.ResetText();
                    richTextBox1.Text += acc.ToString();
                }
                else
                {
                    MessageBox.Show("Not found!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //delete account
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            LogRepository logRepo = new LogRepository();
            string id = textBox10.Text;
            int aID;

            try
            {
                aID = int.Parse(id);

                if (repo.Delete(aID))
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "deleted an account");
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

        //update account
        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            LogRepository logRepo = new LogRepository();
            string id = textBox10.Text;
            string clientID = textBox5.Text;
            string type = textBox6.Text;
            string balance = textBox7.Text;
            int aID, cID;
            double bal;
            DateTime creationDate = DateTime.Now;

            try
            {
                aID = int.Parse(id);
                cID = int.Parse(clientID);
                bal = double.Parse(balance);

                if (type != "")
                {
                    Account acc = new Account(0, cID, type, bal, creationDate);

                    if (repo.Update(aID, acc))
                    {
                        logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "updated an account");
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

        //find all accounts
        private void findALLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            LogRepository logRepo = new LogRepository();
            richTextBox1.ResetText();

            foreach (Account acc in repo.FindAll())
            {
                richTextBox1.Text += acc.ToString() + "\n";
            }

            logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "listed accounts");
        }

        //pay utilities
        private void payUtilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountOperationsRepository repo = new AccountOperationsRepository();
            LogRepository logRepo = new LogRepository();
            string id = textBox10.Text;
            string balance = textBox7.Text;
            int accID;
            double sum;

            try
            {
                accID = int.Parse(id);
                sum = double.Parse(balance);

                if (repo.ProcessUtilities(accID, sum))
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "proccessed utilities");
                    MessageBox.Show("Utilities payed!");
                }
                else
                {
                    MessageBox.Show("Not enough money!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //transfer money
        private void transferMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountOperationsRepository repo = new AccountOperationsRepository();
            LogRepository logRepo = new LogRepository();
            string senderID = textBox10.Text;
            string receiverID = textBox8.Text;
            string balance = textBox7.Text;
            int sID, rID;
            double sum;

            try
            {
                sID = int.Parse(senderID);
                rID = int.Parse(receiverID);
                sum = int.Parse(balance);

                if (repo.TransferMoney(sID, rID, sum))
                {
                    logRepo.InsertLog(currentUser.EmployeeID, currentUser.Name, "trasfered money");
                    MessageBox.Show("Transfer complete!");
                }
                else
                {
                    MessageBox.Show("Not enough money!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //-----------------------------------------------------------------------------------
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
