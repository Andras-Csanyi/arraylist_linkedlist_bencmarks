namespace ListvsLinkedListBenchmarks.Unit.Tests;

using System.Collections.Generic;
using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class AddChangesToLLNodeAsRanges_Should
{
    [Fact]
    public void MakeTheChangesInTheRightOrder()
    {
        Dictionary<int, int[]> changes = new Dictionary<int, int[]>();
        changes.Add(1, new int[] { 101, 102, 103, 104 });
        changes.Add(2, new int[] { 201, 202, 203, 204 });

        List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        ListVsLinkedListVsLinkedListNodeBenchmark benchmark = new ListVsLinkedListVsLinkedListNodeBenchmark
        {
            Changes = changes,
            ListSize = 10
        };

        int[] expectedLL = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        int[] expectedResult = new[] { 10, 9, 104, 103, 204, 203, 202, 201, 102, 101, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        benchmark.Prepare();

        // the creation of the LLNode list is also tested since it is custom code
        ListVsLinkedListVsLinkedListNodeBenchmark.LLNode<int> tmp = benchmark.PureLinkedList;
        for (int i = 0; i < expectedLL.Length; i++)
        {
            tmp.Value.Should().Be(expectedLL[i]);
            tmp = tmp.Next;
        }

        // Act
        benchmark.AddChangesToLLNodesAsRanges();

        // adding operation ends somewhere in the middle of the linked list
        // this way we can step back to the head
        ListVsLinkedListVsLinkedListNodeBenchmark.LLNode<int> turnback = benchmark.PureLinkedList;
        while (turnback.Previous != null)
        {
            turnback = turnback.Previous;
        }

        // from the head we check the order
        ListVsLinkedListVsLinkedListNodeBenchmark.LLNode<int> node = turnback;
        for (int i = 0; i < expectedResult.Length; i++)
        {
            node.Value.Should().Be(expectedResult[i]);
            node = node.Next;
        }
    }
}