using System;
using System.Collections.Generic;

namespace WordCountAndFrequency
{
    public class Phrase
    {
        public static Dictionary<string, int> WordCount(string phrase)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            char[] delimiters = new char[] { ' ', ',' };
            string[] split = phrase.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            split = RemoveSpecialChars(split);
            dictionary = CountOccuranceOfWord(dictionary, split); 

            return dictionary; 
        }

        private static string[] SanitiseStringInputs(string[] words)
        {

            return words; 
        }

        private static string[] RemoveSpecialChars(string[] wordsToCount)
        {
            var stack = new Stack<string>();

            for (int i = 0; i < wordsToCount.Length; i++)
            {
                var word = "";

                for (int j = 0; j < wordsToCount[i].Length; j++)
                {
                    if (Char.IsLetterOrDigit(wordsToCount[i][j]) || ApostropheHandling(wordsToCount[i], j))
                        word += wordsToCount[i][j];
                }

                if(word.Length != 0)
                    stack.Push(word);
            }

            var strArr = new string[stack.Count];
            stack.CopyTo(strArr, 0);

            return strArr;
        }

        private static bool ApostropheHandling(string word, int iterator)
        {
            bool returnVal = false;

            if(word[iterator] == '\'')
                if(iterator != 0 && (iterator + 1) < word.Length)
                    if (Char.IsLetter(word[iterator - 1]) && Char.IsLetter(word[iterator + 1]))
                        returnVal = true;                     

            return returnVal;
        }

        private static Dictionary<string, int> CountOccuranceOfWord(Dictionary<string, int> dictionary, string[] wordsToCount)
        {
            for (int i = 0; i < wordsToCount.Length; i++)
            {
                string word = "";

                word = wordsToCount[i].ToLower();

                if (dictionary.ContainsKey(word))
                {
                    int val = dictionary[word];
                    val++;
                    dictionary[word] = val;
                }
                else
                    dictionary.Add(word, 1);
            }
            return dictionary; 
        }
    }
}
