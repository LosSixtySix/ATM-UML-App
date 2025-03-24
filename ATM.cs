using ATM_UML_App;

public class ATM
{
    private bool cardInserted;
    private bool pinValidated;
    private BankServer bankServer;
    private string currentCardNumber;

    public ATM(BankServer server)
    {
        bankServer = server;
        cardInserted = false;
        pinValidated = false;
    }

    public void insertCard(string cardNumber)
    {
        cardInserted = true;
        currentCardNumber = cardNumber;
        if (!bankServer.verifyCard(currentCardNumber))
        {
            ejectCard();
        }
    }

    public bool enterPIN()
    {
        Console.WriteLine("Please enter your pin");
        string pin = Console.ReadLine();
        int pinInt = Convert.ToInt32(pin);
        if (bankServer.verifyPIN(currentCardNumber, pinInt))
        {
            pinValidated = true;
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
        if (bankServer.processTransaction(currentCardNumber, amountDub))
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

    public ATMAction GetNextAction()
    {
        if (!cardInserted)
            return ATMAction.InsertCard;
        else if (!pinValidated)
            return ATMAction.EnterPIN;
        else
            return ATMAction.DisplayOptions;
    }
}