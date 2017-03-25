using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client: Entity
    {
        private int clientID;
        private string name;
        private int idCardNumber;
        private string code;
        private string address;

        public Client(int clientID, string name, int idCardNumber, 
            string code, string address)
        {
            this.clientID = clientID;
            this.name = name;
            this.idCardNumber = idCardNumber;
            this.code = code;
            this.address = address;
        }

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int IdCardNumber
        {
            get { return idCardNumber; }
            set { idCardNumber = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
