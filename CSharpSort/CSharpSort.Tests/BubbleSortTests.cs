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
    [InlineData(new[] { 5, 10, 15, 20, 25 }, new[] { 5, 10, 15, 20, 25 }, 4, 0)]
    // Average case
    [InlineData(new[] { 20, 25, 15, 5, 10 }, new[] { 5, 10, 15, 20, 25 }, 10, 8)]
    // Worst case
    [InlineData(new[] { 25, 20, 15, 10, 5 }, new[] { 5, 10, 15, 20, 25 }, 10, 10)]
    public void WhenSortInvoked_ThenVerifyInsight(int[] arr, int[] expectedArray, long expectedIterations, long expectedBubbles)
    {
        var bubble = new BubbleSort();

        (long actualIterations, long actualBubbles) = bubble.InsightfulSort(arr);

        Assert.Equal(expectedArray, arr);
        Assert.Equal(expectedIterations, actualIterations);
        Assert.Equal(expectedBubbles, actualBubbles);
    }
}
