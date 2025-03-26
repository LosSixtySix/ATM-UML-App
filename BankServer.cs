
public class BankServer
{

	private Dictionary<string, (int pin, BankAccount account)> validCards;

	public BankServer(Dictionary<string, (int pin, BankAccount account)> initialCards)
	{
		validCards = initialCards ?? new Dictionary<string, (int pin, BankAccount account)>
		{
			{ "1", (987654, new BankAccount(100000.0))}

		};
	}

	public bool verifyCard(string cardNumber)
	{
		return validCards.ContainsKey(cardNumber);
	}

	public bool verifyPIN(string cardNumber, int pin)
	{
		(int pin, BankAccount account) card;
		if (validCards.TryGetValue(cardNumber, out card))
			return card.pin == pin;
		return false;
	}

	public bool processTransaction(string cardNumber, double amount)
	{
		(int pin, BankAccount account) card;
		if (validCards.TryGetValue(cardNumber, out card))
			if (card.account.hasSufficientFunds(amount))
			{
				card.account.withdraw(amount);
				return true;
			}
		return false;
	}

	public double checkBalance(string cardNumber)
	{
		(int pin, BankAccount account) card;
		if (validCards.TryGetValue(cardNumber, out card))
			return card.account.getBalance();
		return 0.0;
	}
}