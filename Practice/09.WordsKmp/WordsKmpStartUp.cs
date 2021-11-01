using System;
using System.Linq;


namespace WordsKmp
{
    class WordsKmpStartUp
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            //Prefix
            var prefixMatches = new int[word.Length + 1];
            Kmp(word, text, prefixMatches);

            ////Printing prefix
            //for (int i = 0; i <= word.Length; i++)
            //{
            //    Console.WriteLine(word.Substring(0, i) + " -> " + prefixMatches[i]);
            //}

            //Suffix
            word = new string(word.Reverse().ToArray());
            text = new string(text.Reverse().ToArray());
                   
            var suffixMatches = new int[word.Length + 1];
            Kmp(word, text, suffixMatches);

            ////Printing suffix
            //for (int i = 0; i <= word.Length; i++)
            //{
            //    Console.WriteLine(word.Substring(word.Length - i, i) + " -> " + suffixMatches[i]);
            //}

            int total = prefixMatches[word.Length];
            for (int i = 1; i < word.Length; i++)
            {
                total += prefixMatches[i] * suffixMatches[word.Length - i];
            }

            Console.WriteLine(total);

        }

        static void Kmp(string pattern, string text, int[] preffixMatches)
        {
            var failLink = new int[pattern.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;

            //precompute
            for (int i = 1; i < pattern.Length; i++)
            {
                int j = failLink[i];
                while (j >= 0 && pattern[i] != pattern[j])
                {
                    j = failLink[i];
                }
                ++j;

                failLink[i + 1] = j;
            }

            //serach
            int matched = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (matched >= 0 && text[i] != pattern[matched])
                {
                    matched = failLink[matched];
                }

                ++matched;


                //counts all partial occurances
                for (int j = matched; j > 0 ; j = failLink[j])
                {
                    preffixMatches[j]++;
                }

                if (matched == pattern.Length)
                {
                    matched = failLink[matched];
                }
            }
        }
    }
}
