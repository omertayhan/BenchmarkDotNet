using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarks.Benchmarks
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net80, baseline: true, id: "String Benchmark Job .Net 8")]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, id: "String Benchmark Job .Net 6")]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class DateTimeParserBenchmark
    {
        private string _dateTime;

        [GlobalSetup]
        public void Setup()
        {
            _dateTime = "2024-01-21T12:00:00";
        }

        [Benchmark(Baseline = true)]
        public int GetYearFromDate()
        {
            var dateTime = DateTime.Parse(_dateTime);
            return dateTime.Year;
        }

        [Benchmark()]
        public int GetYearFromSplit()
        {
            var splitArray = _dateTime.Split('-');
            return int.Parse(splitArray[0]);
        }

        [Benchmark()]
        public int GetYearFromSubStr()
        {
            var index = _dateTime.IndexOf("-");
            return int.Parse(_dateTime.Substring(0, index));
        }

        [Benchmark()]
        public int GetYearFromSpan()
        {
            ReadOnlySpan<char> span = _dateTime;
            var index = _dateTime.IndexOf('-');
            var yearAsSpan = span.Slice(0, index);

            var temp = 0;

            for (int i = 0; i < yearAsSpan.Length; i++)
            {
                temp *= 10 + (yearAsSpan[i] - '0');
            }
            return temp;
        }

        [Benchmark()]
        public int GetYearFromSpanWithManualConversion()
        {
            ReadOnlySpan<char> span = _dateTime;
            var index = _dateTime.IndexOf('-');
            return int.Parse(span.Slice(0, index));
        }
    }
}
