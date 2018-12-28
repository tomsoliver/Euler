using System.Linq;
using Algorithms.Helpers;

namespace Algorithms.ProjectEuler10_99
{
    public static class _10SummationOfPrimes
    {
        //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

        //Find the sum of all the primes below two million.
        public static long Execute()
        {
            const int max = 2000000;

            long sum = 0;
            for(var i = 2; i < max; i++)
            {
                if (PrimeHelper.IsPrimeWithHistory(i)) sum += i;
            }

            return sum;
        }
    }
}
