using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.UtcNow;
            Console.WriteLine($"[UTC: {start:O}] Starting to read the file...");
            var dictionary = new Dictionary<string, UInt64>(1000);
            var words = Regex.Matches(File.ReadAllText("Text.txt"), "\\w+").Cast<Match>().Select(m => m.Value);

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
                Console.WriteLine($"Word: {keyValuePair.Key.PadRight(20)} | count: {keyValuePair.Value}");
            }
            DateTime finish = DateTime.UtcNow;
            Console.WriteLine($"[UTC: {finish:O}] Finished");
            Console.WriteLine($"Elapsed: {(finish - start)}");
            Console.ReadKey();
        }
    }
}
