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
            var result = _21AmicableNumbers.Execute();
            timer.Stop();

            Debug.WriteLine("*************************************");
            Debug.WriteLine("Result: " + result);
            Debug.WriteLine("Time taken: " + timer.Elapsed);
            Debug.WriteLine("*************************************");
        }
    }
}
