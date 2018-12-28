using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Algorithms.Helpers
{
    public static class PrimeHelper
    {
        // Skip 1 
        private static readonly HashSet<double> Primes = new HashSet<double>
        {
            2, 3
        };
        private static double _maxPrime = 3; 

        public static bool IsPrime(double value)
        {
            // Determine if even
            if (Math.Abs(value % 2) < double.Epsilon && Math.Abs(value - 2) > double.Epsilon) return false;

            // If not, test only odd factors
            var max = Math.Ceiling(Math.Sqrt(value));
            for (var i = 3; i <= max; i = i + 2)
            {
                if (Math.Abs(value % i) < double.Epsilon) return false;
            }
            return true;
        }

        /// <summary>
        /// Uses a hashset of primes to determine if a value is prime.
        /// It will ensure all primes below the max prime value are in
        /// a hashset, and will divide the incoming value by all stored primes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPrimeWithHistory(double value)
        {
            if (Primes.Contains(value)) return true;

            // If even, don't even bother to process
            if (Math.Abs(value % 2) < double.Epsilon && Math.Abs(value - 2) > double.Epsilon) return false;

            // If not, test only prime factors
            var max = Math.Ceiling(Math.Sqrt(value));

            // Get all primes less than max - This allows division by only primes
            // as apposed to every odd number
            for (var i = _maxPrime + 2; i <= max; i = i + 2)
            {
                if (Primes.Contains(i)) continue;
                if (!IsPrime(i)) continue;

                Primes.Add(i);
                _maxPrime = i;
            }

            foreach (var prime in Primes)
            {
                if (prime > max) break;
                if (Math.Abs(value % prime) < double.Epsilon) return false;
            }
            return true;
        }

        public static IEnumerable<double> GetAllPrimesLessThanValue(double value)
        {
            // Find next largest prime
            if (Primes.Any(s => s > value)) return Primes.Where(s => s < value).ToList();

            // Get next potential prime
            var nextPotentialPrime = _maxPrime;
            while (true)
            {
                nextPotentialPrime++;
                if (!IsPrimeWithHistory(nextPotentialPrime)) continue;

                Primes.Add(nextPotentialPrime);
                _maxPrime = nextPotentialPrime;
                if (_maxPrime < value) continue;
                break;
            }

            return Primes.Where(s => s < value);
        }
    }
}
