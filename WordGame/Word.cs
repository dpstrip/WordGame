using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    public class Word
    {
        public string theWord { get; set; }
        public string jumbleWord { get; set; }

        public Word(string item)
        {
            theWord = item;
            jumbleWord = jumbling();
        }

        public bool compare(string str)
        {
            if(theWord.Equals(str))
            {
                return true;
            }
            return false;
        }

        private string jumbling()
        {
            int numOfChar = theWord.Length;
            char[] arr;
            char[] newWord = new char[numOfChar];
            arr = theWord.ToCharArray();
            SortedSet<int> charPos = new SortedSet<int>();
            Random rnd = new Random();
            bool next = false;

           for(int i = 0; i < numOfChar; i++)
            {
                //get random number of a postion in arr
                //make sure postion hasn't been used

                int loc = rnd.Next(0, numOfChar);
                next = true;
                while (next)
                {
                    if (charPos.Add(loc))
                    {
                        //Place in new word
                        newWord[i] = arr[loc];
                        next = false;
                    }
                    else
                    {
                        loc = rnd.Next(0, numOfChar);
                    }
                }
                
            }

            return new string(newWord);

        }
    }
}
