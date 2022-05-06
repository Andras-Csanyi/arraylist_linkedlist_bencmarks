namespace ListvsLinkedListBenchmarks.Unit.Tests;

using ArrayListAndLinkedListBenchmarks;
using FluentAssertions;
using Xunit;

public class ListBenchmarks_Should
{
    [Fact]
    public void IncreaseListSize()
    {
        ListBenchmark listBenchmark = new()
        {
            AmountOfChanges = 10,
            RandomLow = -5,
            RandomHigh = 5,
            ListSize = 100
        };
        listBenchmark.Prep();
        listBenchmark.List.Count.Should().Be(100);
        listBenchmark.Changes.Count.Should().Be(10);

        listBenchmark.AddChangesToList();
        listBenchmark.List.Count.Should().Be(110);
    }
}