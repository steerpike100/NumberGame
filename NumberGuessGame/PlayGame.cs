
namespace NumberGuessGame
{
    internal class PlayGame
    {

        private const string Prompt =
            "Welcome to the Number Guess Game.  You have 5 attempts to guess a random number between 1 and 10. \nPress ENTER when ready!";

        private int _attempts;
        private const int MaxAttempts = 5;
        private readonly Random _randomNumber = new Random();

        public void Play()
        {
            _attempts = 0;
            Console.Write(Prompt);
            var start = StartGame();

            if (start)
            {
                int winningAnswer = GetWinningNumber();

                for (_attempts = 0; _attempts < MaxAttempts; _attempts++)
                {
                    int guess = GetUserGuess();

                    if (winningAnswer == guess)
                    {
                        Console.WriteLine($"You correctly guessed {winningAnswer} as the correct answer!, Congratulations!!!");
                        return;
                    }
                    else if (_attempts < MaxAttempts - 1)
                    {
                        Console.WriteLine("I'm sorry, you guessed incorrectly :( please try again.");
                    }
                }

                Console.WriteLine($"I'm sorry, you failed to guess within {MaxAttempts}.");

            }

        }


        private int GetWinningNumber()
        {
            var winningNumber = _randomNumber.Next(1, 11);
            return winningNumber;

        }

        private bool StartGame()
        {
            bool enterPressed = false;
            while (enterPressed == false)
            {
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        return true;
                    }

                    {
                        enterPressed = false;
                        Console.WriteLine("\nYou must start the game by pressing ENTER only");
                        Console.WriteLine("\nPress ENTER when ready!");
                    }
                }
            }

            return false;
        }

        private int GetUserGuess()
        {
            while (true)
            {
                Console.WriteLine($"\nPlease enter your guess (Attempt {_attempts + 1} of {MaxAttempts}):");
                var guess = Console.ReadLine();

                if (int.TryParse(guess, out int validNumber) && validNumber >= 1 && validNumber <= 10)
                {
                    return validNumber;
                }
                else
                {
                    Console.WriteLine($"{guess} isn't a valid number between 1 and 10, try again.");
                }
            }
        }


        public bool GetPlayAgain(string wouldYouLikeToPlayAgain)
        {
            while (true)
            {
                Console.WriteLine($"{wouldYouLikeToPlayAgain} ");
            
                var input = Console.ReadLine().Trim()
                        .ToLower(); 

                if (input == "y" || input == "yes")
                {
                    return true;
                }

                if (input == "n" || input == "no")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");

            }
        }
    }
}

