public class BankAccount
{
    private double _balance;

    public BankAccount(double startingAmount)
    {
        _balance = startingAmount;
    }

    public bool hasSufficientFunds(double amount)
    {
        return _balance >= amount ? true : false;
    }
    public bool withdraw(double amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            return true;
        }
        return false;
    }

    public double getBalance()
    {
        return _balance;
    }
}