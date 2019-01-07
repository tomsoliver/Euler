using System.Linq;
using System.Numerics;

namespace Algorithms.ProjectEuler10_99
{
    public static class _20FactorialDigitSum
    {
        //n! means n × (n − 1) × ... × 3 × 2 × 1

        //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

        //Find the sum of the digits in the number 100!
        public static int Execute()
        {
            BigInteger value = 1;

            for (var i = 2; i < 100; i++)
                value = value * i;

            return value.ToString().Select(s => int.Parse(s.ToString())).Sum();
        }

        public static int ShortVersion() => Enumerable.Range(1, 100)
            .Select(s => (BigInteger)s)
            .Aggregate((s, t) => s * t)
            .ToString()
            .Select(s => int.Parse(s.ToString()))
            .Sum();
    }
}
