using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    public class Game
    {
        private List<Word> wordlist;
        private int turnNum;
        public int score { get; set; }
        public Turn turn;

        //initialize by reading a file of word into a list
        //give the player the jumbled word
        //Allow to make a guess
        //Compare
        //if bad guess remove a point
        //if good then give remaing points as a guess  10 guesses max
        //user can stop game at any point or the words run out.

        public Game()
        {
            readFile();
            score = 0;
            turnNum = 0;
        }

        public bool startRound()
        {
            //load the word into turn
            if (!outOfWords())
            {
                turn = new Turn(wordlist.ElementAt(turnNum));
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool outOfWords()
        {
            if (turnNum >= wordlist.LongCount())
                return true;
            else
                return false;
        }

        //Take a turn.  if guess is good return true, if end of turn return true
        public bool takeATurn(string guess)
        {
            //Take a turn
            //if guess is successful then add turn score to total score
            //end turn
            if (turn.takeATurn(guess))
            {
                endTurn();
                return true;
            }//Did I run out of turns?
            else if(turn.score == 0)
            {
                endTurn();
                return true;
            }
                return false;

        }

        public void endTurn()
        {
            score = score + turn.score;
            turnNum++;
            startRound();
        }



         private void readFile()
        {
            wordlist = new List<Word>();
            string[] lines = System.IO.File.ReadAllLines(@"lows.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                wordlist.Add(new Word(line));
            }

        }

        public void viewList()
        {
            foreach(Word word in wordlist)
            {
                Console.WriteLine("Word: {0}, Jumbile: {1}", word.theWord, word.jumbleWord);
            }
        }
    }
}
