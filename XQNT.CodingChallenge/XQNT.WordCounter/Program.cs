using System;
using System.IO;
using System.Linq;
using System.Text;

namespace XQNT.WordCounter
{
    class Program
    {
        /// <summary>
        /// Goal: Find to 5 most frequently used words of length 5 characters and more.
        /// And print them.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var text = File.ReadAllText("kobzar.txt");

            var delimiters = new char[] { ' ', ',', '.', '!', '?', '\"', '“', '”', '(', ')', '«', '»', '—', '-', '…', '\n' };

            var wordList = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var top5FrequentWords = wordList.Where(x => x.Length >= 5)
                .GroupBy(x => x.ToLower())
                .Select(x => new { Word = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5);

            Console.OutputEncoding = Encoding.UTF8;

            foreach (var item in top5FrequentWords.Select((value, index) => new { value, Position = index + 1 }))
                Console.WriteLine($"{item.Position}. {item.value.Word}, Count:{item.value.Count}");
        }
    }
}
