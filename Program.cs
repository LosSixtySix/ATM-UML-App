Atm atm = new Atm();

void main(Atm ATM)
{
    ConsoleColor AtmLettersColor = ConsoleColor.Green;
    ConsoleColor ErrorColor = ConsoleColor.Red;
    ConsoleColor defaultColor = Console.ForegroundColor;

    bool running = true;

    // Changes text color to green
    Console.ForegroundColor = AtmLettersColor;

    string? cardNumber = "";


    while (running)
    {
        Console.Clear();
        Console.WriteLine("Welcome to your ATM!");
        if (cardNumber == "")
        {
            cardNumber = getCardNumber();
        }
    }

    // Changes text color to default color
    Console.ForegroundColor = defaultColor;


    string getCardNumber()
    {
        string? input = "";


        while (input == "")
        {
            Console.Write("Please Enter your card Number:");
            input = Console.ReadLine();
            if (input == "")
            {
                Console.ForegroundColor = ErrorColor;
                Console.WriteLine("That is not a valid card Number. Please Try again");
                Console.ForegroundColor = AtmLettersColor;
            }
        }
        return input;
    }
}

main(atm);

class Atm()
{

}