using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccesLayer;

namespace BusinessLayer
{
    public class AccountOperationsRepository
    {
        private AccountGateway myGateway;

        public AccountOperationsRepository()
        {
            myGateway = new AccountGateway();
        }

        public bool ProcessUtilities(int accountID, double sum)
        {
            Account account = myGateway.Find(accountID);
            
            if(account.ProccessUtilities(sum))
            {
                myGateway.Update(accountID, account);
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool TransferMoney(int senderID, int receiverID, double sum)
        {
            Account senderAccount = myGateway.Find(senderID);
            Account receiverAccount = myGateway.Find(receiverID);

            if (senderAccount.TransferMoney(receiverAccount, sum))
            {
                myGateway.Update(senderID, senderAccount);
                myGateway.Update(receiverID, receiverAccount);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
