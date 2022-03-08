namespace CSharpSort;

public class SelectionSort : ISorting<int>
{
    private readonly Action? _onIterate;
    private readonly Action? _onPlacement;
    protected SelectionSort(Action onIterate, Action onPlacement)
    {
        _onIterate = onIterate;
        _onPlacement = onPlacement;
    }

    public SelectionSort() { }

    public void Sort(int[] arr)
    {
        var length = arr.Length;

        for (int i = 0; i < length; i++)
        {
            var startValue = arr[i];
            (var minValue, var minIndex) = (startValue, i);

            for (int j = i + 1; j < length; j++)
            {
                _onIterate?.Invoke();
                var value = arr[j];

                if (value < minValue)
                {
                    minIndex = j;
                    minValue = value;
                }
            }

            if (minValue < startValue)
            {
                _onPlacement?.Invoke();
                (arr[minIndex], arr[i]) = (startValue, minValue);
            }
        }
    }

    /// <summary>
    /// Sort operation with operational insight
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static InsightData InsightfulSort(int[] arr)
    {
        (long iteration, long placement) = (0, 0);

        var selection = new SelectionSort(() => iteration++, () => placement++);

        selection.Sort(arr);

        return new (iteration, iteration + arr.Length, placement * 2, placement);
    }
}
