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
