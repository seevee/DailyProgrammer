// arguments: "C:\Users\Vinny\Documents\Visual Studio 2012\Projects\Daily Programmer\125_Word Analytics\Latin-Lipsum.txt"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _125_Word_Analytics
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filepath = args[0];

            // Test filepath
            string filePath = @"C:\Users\Vinny\Documents\Visual Studio 2012\Projects\Daily Programmer\125_Word Analytics\Latin-Lipsum.txt";

            string text = System.IO.File.ReadAllText(filePath);
            string[] lines = System.IO.File.ReadAllLines(filePath);

            // Test text
            //text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";


            // Number of words
            string[] words = text.Split(new string[] {" ", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
            int numWords = words.Length;


            // Number of letters
            int numLetters = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                    numLetters ++;
            }


            // Number of symbols
            int numSymbols = 0;
            foreach (char c in text)
            {
                if (char.IsPunctuation(c))
                    numSymbols ++;
            }


            // Most common words
            var dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            foreach (string word in words)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word] = dictionary[word] + 1;
                else
                    dictionary[word] = 1;
            }

            var sortedDictionary = from item in dictionary
                              orderby item.Value descending
                              select item;

            string[] commonWords = new string[3];
            int count = 0;

            foreach (KeyValuePair<string, int> item in sortedDictionary.Take(3))
            {
                commonWords[count] = item.Key;
                count++;
            }


            // Words appearing once
            var dictionaryOne = dictionary;

            foreach (var item in dictionaryOne.Where(kvp => kvp.Value != 1).ToList())
            {
                dictionaryOne.Remove(item.Key);
            }

            dictionaryOne.Keys.ToArray();

            string oneWord_KeysValues = string.Join("", dictionaryOne);



            Console.WriteLine(numWords + " words");
            Console.WriteLine(numLetters + " letters");
            Console.WriteLine(numSymbols + " symbols");
            Console.WriteLine("Top three most common words: {0}, {1}, {2}", commonWords[0], commonWords[1], commonWords[2]);
            Console.WriteLine("Words only used once: {0}", oneWord_KeysValues);
            Console.ReadKey();
        }
    }
}
