

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
            bool cardNotInserted = false;
            string? cardNumber = "";
            bool verified = false;
            int selectedOption = 0;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to your ATM!");
                if (cardNotInserted)
                {
                    cardNumber = getCardNumber();
                    atm.insertCard(cardNumber);
                    verified = atm.enterPIN;
                    cardNotInserted = false;
                }
                if (verified)
                {
                    selectedOption = printATMOptions();
                    verified = false;
                }
                if(verified == false && cardNotInserted == false)
                {
                    if(selectedOption == 0)
                    {
                        atm.requestAmount();
                    }
                    else if(selectedOption == 1)
                    {
                        atm.dispenseCash();
                    }
                    else if(selectedOption == 2)
                    {
                        atm.ejectCard();
                        cardNotInserted = true;
                    }
                }
            }

            // Changes text color to default color
            Console.ForegroundColor = defaultColor;

            int printATMOptions()
            {
                int selectedIndex = 0;
                bool selecting = true;
                string[] messages = ["1: Request Amount", "2: Dispense Cash", "3: Eject Card"];
                for (int index = 0; index < messages.Length; index++)
                {
                    if (index == selectedIndex)
                    {
                        Console.WriteLine($"{messages[index]}\t<");
                    }
                    else
                    {
                        Console.WriteLine(messages[index]);
                    }
                }
                while (selecting)
                {
                    var keyInput = Console.ReadKey();
                    Console.Clear();

                    if (keyInput.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedIndex - 1 >= 0)
                        {
                            selectedIndex -= 1;
                        }
                    }
                    else if (keyInput.Key == ConsoleKey.DownArrow)
                    {
                        if (selectedIndex + 1 < 3)
                        {
                            selectedIndex += 1;
                        }
                    }
                    else if(keyInput.Key == ConsoleKey.Enter)
                    {
                        selecting = false;
                    }
                        for (int index = 0; index < messages.Length; index++)
                        {
                            if (index == selectedIndex)
                            {
                                Console.WriteLine($"{messages[index]}\t<");
                            }
                            else
                            {
                                Console.WriteLine(messages[index]);
                            }
                        }
                }
                return selectedIndex;
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
