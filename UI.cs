

namespace ATM_UML_App
{
    class UI
    {
        private ATM atm;
        public UI(ATM atm)
        {
            this.atm = atm;
        }
        static void main()
        {
            ConsoleColor AtmLettersColor = ConsoleColor.Green;
            ConsoleColor ErrorColor = ConsoleColor.Red;
            ConsoleColor defaultColor = Console.ForegroundColor;

            bool running = true;

            // Changes text color to green
            Console.ForegroundColor = AtmLettersColor;

            bool insertCard = false;
            string? cardNumber = "";
            bool verified = false;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to your ATM!");
                if (insertCard)
                {
                    cardNumber = getCardNumber();
                }
                if (verified)
                {
                    printATMOptions();
                }
            }

            // Changes text color to default color
            Console.ForegroundColor = defaultColor;

            void printATMOptions()
            {
                int selectedIndex = 0;
                bool selecting = true;
                string[] messages = ["Request Amount", "Dispense Cash", "Eject Card"];
                while (selecting)
                {
                    Console.Clear();

                    
                    var keyInput = Console.ReadKey();

                    if(keyInput.Key == ConsoleKey.UpArrow)
                    {
                        if(selectedIndex -1 > 0)
                        {
                            selectedIndex -= 1;
                        }
                    }
                    else if(keyInput.Key == ConsoleKey.DownArrow)
                    {
                        if(selectedIndex +1 < 3)
                        {
                            selectedIndex += 1;
                        }
                    }
                }
            }
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
    }
}
