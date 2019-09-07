using System;
using System.Collections.Generic;
using System.IO;

namespace WordCount_by_dotNET_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[UTC: {DateTime.UtcNow:O}] Starting to read the file...");
            DateTime start = DateTime.UtcNow;
            var dictionary = new Dictionary<string, UInt64>();
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

            DateTime finish = DateTime.UtcNow;

            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine($"Word: \"{keyValuePair.Key}\" | count: {keyValuePair.Value}");
            }
            Console.WriteLine($"[UTC: {finish:O}] Finished");
            Console.WriteLine($"Elapsed: {(finish - start)}");
            Console.ReadKey();
        }
    }
}
