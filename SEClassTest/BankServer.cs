using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEClassTest
{
    class BankServer
    {
        private Dictionary<string, (int pin, BankAccount account)> ValidCards;

        public BankServer(Dictionary<string, (int pin, BankAccount account)> initialCards = null)
        {       
        }

        public bool VerifyCard(string cardNumber)
        {
            return ValidCards.ContainsKey(cardNumber);
        }
    }
}
