namespace CSharpSort;

public class BubbleSort : ISorting<int>
{
    public void Sort(int[] arr)
    {
        SortCore(arr, null, null);
    }

    public (long iterations, long bubbles) InsightfulSort(int[] arr)
    {
        (long it, long b) = (0, 0);

        SortCore(arr, () => it++, () => b++);

        return (it, b);
    }

    static void SortCore(int[] arr, Action? iteration, Action? bubble)
    {
        var length = arr.Length;

        for (int i = 0; i < length; i++)
        {
            bool bubbling = false;
            for (int j = 1; j < length - i; j++)
            {
                bubbling |= BubbleUp(ref arr[j - 1], ref arr[j], iteration, bubble);
            }

            // if no bubbling happens in a full-round,
            // then sorting is already completed
            if (!bubbling) break;
        }
    }

    static bool BubbleUp(ref int a, ref int b, Action? iteration, Action? bubble)
    {
        iteration?.Invoke();

        if (a > b)
        {
            (b, a) = (a, b);
            bubble?.Invoke();
            return true;
        }

        return false;
    }
}
