using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    public class Turn
    {
        public Word word { get; set; }
        public int score { get; set; }

        public  Turn(Word word)
        {
            this.word = word;
            score = 10;
        }

        public Boolean takeATurn(string guess)
        {
            if(word.compare(guess))
            {
                return true;
            }
            else
            {
                score--;
                return false;
            }
        }
    }
}
