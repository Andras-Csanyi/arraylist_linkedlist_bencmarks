namespace ArrayListAndLinkedListBenchmarks;

using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        Summary? sum = BenchmarkRunner.Run<ListBenchmark>();
    }
}