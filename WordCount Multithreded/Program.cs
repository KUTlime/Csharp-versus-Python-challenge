using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount_Multithreded
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[UTC: {DateTime.UtcNow:O}] Starting to read the file...");
            DateTime start = DateTime.UtcNow;
            //ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
            var dictionary = new ConcurrentDictionary<string, UInt64>(16, 10000);
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

            DateTime finish = DateTime.UtcNow;
            Parallel.ForEach(dictionary, keyValuePair =>
            {
                Console.WriteLine($"Word: {keyValuePair.Key.PadRight(20)} | count: {keyValuePair.Value}");
            }
            );
            Console.WriteLine($"[UTC: {finish:O}] Finished");
            Console.WriteLine($"Elapsed: {(finish - start)}");
            Console.ReadKey();
        }
    }
}
