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
            ValidCards = initialCards ?? new Dictionary<string, (int pin, BankAccount account)>
            {
                { "1234567890", (1234, new BankAccount(1000.0)) },
                { "0987654321", (5678, new BankAccount(500.0)) }
            };
        }

        public bool VerifyCard(string cardNumber)
        {
            return ValidCards.ContainsKey(cardNumber);
        }
    }
}
