using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Extensions;

namespace _052
{
    /// <summary>
    /// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
    /// 
    /// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                var digits = GetSortedDigits(i);
                bool isAnswer = false;

                for (int j = 2; j <= 6; j++)
                {
                    var num = i * j;
                    var newDigits = GetSortedDigits(num);

                    isAnswer = AreEqual(digits, newDigits);
                    if (!isAnswer)
                        break;
                }

                if (isAnswer)
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            Console.ReadKey();
        }

        private static bool AreEqual(int[] digits, int[] newDigits)
        {
            if (digits.Length != newDigits.Length)
                return false;

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != newDigits[i])
                    return false;
            }

            return true;
        }

        private static int[] GetSortedDigits(int i)
        {
            var num = i.ToString();
            var digits = new int[num.Length];

            for (int j = 0; j < num.Length; j++)
                digits[j] = num.ParseDigit(j);

            return digits.OrderBy(n => n).ToArray();
        }
    }
}
