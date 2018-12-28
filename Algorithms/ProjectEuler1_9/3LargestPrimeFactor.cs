using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.ProjectEuler
{
    public static  class _3LargestPrimeFactor
    {
        //The prime factors of 13195 are 5, 7, 13 and 29.

        //What is the largest prime factor of the number 600851475143 ?
        public static long Execute()
        {
            const long value = 600851475143124542;
            long largestPrime = 0;
            var max = Math.Ceiling(Math.Sqrt(value));

            for (long i = 2; i < max; i++)
            {
                if (value % i != 0) continue;
                
                if (PrimeHelper.IsPrime(i))
                    largestPrime = i;

                var divider = value / i;

                if (!PrimeHelper.IsPrime(divider)) continue;

                largestPrime = divider;
                i = divider;
            }

            return largestPrime;
        }
    }
}
