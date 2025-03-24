using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEClassTest
{
    class ATM
    {
        private bool cardInserted;
        private bool pinValidated;
        private BankServer bankServer;
        private string currentCardNumber;

        public ATM(BankServer server)
        {
            bankServer = server ?? throw new ArgumentNullException(nameof(server));
            cardInserted = false;
            pinValidated = false;
        }

    }
}
