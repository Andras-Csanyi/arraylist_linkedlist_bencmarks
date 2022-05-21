namespace ListvsLinkedListBenchmarks.Unit.Tests;

using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class PureLinkedListBenchmark_Should
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PureLinkedListBenchmark_Should(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void AddChanges()
    {
        ListVsLinkedListVsLinkedListNodeBenchmark listVsLinkedListVsLinkedListNodeBenchmark =
            new ListVsLinkedListVsLinkedListNodeBenchmark
            {
                AmountOfChanges = 10,
                ListSize = 100,
                SizeOfAppendedArrays = 10
            };

        listVsLinkedListVsLinkedListNodeBenchmark.Prepare();
        listVsLinkedListVsLinkedListNodeBenchmark.AddChangesToPureLinkedListNodes();

        int counter = 0;
        ListVsLinkedListVsLinkedListNodeBenchmark.LLNode<int> node = listVsLinkedListVsLinkedListNodeBenchmark
            .PureLinkedList;
        while (node.Next != null)
        {
            counter++;
            node.Next = node.Next.Next;
        }

        counter.Should().Be((listVsLinkedListVsLinkedListNodeBenchmark.AmountOfChanges *
                             listVsLinkedListVsLinkedListNodeBenchmark.SizeOfAppendedArrays) +
                            listVsLinkedListVsLinkedListNodeBenchmark.ListSize);
    }
}