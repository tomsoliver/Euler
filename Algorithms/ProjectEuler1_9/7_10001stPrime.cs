using Algorithms.Helpers;

namespace Algorithms.ProjectEuler
{
    public static class _7_10001stPrime
    {
        //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

        //What is the 10001st prime number?
        /// <summary>
        /// 500000 gives 7368787 and takes 5 seconds
        /// </summary>
        public static int Execute()
        {
            var maxPrimeCount = 500000;

            // Skip first 3 primes
            var primeCount = 3;
            var i = 3;

            while (primeCount <= maxPrimeCount)
            {
                i = i + 2;
                if (PrimeHelper.IsPrimeWithHistory(i))
                    primeCount++;
            }

            return i;
        }

        /// <summary>
        /// 500000 gives 7368787 and takes 8.3 seconds
        /// </summary>
        /// <returns></returns>
        public static int FirstRun()
        {
            var maxPrimeCount = 500000;
            var primeCount = 0;
            var i = 0;

            while (primeCount <= maxPrimeCount)
            {
                i++;
                if (PrimeHelper.IsPrime(i))
                    primeCount++;
            }

            return i;
        }
    }
}
