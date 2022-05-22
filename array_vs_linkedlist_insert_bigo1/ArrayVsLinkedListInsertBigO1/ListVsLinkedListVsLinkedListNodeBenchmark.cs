namespace ArrayListAndLinkedListBenchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser(false)]
// [SimpleJob(launchCount:1, warmupCount:5, targetCount:10)]
[ShortRunJob]
[RPlotExporter]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class ListVsLinkedListVsLinkedListNodeBenchmark
{
    public Dictionary<int, int[]> Changes { get; set; }

    [Params(100, 200, 300, 400, 500, 1000, 2000, 3000, 4000, 5000, 10000, 15000, 20000)]
    public int AmountOfChanges { get; set; }

    [Params(100)]
    public int SizeOfAppendedArrays { get; set; }

    public LinkedList<int> LinkedList { get; set; }
    public LLNode<int> PureLinkedList { get; set; }
    public List<int> List { get; set; }

    [Params(10000)]
    public int ListSize { get; set; }

    [GlobalSetup]
    public void Prepare()
    {
        LinkedList = new LinkedList<int>();
        for (int i = 0; i < ListSize; i++)
        {
            LinkedList.AddLast(i);
        }

        (LLNode<int> nodes, LLNode<int> lastNode) populateResult = PopulateLinkedListNodes(
            ListSize, null!);
        PureLinkedList = populateResult.nodes;

        List = new List<int>();
        for (int i = 0; i < ListSize; i++)
        {
            List.Insert(i, i);
        }

        Changes = new Dictionary<int, int[]>();
        for (int i = 1; i < AmountOfChanges + 1; i++)
        {
            int[] singleArray = new int[SizeOfAppendedArrays];
            for (int j = 0; j < SizeOfAppendedArrays; j++) singleArray[j] = i * 1000 + j;

            Changes.Add(i, singleArray);
        }
    }

    [GlobalCleanup]
    public void CleanUp()
    {
        LinkedList.Clear();
        PureLinkedList = null;
        List.Clear();
        Changes.Clear();
    }

    private (LLNode<int> node, LLNode<int> lastNode) PopulateLinkedListNodesRealValues(
        int count, int[] array, LLNode<int> previous)
    {
        LLNode<int> node = new();
        node.Value = array[count];
        node.Previous = previous;
        if (count > 0)
        {
            (LLNode<int> nodes, LLNode<int> lastNode) s = PopulateLinkedListNodesRealValues(
                count - 1, array, node);
            node.Next = s.nodes;
            return (node, s.lastNode);
        }

        return (node, node);
    }

    private (LLNode<int> nodes, LLNode<int> lastNode) PopulateLinkedListNodes(int count, LLNode<int> previous)
    {
        LLNode<int> node = new();
        node.Value = count;
        node.Previous = previous;
        if (count > 0)
        {
            (LLNode<int> nodes, LLNode<int> lastNode) s = PopulateLinkedListNodes(count - 1, node);
            node.Next = s.nodes;
            return (node, s.lastNode);
        }

        return (node, node);
    }

    /// <summary>
    ///     It adds changes to a LinkedList one by one.
    ///     The LinkedList is using the data structure provided by MS.
    /// </summary>
    [Benchmark]
    public void AddChangesToLinkedListOneByOne()
    {
        LinkedListNode<int> StartNode = LinkedList.First;

        foreach (KeyValuePair<int, int[]> change in Changes)
        {
            if (change.Key > 0)
                for (int i = 0; i < change.Key; i++)
                {
                    if (StartNode.Next is not null)
                    {
                        StartNode = StartNode.Next;
                    }
                    else
                    {
                        break;
                    }
                }

            foreach (int i in change.Value)
            {
                LinkedList.AddAfter(StartNode!, i);
            }
        }
    }

    /// <summary>
    ///     It inserts values into an array.
    ///     The new value inserts happen one-by-one.
    ///     It uses List<T> type.
    /// </summary>
    [Benchmark]
    public void AddChangesToListOneByOne()
    {
        int startIndex = 1;
        foreach (KeyValuePair<int, int[]> singleChange in Changes)
        {
            startIndex += singleChange.Key;
            foreach (int i in singleChange.Value) List.Insert(startIndex, i);
        }
    }

    /// <summary>
    ///     It inserts ranges to a list.
    ///     All the incoming changes, they are arrays, will be inserted as range.
    ///     It uses List<T> type.
    /// </summary>
    [Benchmark]
    public void AddChangesToListAsRanges()
    {
        int startIndex = 1;
        foreach (KeyValuePair<int, int[]> singleChangeKeyValuePair in Changes)
        {
            startIndex += singleChangeKeyValuePair.Key;
            if (0 < startIndex && startIndex < List.Count - 1)
                List.InsertRange(startIndex, singleChangeKeyValuePair.Value);
        }
    }

    /// <summary>
    ///     It merges the changes into the linked list as range.
    ///     It uses a custom linked list type.
    /// </summary>
    [Benchmark]
    public void AddChangesToLLNodesAsRanges()
    {
        LLNode<int> StartNode = PureLinkedList;

        foreach (KeyValuePair<int, int[]> change in Changes)
        {
            if (change.Key > 0)
                for (int i = 0; i < change.Key; i++)
                {
                    StartNode = StartNode.Next;
                }

            (LLNode<int> nodes, LLNode<int> lastNode) convertResult =
                PopulateLinkedListNodesRealValues(change.Value.Length - 1, change.Value, null!);
            LLNode<int> oldLastOne = StartNode.Next;
            StartNode.Next = convertResult.nodes;
            convertResult.nodes.Previous = StartNode;
            convertResult.lastNode.Next = oldLastOne;
        }

        PureLinkedList = StartNode;
    }

    public class LLNode<T>
    {
        public LLNode<T>? Previous { get; set; }
        public LLNode<T>? Next { get; set; }
        public T? Value { get; set; }
    }
}