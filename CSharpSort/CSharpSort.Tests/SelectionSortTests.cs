namespace CSharpSort.Tests;

public class SelectionSortTests : UnitTestBase
{
    [Fact]
    public void GivenNumericArray_WhenInvokedBySelectionSort_ThenProduceSortedArray()
    {
        var selection = new SelectionSort();

        var arr = new[] { 20, 25, 15, 5, 10 };

        selection.Sort(arr);

        Assert.Equal(new[] { 5, 10, 15, 20, 25 }, arr);
    }

    [Theory]
    // Best case
    [InlineData(new[] { 5, 10, 15, 20, 25 }, new[] { 5, 10, 15, 20, 25 }, 10, 0, 15, 0)]
    // Average case
    [InlineData(new[] { 20, 25, 15, 5, 10 }, new[] { 5, 10, 15, 20, 25 }, 10, 2, 15, 4)]
    // Worst case
    [InlineData(new[] { 25, 20, 15, 10, 5 }, new[] { 5, 10, 15, 20, 25 }, 10, 2, 15, 4)]
    public void WhenSortInvoked_ThenVerifyInsight(int[] arr, int[] expectedArray, long iterations, long placement, long reads, long writes)
    {
        var insight = SelectionSort.InsightfulSort(arr);

        Assert.Equal(expectedArray, arr);
        Assert.Equal(iterations, insight.Iterations);
        Assert.Equal(reads, insight.Reads);
        Assert.Equal(writes, insight.Writes);
        Assert.Equal(placement, insight.KeyOps);
    }
}