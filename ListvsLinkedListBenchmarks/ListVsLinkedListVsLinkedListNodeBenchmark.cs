namespace ArrayListAndLinkedListBenchmarks;

using BenchmarkDotNet.Attributes;

public class ListVsLinkedListVsLinkedListNodeBenchmark
{
    private readonly Random _random = new();
    public Dictionary<int, int[]> Changes { get; set; } = new Dictionary<int, int[]>();

    [Params(10)]
    public int AmountOfChanges { get; set; }

    [Params(10)]
    public int SizeOfAppendedArrays { get; set; }

    [Params(-5)]
    public int RandomLow { get; set; }

    [Params(5)]
    public int RandomHigh { get; set; }

    public LinkedList<int> LinkedList { get; set; }
    public LinkedList<int> PureLinkedList { get; set; }
    public List<int> List { get; set; }

    [Params(100)]
    public int ListSize { get; set; }

    [GlobalSetup]
    public void Prepare()
    {
        // set up initial list/linkedlist size
        LinkedList = new LinkedList<int>();
        for (int i = 0; i < ListSize; i++)
        {
            LinkedList.AddLast(i);
        }

        PureLinkedList = new LinkedList<int>();
        for (int i = 0; i < ListSize; i++)
        {
            PureLinkedList.AddLast(i);
        }

        List = new List<int>(ListSize);
        for (int i = 0; i < ListSize; i++)
        {
            List.Insert(i, i);
        }

        // prepare the arrays to be appended to the original lists/arrays
        for (int i = 0; i < AmountOfChanges; i++)
        {
            int[] singleArray = new int[SizeOfAppendedArrays];
            for (int j = 0; j < SizeOfAppendedArrays - 1; j++)
            {
                singleArray[j] = j;
            }

            Changes.Add(_random.Next(RandomLow, RandomHigh), singleArray);
        }


        Console.WriteLine("LinkedList size: " + LinkedList.Count);
        Console.WriteLine("Changes size: " + Changes.Count);
    }

    [Benchmark]
    public void AddChangesToLinkedList()
    {
        int startPosition = ListSize / 2;

        LinkedListNode<int> StartNode = LinkedList.First;
        for (int i = 0; i < startPosition; i++)
        {
            StartNode = StartNode.Next;
        }

        foreach (KeyValuePair<int, int[]> change in Changes)
        {
            LinkedListNode<int> Node = StartNode;
            if (change.Key < 0)
            {
                for (int i = 0; i > change.Key; i--)
                {
                    Node = Node.Previous;
                }
            }

            if (change.Key > 0)
            {
                for (int i = 0; i < change.Key; i++)
                {
                    Node = Node.Next;
                }
            }

            LinkedList<int> appendedList = new LinkedList<int>(change.Value);
            LinkedList.AddAfter(Node, appendedList.First);
        }
    }

    [Benchmark]
    public void AddChangesToList()
    {
        int startIndex = ListSize / 2;
        foreach (KeyValuePair<int, int[]> singleChangeKeyValuePair in Changes)
        {
            int workingIndex = startIndex + singleChangeKeyValuePair.Key;
            if (0 < workingIndex && workingIndex < List.Count - 1)
                List.InsertRange(workingIndex, singleChangeKeyValuePair.Value);

            startIndex = workingIndex;
        }
    }

    [Benchmark]
    public void AddChangesToLinkedListNodes()
    {
        int startIndex = ListSize / 2;

        LinkedListNode<int> StartNode = PureLinkedList.First;
        for (int i = 0; i < startIndex; i++)
        {
            StartNode = StartNode.Next;
        }

        foreach (KeyValuePair<int, int[]> change in Changes)
        {
            LinkedListNode<int> Node = StartNode;
            if (change.Key < 0)
            {
                for (int i = 0; i > change.Key; i--)
                {
                    Node = Node.Previous;
                }
            }

            if (change.Key > 0)
            {
                for (int i = 0; i < change.Key; i++)
                {
                    Node = Node.Next;
                }
            }

            LinkedList<int> appendedList = new LinkedList<int>(change.Value);
            // create your own node
        }
    }
}