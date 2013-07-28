using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022
{
    /// <summary>
    /// Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// 
    /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
    /// 
    /// What is the total of all the name scores in the file?
    /// </summary>
    class Program
    {
        private static String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            var names = (from l in File.ReadAllText(@"names.txt").Split(',')
                         orderby l ascending
                         select l.Replace("\"", String.Empty))
                        .ToArray()
                        .Select((name, index) =>
                        {
                            int sum = 0;
                            for (int j = 0; j < name.Length; j++)
                            {
                                var letter = name.Substring(j, 1);
                                sum += (alphabet.IndexOf(letter) + 1);
                            }
                            return sum * ((long)(index + 1));
                        })
                        .Sum();

            Console.WriteLine(names);
            Console.ReadKey();
        }
    }
}
