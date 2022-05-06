namespace ArrayListAndLinkedListBenchmarks;

public class LinkedListBenchmark
{
    private readonly LinkedList<int> _linkedList = new();

    public void CreateLinkedList(int listSize)
    {
        for (int i = 0; i < listSize; i++) _linkedList.AddLast(i);
    }

    public void AddChangesToLinkedList()
    {
    }
}