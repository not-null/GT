namespace BubbleSort.Extensions
{
    public static class ArrayExtensions
    {
        public static void BubbleSort(this int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var swapped = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // swap
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        swapped = true;
                    }
                }

                // exit early if array is sorted
                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
