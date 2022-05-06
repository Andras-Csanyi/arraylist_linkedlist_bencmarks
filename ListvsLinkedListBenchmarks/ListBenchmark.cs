namespace ArrayListAndLinkedListBenchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ListBenchmark
{
    private readonly Random _random = new();
    public Dictionary<int, int> Changes { get; set; }

    [Params(1000)]
    public int AmountOfChanges { get; set; }

    [Params(-15)]
    public int RandomLow { get; set; }

    [Params(15)]
    public int RandomHigh { get; set; }

    public List<int> List { get; set; }

    [Params(10000)]
    public int ListSize { get; set; }

    [GlobalSetup]
    public void Prep()
    {
        Changes = new Dictionary<int, int>();
        for (int i = 0; i < AmountOfChanges; i++) Changes.Add(i, _random.Next(RandomLow, RandomHigh));

        List = new List<int>(ListSize);
        for (int i = 0; i < ListSize; i++) List.Insert(i, i);

        Console.WriteLine("List size: " + List.Count);
        Console.WriteLine("Changes size: " + Changes.Count);
    }

    [Benchmark]
    public void AddChangesToList()
    {
        int startIndex = ListSize / 2;
        foreach (KeyValuePair<int, int> singleChangeKeyValuePair in Changes)
        {
            int workingIndex = startIndex + singleChangeKeyValuePair.Value;
            if (0 < workingIndex && workingIndex < List.Count - 1)
                List.Insert(workingIndex, singleChangeKeyValuePair.Value);

            startIndex = workingIndex;
        }
    }
}