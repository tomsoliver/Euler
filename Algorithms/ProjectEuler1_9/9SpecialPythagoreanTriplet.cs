using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ProjectEuler
{
    //A Pythagorean triplet is a set of three natural numbers, a < b<c, for which,

    //a2 + b2 = c2
    //For example, 32 + 42 = 9 + 16 = 25 = 52.

    //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    //Find the product abc.
    
    // Gives the answer 31875000 and takes 0.025 seconds
    // Using Euclids formula for pythagorean triples
    // Gives the answer 31875000 and takes 0.0008 seconds
    public static class _9SpecialPythagoreanTriplet
    {
        public static int Execute()
        {
            const int max = 1000;
            const int euclidValue = max / 2;
            const int valueToBreak = euclidValue / 2;

            var m = 0;
            int n;

            while (true)
            {
                m++;
                if (m > valueToBreak) throw new Exception("Euclid Formula Failed");
                var nDouble = (euclidValue - Math.Pow(m, 2)) / m;

                if (m < nDouble) continue;
                if (Math.Abs(nDouble % 1) > double.Epsilon) continue;

                n = (int)nDouble;
                break;
            }

            // Factor in k
            var a = Math.Pow(m, 2) - Math.Pow(n, 2);
            var b = 2 * m * n;
            var c = Math.Pow(m, 2) + Math.Pow(n, 2);

            if (Math.Abs(a + b + c - max) > double.Epsilon) throw new Exception("Formula failed");

            return (int) (a * b * c);
        }

        // Gives the answer 31875000 and takes 10 seconds
        public static int FirstRun()
        {
            for (var a = 1; a < 1000; a++)
            {
                for (var b = a; b < 1000; b++)
                {
                    for (var c = b; c < 1000; c++)
                    {
                        if (Math.Pow(a, 2) + Math.Pow(b, 2) != Math.Pow(c, 2)) continue;

                        if (a + b + c == 1000) return a * b * c;
                    }
                }
            }

            throw new Exception("Answer not found");
        }

        // Gives the answer 31875000 and takes 0.025 seconds
        public static int SecondRun()
        {
            for (var a = 1; a <= 1000; a++)
            {
                for (var b = a; b <= 1000 - a; b++)
                {
                    var c = 1000 - a - b;
                    if (Math.Pow(a, 2) + Math.Pow(b, 2) != Math.Pow(c, 2)) continue;

                    return a * b * c;
                }
            }

            throw new Exception("Answer not found");
        }
    }
}
