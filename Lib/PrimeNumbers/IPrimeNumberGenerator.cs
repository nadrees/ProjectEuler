using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.PrimeNumbers
{
    public interface IPrimeNumberGenerator
    {
        IEnumerable<int> GetPrimesBelowIntMaxValue();
        IEnumerable<long> GetPrimesBelowLongMaxValue();
    }
}
