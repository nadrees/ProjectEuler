using Lib.PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public enum NumberAbundancy
    {
        Abundant,
        Perfect,
        Deficient
    }

    public static class IntegerExtensions
    {

        public static String ToBase(this int n, int targetBase)
        {
            String result = String.Empty;

            var stack = new Stack<BigInteger>();
            
            int num = 1;
            BigInteger power = BigInteger.One;
            do
            {
                stack.Push(power);
                power = targetBase.ToPower(num++);
            }
            while (power < n);

            var workingNum = new BigInteger(n);
            while (stack.Count > 0)
            {
                power = stack.Pop();
                var count = workingNum / power;
                result += count;
                workingNum -= count * power;
            }

            return result;
        }

        public static BigInteger Choose(this int n, int r)
        {
            var numerator = n.Factorial();
            var denominator = r.Factorial() * (n - r).Factorial();
            return numerator / denominator;
        }

        public static BigInteger Factorial(this int n)
        {
            var start = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                start *= i;

            return start;
        }

        private static readonly Dictionary<int, NumberAbundancy> abundancyCache = new Dictionary<int, NumberAbundancy>();
        public static NumberAbundancy GetAbundancy(this int n)
        {
            if (!abundancyCache.ContainsKey(n))
            {
                NumberAbundancy value;

                var divisorsSum = n.GetAllDivisors().Sum();
                if (divisorsSum > n)
                    value = NumberAbundancy.Abundant;
                else if (divisorsSum == n)
                    value = NumberAbundancy.Perfect;
                else
                    value = NumberAbundancy.Deficient;

                abundancyCache[n] = value;
            }

            return abundancyCache[n];
        }

        public static BigInteger ToPower(this int n, int power)
        {
            var result = new BigInteger(n);
            for (int i = 2; i <= power; i++)
                result *= n;

            return result;
        }

        public static IEnumerable<int> GetAllDivisors(this int n)
        {
            return from a in Enumerable.Range(1, n / 2)
                   where n % a == 0
                   select a;
        }

        private static CachedPrimeNumberGenerator generator = new CachedPrimeNumberGenerator(new SievePrimeNumberGenerator());
        private static readonly Object lockObj = new Object();
        public static IEnumerable<int> PrimeFactorize(this int value)
        {
            int[] primes;

            lock (lockObj)
            {
                primes = generator.GetPrimesBelowIntMaxValue().TakeWhile(p => p <= value).ToArray();
            }

            return PrimeFactorize(value, primes);
        }

        private static IEnumerable<int> PrimeFactorize(int value, int[] primes)
        {
            if (primes.Contains(value))
                return new[] { value };

            var primeFactors = new List<int>();

            if (value >= 2)
            {
                foreach (var prime in primes)
                {
                    while (value % prime == 0)
                    {
                        primeFactors.Add(prime);
                        value /= prime;
                    }

                    if (value < 2)
                        break;
                }
            }

            return primeFactors;
        }

        public static BigInteger SumOfSquares(this int n)
        {
            return Enumerable.Range(1, n)
                .Select(i => new BigInteger(i))
                .Select(bi => bi * bi)
                .Aggregate(new BigInteger(0), (sum, bi) => sum += bi);
        }

        public static BigInteger SquareOfSum(this int n)
        {
            var sum = Enumerable.Range(1, n)
                .Select(i => new BigInteger(i))
                .Aggregate(new BigInteger(0), (s, bi) => s += bi);
            return sum * sum;
        }

        public static int[] GetAllRotations(this int n)
        {
            var str = n.ToString();
            if (str.Length == 1)
                return new int[] { n };

            int[] rotations = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str = str.RotateLeft();
                rotations[i] = int.Parse(str);
            }

            return rotations;
        }

        public static String Spell(this int n)
        {
            if (n > 9999)
                throw new ArgumentOutOfRangeException();

            if (n >= 1000)
            {
                int thousandPart = n / 1000;
                int remainder = n % 1000;

                return String.Format("{0} thousand {1}", Spell(thousandPart), Spell(remainder)).TrimEnd(' ');
            }
            else if (n >= 100)
            {
                int hundredPart = n / 100;
                int remainder = n % 100;

                if (remainder == 0)
                    return String.Format("{0} hundred", Spell(hundredPart));
                else
                    return String.Format("{0} hundred and {1}", Spell(hundredPart), Spell(remainder));
            }
            else if (n >= 20)
            {
                int tensPart = n / 10;
                int remainder = n % 10;

                switch (tensPart)
                {
                    case 2:
                        return String.Format("twenty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 3:
                        return String.Format("thirty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 4:
                        return String.Format("forty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 5:
                        return String.Format("fifty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 6:
                        return String.Format("sixty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 7:
                        return String.Format("seventy-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 8:
                        return String.Format("eighty-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    case 9:
                        return String.Format("ninety-{0}", Spell(remainder)).TrimEnd(' ', '-');
                    default:
                        throw new ArgumentException(n.ToString());
                }
            }
            else if (n >= 16)
            {
                if (n == 18)
                    return "eighteen";
                else
                {
                    int remainder = n % 10;

                    return String.Format("{0}teen", Spell(remainder));
                }
            }
            else
            {
                switch (n)
                {
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    case 4:
                        return "four";
                    case 5:
                        return "five";
                    case 6:
                        return "six";
                    case 7:
                        return "seven";
                    case 8:
                        return "eight";
                    case 9:
                        return "nine";
                    case 10:
                        return "ten";
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    default:
                        return "";
                }
            }
        }
    }
}
