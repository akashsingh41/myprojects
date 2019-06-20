using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpMaxOccuringWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> wordStore = new Dictionary<string,int>();
            StreamReader reader = new StreamReader(@"C:\akashsingh41\abc.txt");
            char[] delims = {' ', '.', '\n','\t','\b' };
            String text = reader.ReadToEnd();
            foreach (var word in text.Split(delims))
            {
                if(word != "" && !string.IsNullOrEmpty(word))
                {
                    //Console.WriteLine(word);
                    if (wordStore.ContainsKey(word))
                    {
                        wordStore[word]++;
                    }
                    else
                        wordStore.Add(word, 1);
                }
            }
            string result = wordStore.Aggregate((l, r) => l.Value > r.Value ? l : r).Key.ToString();
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
