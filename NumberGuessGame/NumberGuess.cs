namespace NumberGuessGame
{
    internal class NumberGuess
    {
        static void Main(string[] args)
        {

            {
              
                bool playAgain = true;
                while (playAgain)
                {
                    var game = new PlayGame();
                    game.Play();
                    playAgain =  game.GetPlayAgain("\nWould you like to play again?");
                }
                Console.WriteLine("Thank you for playing");
            }


        }
    }
}

