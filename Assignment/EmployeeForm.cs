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
        public EmployeeForm()
        {
            InitializeComponent();
        }

        //insert client
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            string name = textBox1.Text;
            string idCardNr = textBox2.Text;
            string code = textBox3.Text;
            string address = textBox4.Text;
            int n;

            if (name != "" && code != "" && address != "" && Int32.TryParse(idCardNr, out n))
            {
                Client client = new Client(0, name, n, code, address);

                if (repo.Insert(client))
                {
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

        //find client
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            string id = textBox9.Text;
            int n;

            if (Int32.TryParse(id, out n))
            {
                Client client = (Client)repo.Find(n);

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
            else
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //delete client
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            string id = textBox9.Text;
            int n;

            if (Int32.TryParse(id, out n))
            {
                if (repo.Delete(n))
                {
                    MessageBox.Show("Succesfully Deleted!");
                }
                else
                {
                    MessageBox.Show("Not Found!");
                }
            }
            else
            {
                MessageBox.Show("Wrong input!");
            }

        }

        //update client
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            string name = textBox1.Text;
            string idCardNr = textBox2.Text;
            string code = textBox3.Text;
            string address = textBox4.Text;
            string id = textBox9.Text;
            int n, m;

            if (name != "" && code != "" && address != ""
                && Int32.TryParse(idCardNr, out n) && Int32.TryParse(id, out m))
            {
                Client client = new Client(m, name, n, code, address);

                if (repo.Update(m, client))
                {
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

        //find all clients
        private void findAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrudRepository<ClientGateway, Client> repo = new CrudRepository<ClientGateway, Client>();
            richTextBox1.ResetText();

            foreach (Client c in repo.FindAll())
            {
                richTextBox1.Text += c.ToString() + "\n";
            }

        }

        //insert account
        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            string clientID = textBox5.Text;
            string type = textBox6.Text;
            string balance = textBox7.Text;
            int cID;
            double bal;
            DateTime creationDate = DateTime.Now;

            if (Int32.TryParse(clientID, out cID) && type != "" && Double.TryParse(balance, out bal))
            {
                Account acc = new Account(0, cID, type, bal, creationDate);

                if (repo.Insert(acc))
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

        //find client
        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            string id = textBox10.Text;
            int aID;

            if (Int32.TryParse(id, out aID))
            {
                Account acc = (Account)repo.Find(aID);

                if (acc != null)
                {
                    richTextBox1.ResetText();
                    richTextBox1.Text += acc.ToString();
                }
                else
                {
                    MessageBox.Show("Not found!");
                }
            }
            else
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //delete account
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            string id = textBox10.Text;
            int aID;

            if (Int32.TryParse(id, out aID))
            {
                if (repo.Delete(aID))
                {
                    MessageBox.Show("Succesfully deleted!");
                }
                else
                {
                    MessageBox.Show("Not deleted!");
                }
            }
            else
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //update account
        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            string id = textBox10.Text;
            string clientID = textBox5.Text;
            string type = textBox6.Text;
            string balance = textBox7.Text;
            int aID, cID;
            double bal;
            DateTime creationDate = DateTime.Now;

            if (Int32.TryParse(id, out aID) && Int32.TryParse(clientID, out cID) &&
                type != "" && Double.TryParse(balance, out bal))
            {
                Account acc = new Account(0, cID, type, bal, creationDate);

                if (repo.Update(aID, acc))
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

        //find all accounts
        private void findALLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrudRepository<AccountGateway, Account> repo = new CrudRepository<AccountGateway, Account>();
            richTextBox1.ResetText();

            foreach (Account acc in repo.FindAll())
            {
                richTextBox1.Text += acc.ToString() + "\n";
            }
        }

        //pay utilities
        private void payUtilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountOperationsRepository repo = new AccountOperationsRepository();
            string id = textBox10.Text;
            string balance = textBox7.Text;
            int accID;
            double sum;

            if (int.TryParse(id, out accID) && double.TryParse(balance, out sum))
            {
                if (repo.ProcessUtilities(accID, sum))
                {
                    MessageBox.Show("Utilities payed!");
                }
                else
                {
                    MessageBox.Show("Not enough money!");
                }
            }
            else
            {
                MessageBox.Show("Wrong input!");
            }
        }

        //transfer money
        private void transferMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountOperationsRepository repo = new AccountOperationsRepository();
            string senderID = textBox10.Text;
            string receiverID = textBox8.Text;
            string balance = textBox7.Text;
            int sID, rID;
            double sum;

            if (int.TryParse(senderID, out sID) && int.TryParse(receiverID, out rID) &&
                double.TryParse(balance, out sum))
            {
                if (repo.TransferMoney(sID, rID, sum))
                {
                    MessageBox.Show("Transfer complete!");
                }
                else
                {
                    MessageBox.Show("Not enough money!");
                }
            }
            else
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

    }
}
