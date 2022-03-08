namespace CSharpSort;

public class BubbleSort : ISorting<int>
{
    private readonly Action? _onIterate;
    private readonly Action? _onBubble;
    protected BubbleSort(Action onIterate, Action onBubble)
    {
        _onIterate = onIterate;
        _onBubble = onBubble;
    }

    public BubbleSort() { }

    /// <summary>
    /// Sort array in ascending order
    /// </summary>
    /// <param name="arr"></param>
    public void Sort(int[] arr)
    {
        var length = arr.Length;

        for (int i = 0; i < length; i++)
        {
            bool bubbling = false;
            for (int j = 1; j < length - i; j++)
            {
                bubbling |= bubbleUp(ref arr[j - 1], ref arr[j]);
            }

            // if no bubbling happens in a full-round,
            // then sorting is already completed
            if (!bubbling) break;
        }

        bool bubbleUp(ref int a, ref int b)
        {
            _onIterate?.Invoke();

            if (a > b)
            {
                (b, a) = (a, b);
                _onBubble?.Invoke();
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Sort operation with operational insight
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static InsightData InsightfulSort(int[] arr)
    {
        (long iterations, long bubbles) = (0, 0);

        var bubble = new BubbleSort(() => iterations++, () => bubbles++);

        bubble.Sort(arr);

        return new (iterations, iterations * 2, bubbles * 2, bubbles);
    }
}
