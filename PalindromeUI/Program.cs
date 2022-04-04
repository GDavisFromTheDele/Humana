using System;
using System.Collections.Generic;
using System.Linq;
using PalindromeLib;

namespace PalindromeUI
{
    class Program
    {
        // <summary>
        // Main entry point
        // </summary>
        static void Main(string[] args)
        {
            string _input, _input2, word = string.Empty;
            int palindromeSentenceCount = 0, frequency = 0;
            char? chr;

            Console.Write("Enter string to evaluate : ");
            _input =Console.ReadLine();

            if (_input == "")
            {
                return;
            }

            Console.WriteLine();

            Console.WriteLine("[Display count of paindrome words]");
            Console.WriteLine("    You entered : " + _input);
            Console.WriteLine("    Input contains " + PalindromeUtils.palindromeCount(_input.Replace(".", "")) + " palindrome word(s)");
            Console.WriteLine();

            //Count palindrome sentences
            //Assumption: Sentence ends in a period (.)
            string[] sentences = _input.Split(". ");

            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i] != "")
                {
                    //Ensure that a trailing period (.) is removed in the event that a sentence is at the end of the string
                    if (PalindromeUtils.palindromeSentenceCount(sentences[i].Replace(".", "")))
                    {
                        palindromeSentenceCount++;
                    }
                }
            }
            Console.WriteLine("[Display count of palindrome sentences]");
            Console.WriteLine("    Input contains " + palindromeSentenceCount + " palindrome sentence(s).");
            Console.WriteLine();

            //Get list of all words in string and count instances
            string[] uniqueWords = _input.Replace(".", "").Split(' ');
            //string word = "";
            Dictionary<string, int> wordsAndcount = new Dictionary<string, int>();

            for (int i = 0; i < uniqueWords.Length; i++)
            {
                word = uniqueWords[i];

                if (!wordsAndcount.ContainsKey(word))
                {
                    wordsAndcount.Add(word, 1);
                }
                else
                {
                    wordsAndcount[word]++;
                }
            }

            //Show words in string and occurences
            Console.WriteLine("[Unique words and occurences]");
            foreach (KeyValuePair<string, Int32> wrd in wordsAndcount)  
            {  
                Console.WriteLine("    Word: {0}, Occurences: {1}", wrd.Key, wrd.Value);  
            }
            Console.WriteLine();

            //Count occurences of a character in string
            Console.Write("Enter a letter to count occurences in string entered : ");
            _input2 =Console.ReadLine();

            //Variable previously defined. Reuse
            chr = char.Parse(_input2.Substring(0, 1));
            frequency = _input.Count(f => (f == chr));
            Console.WriteLine("[Value searched in string]");
            Console.WriteLine("    Input [" + _input2 + "] occurs " + frequency + " time(s) in [" + _input + "]");
            Console.WriteLine();
        }
    }
}
