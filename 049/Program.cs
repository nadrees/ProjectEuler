using Lib.PrimeNumbers;
using Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _049
{
    /// <summary>
    /// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
    /// 
    /// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    /// 
    /// What 12-digit number do you form by concatenating the three terms in this sequence?
    /// </summary>
    class Program
    {
        const String knownSequence = "148748178147";

        static void Main(string[] args)
        {
            // we know we only need 4 digit primes
            var primes = new SievePrimeNumberGenerator().GetPrimesBelowIntMaxValue().SkipWhile(p => p < 1000).TakeWhile(p => p <= 9999).ToList();

            // get all combinations where the primes form an arithmetic sequence
            var sequences = from p1 in primes
                            from p2 in primes
                            from p3 in primes
                            where p1 < p2 && p2 < p3
                            where p2 - p1 == p3 - p2
                            select new
                            {
                                p1 = p1.ToString(),
                                p2 = p2.ToString(),
                                p3 = p3.ToString()
                            };
            
            // filter to only the sequences that are permutations of each other
            var perms = from tuple in sequences
                        where tuple.p1.GeneratePermutations().Contains(tuple.p2)
                        where tuple.p2.GeneratePermutations().Contains(tuple.p3)
                        select tuple.p1 + tuple.p2 + tuple.p3;

            // find the only sequence which isn't the known one
            var ans = perms.First(p => p != knownSequence);
            
            Console.WriteLine(ans);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
