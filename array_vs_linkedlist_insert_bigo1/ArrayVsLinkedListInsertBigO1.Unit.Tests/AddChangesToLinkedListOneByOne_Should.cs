namespace ListvsLinkedListBenchmarks.Unit.Tests;

using System.Collections.Generic;
using System.Linq;
using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class AddChangesToLinkedListOneByOne_Should
{
    [Fact]
    public void MakeTheChangesInTheRightOrder()
    {
        Dictionary<int, int[]> changes = new Dictionary<int, int[]>();
        changes.Add(1, new int[] { 101, 102, 103, 104 });
        changes.Add(2, new int[] { 201, 202, 203, 204 });

        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < 10; i++)
        {
            list.AddLast(i);
        }

        ListVsLinkedListVsLinkedListNodeBenchmark benchmarkSetup = new ListVsLinkedListVsLinkedListNodeBenchmark
        {
            Changes = changes,
            LinkedList = list
        };

        int[] expectedResult = new[] { 0, 1, 104, 103, 204, 203, 202, 201, 102, 101, 2, 3, 4, 5, 6, 7, 8, 9 };

        benchmarkSetup.AddChangesToLinkedListOneByOne();
        for (int i = 0; i < benchmarkSetup.LinkedList.Count; i++)
        {
            benchmarkSetup.LinkedList.ElementAt(i).Should().Be(expectedResult[i]);
        }
    }

    [Fact]
    public void MakeTheChanges()
    {
        ListVsLinkedListVsLinkedListNodeBenchmark benchmark = new ListVsLinkedListVsLinkedListNodeBenchmark
        {
            AmountOfChanges = 100,
            ListSize = 100,
            SizeOfAppendedArrays = 100
        };
        
        benchmark.Prepare();
        benchmark.AddChangesToLinkedListOneByOne();

        benchmark.LinkedList.Count.Should().Be(10100);
    }
}