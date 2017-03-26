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

        public bool ProcessUtilities(int accountID, int sum)
        {
            Account account = myGateway.Find(accountID);
   
            return account.ProccessUtilities(sum);
        }

        public bool TransferMoney(int senderID, int receiverID, int sum)
        {
            Account senderAccount = myGateway.Find(senderID);
            Account receiverAccount = myGateway.Find(receiverID);

            return senderAccount.TransferMoney(receiverAccount, sum);
        }
    }
}
