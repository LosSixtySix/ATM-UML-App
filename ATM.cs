public class ATM
{
    private bool cardInserted;
    private bool pinValidated;
    private BankServer bankServer;
    private string currentCardNumber;

    public  ATM(BankServer server)
    {
        bankServer = server;
    }

    public void insertCard(string cardNumber)
    {
        cardInserted = true;
        currentCardNumber = cardNumber;
        if(bankServer.verifyCard(cardNumber))
        {
            enterPIN();
        }
        ejectCard();
    }

    public bool enterPIN()
    {
        Console.WriteLine("Please enter your pin");
        string pin = Console.ReadLine();
        int pinInt = Convert.ToInt32(pin);
        if(bankServer.verifyPIN(currentCardNumber, pinInt))
        {
            pinValidated = true;
            requestAmount();
            return true;
        }
        ejectCard();
        return false;
    }

    public void requestAmount()
    {
        Console.WriteLine("Enter the amount you want to withdraw");
        string amount = Console.ReadLine();
        double amountDub = Convert.ToDouble(amount);
        if(bankServer.processTransaction(currentCardNumber, amountDub))
        {
            dispenseCash();
        }
        ejectCard();
    }

    public void dispenseCash()
    {
        Console.WriteLine("Please take your cash");
        ejectCard();
    }

    public void ejectCard()
    {
        Console.WriteLine("Please take your card");
    }

    public void checkBalance()
    {
        Console.WriteLine($"Your balance is {bankServer.checkBalance(currentCardNumber)}");
    }

    public ATMAction(enum) getNextAction()
    {

    }
}