using System;
using System.Collections.Generic;
using System.IO;

namespace WordCount_by_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.UtcNow;
            Console.WriteLine($"[UTC: {start:O}] Starting to read the file...");
            var dictionary = new Dictionary<string, UInt64>(1000);
            string[] words = File.ReadAllText("Text.txt").Split(
                new char[] { '\n', '\r', ' ', '.', ',', '!', '?', ':', ';', '"', '\'', 't', '(', ')', '[', ']', '{', '}' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary[word] = 1;
                }

            }

            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine($"Word: \"{keyValuePair.Key}\" | count: {keyValuePair.Value}");
            }
            DateTime finish = DateTime.UtcNow;
            Console.WriteLine($"[UTC: {finish:O}] Finished");
            Console.WriteLine($"Elapsed: {(finish - start)}");
            Console.ReadKey();
        }
    }
}
