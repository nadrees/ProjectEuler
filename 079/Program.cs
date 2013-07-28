using Lib.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _079
{
    /// <summary>
    /// A common security method used for online banking is to ask the user for three random characters from a passcode. 
    /// For example, if the passcode was 531278, they may ask for the 2nd, 3rd, and 5th characters; the expected reply would be: 317.
    /// 
    /// The text file, keylog.txt, contains fifty successful login attempts.
    /// 
    /// Given that the three characters are always asked for in order, analyse the file so as to determine the shortest possible secret passcode of unknown length.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"keylog.txt");
            var graph = new Graph<int?>();

            foreach (var line in lines)
            {
                int? lastnum = null;
                for (int i = 0; i < line.Length; i++)
                {
                    var num = line.ParseDigit(i);
                    graph.AddValue(num, lastnum);
                    lastnum = num;
                }
            }

            var sorted = graph.TopologicalSort();

            Console.WriteLine(String.Join("", sorted));
            Console.ReadKey();
        }
    }
}
