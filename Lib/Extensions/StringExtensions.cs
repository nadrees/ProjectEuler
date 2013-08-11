using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class StringExtensions
    {
        private static String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static int GetAlphabetScore(this String s)
        {
            int sum = 0;
            for (int j = 0; j < s.Length; j++)
            {
                var letter = s.Substring(j, 1);
                sum += (alphabet.IndexOf(letter) + 1);
            }
            return sum;
        }

        public static IEnumerable<String> GeneratePermutations(this String s)
        {
            if (s == null || s.Length == 0)
                yield return String.Empty;
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    var prefix = Convert.ToString(s[i]);
                    var allSubPermutations = GeneratePermutations(s.Substring(0, i) + s.Substring(i + 1));
                    foreach (var subPermutation in allSubPermutations)
                        yield return prefix + subPermutation;
                }
            }
        }

        public static bool IsPalindrome(this String s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return false;

            return new String(s.ToLower().Reverse().ToArray()) == s.ToLower();
        }

        public static int ParseDigit(this String s, int position)
        {
            return int.Parse(new String(new[] { s[position] }));
        }

        public static String RotateLeft(this String s)
        {
            if (s == null)
                return null;
            else if (s.Length == 1)
                return s;

            var firstChar = s.Substring(0, 1);
            return s.Substring(1) + firstChar;
        }

        public static bool IsPandigital(this String s)
        {
            if (s == null)
                return false;

            bool oneUsed = false, twoUsed = false, threeUsed = false,
                fourUsed = false, fiveUsed = false, sixUsed = false,
                sevenUsed = false, eightUsed = false, nineUsed = false;

            for (int i = 0; i < s.Length; i++)
            {
                int digit = s.ParseDigit(i);
                switch (digit)
                {
                    case 0:
                        return false;
                    case 1:
                        if (oneUsed)
                            return false;
                        oneUsed = true;
                        break;
                    case 2:
                        if (twoUsed)
                            return false;
                        twoUsed = true;
                        break;
                    case 3:
                        if (threeUsed)
                            return false;
                        threeUsed = true;
                        break;
                    case 4:
                        if (fourUsed)
                            return false;
                        fourUsed = true;
                        break;
                    case 5:
                        if (fiveUsed)
                            return false;
                        fiveUsed = true;
                        break;
                    case 6:
                        if (sixUsed)
                            return false;
                        sixUsed = true;
                        break;
                    case 7:
                        if (sevenUsed)
                            return false;
                        sevenUsed = true;
                        break;
                    case 8:
                        if (eightUsed)
                            return false;
                        eightUsed = true;
                        break;
                    case 9:
                        if (nineUsed)
                            return false;
                        nineUsed = true;
                        break;
                }
            }

            return oneUsed && twoUsed && threeUsed && fourUsed && fiveUsed && sixUsed && sevenUsed && eightUsed && nineUsed;
        }
    }
}
