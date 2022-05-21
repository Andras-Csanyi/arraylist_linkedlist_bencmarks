namespace ListvsLinkedListBenchmarks.Unit.Tests;

using System.Collections.Generic;
using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class AddChangesToListOneByOne_Should
{
    [Fact]
    public void AddChangestoList_InTheRightOrder()
    {
        Dictionary<int, int[]> changes = new Dictionary<int, int[]>();
        changes.Add(1, new int[] { 101, 102, 103, 104 });
        changes.Add(2, new int[] { 201, 202, 203, 204 });

        List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        ListVsLinkedListVsLinkedListNodeBenchmark benchmark = new ListVsLinkedListVsLinkedListNodeBenchmark
        {
            Changes = changes,
            List = list
        };

        int[] expectedResult = new[] { 0, 1, 104, 103, 204, 203, 202, 201, 102, 101, 2, 3, 4, 5, 6, 7, 8, 9 };

        benchmark.AddChangesToListOneByOne();

        for (int i = 0; i < expectedResult.Length; i++)
        {
            benchmark.List[i].Should().Be(expectedResult[i]);
        }
    }
}