using System;
using System.Diagnostics;
using Algorithms.ProjectEuler10_99;

namespace Algorithms
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var timer = new Stopwatch();

            timer.Start();
            var result = _11LargestProductInAGrid.Execute();
            timer.Stop();

            Console.WriteLine("*************************************");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Time taken: " + timer.Elapsed);
            Console.WriteLine("*************************************");
            Console.ReadLine();
        }
    }
}
