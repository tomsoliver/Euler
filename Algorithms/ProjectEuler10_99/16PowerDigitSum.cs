using System;
using System.Linq;
using System.Numerics;

namespace Algorithms.ProjectEuler10_99
{
    public static class _16PowerDigitSum
    {
        // 215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

        // What is the sum of the digits of the number 21000?
        public static BigInteger Execute()
        {
            BigInteger result = 2;
            for (int i = 2; i <= 1000; i++)
                result = result * 2;

            return result.ToString().Select(s => int.Parse(s.ToString())).Sum();
        }
    }
}