using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Account: Entity
    {
        private int accountID;
        private int userID;
        private string type;
        private double balance;
        private DateTime creationDate;

        public Account(int accountID, int userID, string type, 
            double balance, DateTime creationDate)
        {
            this.accountID = accountID;
            this.userID = userID;
            this.type = type;
            this.balance = balance;
            this.creationDate = creationDate;
        }

        public bool ProccessUtilities(double sumToBePayed)
        {
            bool isPayed = true;

            if (sumToBePayed > balance)
            {
                isPayed = false;
            }
            else
            {
                balance -= sumToBePayed;
            }

            return isPayed;
        }

        public bool TransferMoney(Account recipientAccount, double sumToBeTransfered)
        {
            bool isTransfered = true;

            if(sumToBeTransfered > balance)
            {
                isTransfered = false;
            }
            else
            {
                balance -= sumToBeTransfered;
                recipientAccount.Balance += sumToBeTransfered;
            }

            return isTransfered;
        }

        public int AccountID
        {
            get { return accountID; }

            set { accountID = value; }
        }

        public int UserID
        {
            get { return userID; }

            set { userID = value; }
        }

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

        public double Balance
        {
            get { return balance; }

            set { balance = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }

            set { creationDate = value; }
        }

    }
}
