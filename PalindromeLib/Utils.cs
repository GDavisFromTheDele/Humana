using System;

namespace PalindromeLib
{
    // <summary>
    // public PalindromeUtils():
    //     This is a collection of reusable function for returning palindrome requests
    // </summary>
    public class PalindromeUtils
    {
        // <summary>
        // public palindromeCount():
        //     Assumption that string is determined to be palindrome using lowercase as default
        //     Return the nummber of palindrome words in a string
        // </summary>
        public static int palindromeCount(string input)
        {
            //Check last word to see if palindrome
            input = input.ToLower() + " ";

            //Store each word
            string wrd = "";
            int wordCount = 0;

            for (int x = 0; x < input.Length; x++)
            {
                char chr = input[x];

                //Extract each word
                if (chr != ' ')
                {
                    wrd = wrd + chr;
                }
                else
                {
                    if (checkPalindrome(wrd))
                    {
                        //Increment counter
                        wordCount++;
                    }

                    //Reset value
                    wrd = "";
                }
            }

            return wordCount;
        }

        // <summary>
        // checkPalindrome():
        //     Assumption that string is determined to be palindrome using lowercase as default
        //     Return if a word is polindrome
        // </summary>
        public static bool checkPalindrome(string word)
        {
            int n = word.Length;

            //Assumption that word is determined to be palindrome regardless of case
            word = word.ToLower();
            for (int x = 0; x < n; x++, n--)
            {
                if (word[x] != word[n - 1])
                {
                    return false;
                }
            }

            return true;
        }

        // <summary>
        // palindromeSentenceCount():
        // Determine if string is palindrome
        //     Assumption that string is determined to be palindrome using lowercase as default
        // </summary>
        public static bool palindromeSentenceCount(string input)
        {
            input = RemoveWhitespace(input);
            string reverseinput = string.Empty;

            if (input != null)
            {
                for (int x = input.Length - 1; x >= 0; x--)
                {
                    reverseinput += input[x].ToString();
                }

                if (!input.Equals(reverseinput, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

        public static string RemoveWhitespace(string input)
        {
            var inputLength = input.Length;
            var newString = input.ToCharArray();
            int idx = 0;

            for (int i = 0; i < inputLength; i++)
            {
                var ch = newString[i];
                switch (ch)
                 {
                    case '\u0020': case '\u00A0': case '\u1680': case '\u2000': case '\u2001': 
                    case '\u2002': case '\u2003': case '\u2004': case '\u2005': case '\u2006': 
                    case '\u2007': case '\u2008': case '\u2009': case '\u200A': case '\u202F': 
                    case '\u205F': case '\u3000': case '\u2028': case '\u2029': case '\u0009': 
                    case '\u000A': case '\u000B': case '\u000C': case '\u000D': case '\u0085':
                        continue;
                    default:
                        newString[idx++] = ch;
                        break;
                }
            }

            return new string(newString, 0, idx);
        }
    }
}