using System;

namespace Words
{
    class WordsStartUp
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            int total = Count(word, text);

            for (int i = 0; i < word.Length; i++)
            {
                string prefix = word.Substring(0, i);
                string suffinx = word.Substring(i, word.Length - i);

                total += Count(prefix, text) * Count(suffinx, text);
            }

            Console.WriteLine(total);

        }

        static int Count(string pattern, string text)
        {
            int count = 0;
            int lastMatchIndex = 0;

            while (lastMatchIndex < text.Length)
            {
                int index = text.IndexOf(pattern, lastMatchIndex);
                if (index < 0)
                {
                    break;
                }
                count++;
                lastMatchIndex = index + 1;
            }
            return count;
        }
    }
}


       



