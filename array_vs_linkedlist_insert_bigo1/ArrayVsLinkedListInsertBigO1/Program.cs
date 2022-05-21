namespace ArrayListAndLinkedListBenchmarks;

using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        // Summary? sumList = BenchmarkRunner.Run<ListBenchmark>();
        Summary? sumLinkedList = BenchmarkRunner.Run<ListVsLinkedListVsLinkedListNodeBenchmark>();
    }
}