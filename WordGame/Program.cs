using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            Console.WriteLine("Press any key");

            Game game = new Game();
            game.viewList();
            game.startRound();
            do
            {
                Console.WriteLine("Your score is: {0}", game.score);
                setUpTurn(game.turn);
                while (!game.takeATurn(retrieveGuess()))
                {
                    Console.WriteLine("Your turn score is: {0}", game.turn.score);
                }

            } while (game.startRound());
            Console.WriteLine("Your final score is: {0}", game.score);
            Console.ReadKey();
        }

        private static void setUpTurn(Turn turn)
        {
            Console.WriteLine("The word to guess is: {0}", turn.word.jumbleWord);
        }

            private static string retrieveGuess()
        {
            Console.WriteLine("Type in a word and press enter.");
            string lGuess = Console.ReadLine();
            return lGuess;
        }
    }
}
