using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _050
{
    /// <summary>
    /// The prime 41, can be written as the sum of six consecutive primes:
    /// 
    /// 41 = 2 + 3 + 5 + 7 + 11 + 13
    /// 
    /// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
    /// 
    /// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    /// 
    /// Which prime, below one-million, can be written as the sum of the most consecutive primes?
    /// </summary>
    class Program
    {
        public static void Main(String[] args)
        {
            var primes = new SievePrimeNumberGenerator().GetPrimesBelowIntMaxValue().TakeWhile(p => p <= 1000000).ToArray();

            for (int i = 2; i < primes.Length; i++)
            {
                for (int start = 0; start < primes.Length - i; start++)
                {
                    int[] digits = new int[i];
                    for (int offset = 0; offset < i; offset++)
                        digits[offset] = primes[start + offset];

                    int sumOfDigits = 0;

                    try
                    {
                        sumOfDigits = digits.Sum();
                    }
                    catch (ArithmeticException)
                    {
                        // number overflowed what int could handle, clearly not < 1 million
                        continue;
                    }

                    if (sumOfDigits >= 1000000)
                        break;
                    else if (primes.Contains(sumOfDigits))
                    {
                        Console.WriteLine("{0}: {1}", i, sumOfDigits);
                        break;
                    }
                }
            }

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
