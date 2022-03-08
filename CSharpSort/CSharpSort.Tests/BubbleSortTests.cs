namespace CSharpSort.Tests;

public class BubbleSortTests : UnitTestBase
{
    [Fact]
    public void GivenNumericArray_WhenInvokedByBubbleSort_ThenProduceSortedArray()
    {
        var bubble = new BubbleSort();

        var arr = new[] { 20, 25, 15, 5, 10 };

        bubble.Sort(arr);

        Assert.Equal(new[] { 5, 10, 15, 20, 25 }, arr);
    }

    [Theory]
    // Best case
    [InlineData(new[] { 5, 10, 15, 20, 25 }, new[] { 5, 10, 15, 20, 25 }, 4, 0, 8, 0)]
    // Average case
    [InlineData(new[] { 20, 25, 15, 5, 10 }, new[] { 5, 10, 15, 20, 25 }, 10, 8, 20, 16)]
    // Worst case
    [InlineData(new[] { 25, 20, 15, 10, 5 }, new[] { 5, 10, 15, 20, 25 }, 10, 10, 20, 20)]
    public void WhenSortInvoked_ThenVerifyInsight(int[] arr, int[] expectedArray, long iterations, long bubbles, long reads, long writes)
    {
        var insight = BubbleSort.InsightfulSort(arr);

        Assert.Equal(expectedArray, arr);
        Assert.Equal(iterations, insight.Iterations);
        Assert.Equal(reads, insight.Reads);
        Assert.Equal(writes, insight.Writes);
        Assert.Equal(bubbles, insight.KeyOps);
    }
}