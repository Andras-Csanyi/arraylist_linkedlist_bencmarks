namespace ListvsLinkedListBenchmarks.Unit.Tests;

using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class LinkedListBenchmark_Should
{
    [Fact]
    public void MakeTheChanges()
    {
        ListVsLinkedListVsLinkedListNodeBenchmark listVsLinkedListVsLinkedListNodeBenchmark =
            new ListVsLinkedListVsLinkedListNodeBenchmark
            {
                AmountOfChanges = 10,
                RandomLow = -2,
                RandomHigh = 2,
                ListSize = 10
            };

        listVsLinkedListVsLinkedListNodeBenchmark.Prepare();
        listVsLinkedListVsLinkedListNodeBenchmark.Changes.Count.Should().Be(10);
        listVsLinkedListVsLinkedListNodeBenchmark.LinkedList.Count.Should().Be(10);

        listVsLinkedListVsLinkedListNodeBenchmark.AddChangesToLinkedList();
        listVsLinkedListVsLinkedListNodeBenchmark.LinkedList.Count.Should().Be(20);
    }
}