namespace ListvsLinkedListBenchmarks.Unit.Tests;

using System.Collections.Generic;
using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class AddChangesToListAsRange_Should
{
    [Fact]
    public void MakeTheChangesInTheRightOrder()
    {
        Dictionary<int, int[]> changes = new();
        changes.Add(1, new[] { 101, 102, 103, 104 });
        changes.Add(2, new[] { 201, 202, 203, 204 });

        List<int> list = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        ListVsLinkedListVsLinkedListNodeBenchmark benchmark = new()
        {
            Changes = changes,
            List = list
        };

        int[] expectedResult = { 0, 1, 101, 102, 201, 202, 203, 204, 103, 104, 2, 3, 4, 5, 6, 7, 8, 9 };

        benchmark.AddChangesToListAsRanges();

        for (int i = 0; i < expectedResult.Length; i++)
        {
            benchmark.List[i].Should().Be(expectedResult[i]);
        }
    }
}