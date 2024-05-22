using BenchmarkDotNet.Attributes;
using System.Text;

namespace Benchmarks.Benchmarks
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net80, id: "String Benchmark Job")]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60, id: "String Benchmark Job")]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class StringProcessBenchmark
    {
        int counter = 1000;
        [Benchmark(Baseline = true)]
        public void Append()
        {
            string empty = string.Empty;

            for (int i = 0; i < counter; i++)
            {
                empty += i.ToString();
            }
        }

        [Benchmark()]
        public void AppendWithStringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder(counter);

            for (int i = 0; i < counter; i++)
            {
                stringBuilder.Append(i.ToString());
            }
        }
    }
}
