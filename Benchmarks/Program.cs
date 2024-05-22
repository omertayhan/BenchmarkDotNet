using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using System;

namespace BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DateTimeParserBenchmark>();

            Console.ReadLine();
        }
    }
}