using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019
{
    /// <summary>
    /// You are given the following information, but you may prefer to do some research for yourself.
    /// 
    /// * 1 Jan 1900 was a Monday.
    /// 
    /// * Thirty days has September,
    /// April, June and November.
    /// All the rest have thirty-one,
    /// Saving February alone,
    /// Which has twenty-eight, rain or shine.
    /// And on leap years, twenty-nine.
    /// 
    /// *A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    /// 
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(1899, 12, 31);

            var start = new DateTime(1901, 1, 1);
            var end = new DateTime(2000, 12, 31);

            int count = 0;
            while (date <= end)
            {
                if (date >= start && date.Day == 1)
                    count++;

                date += new TimeSpan(7, 0, 0, 0, 0);
            }

            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
