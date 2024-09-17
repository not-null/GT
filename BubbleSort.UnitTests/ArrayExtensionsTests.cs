using BubbleSort.Extensions;

namespace BubbleSort.UnitTests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void BubbleSort_IncreasingList_ShouldDoNothing()
        {
            int[] list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            list.BubbleSort();
            int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void BubbleSort_DecreasingList_ShouldReverse()
        {
            int[] list = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];
            list.BubbleSort();
            int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void BubbleSort_RandomList_ShouldSort()
        {
            Random random = new();
            var list = Enumerable.Range(1, 10).Select(i => random.Next()).ToArray();
            var expected = (int[])list.Clone();
            Array.Sort(expected);

            list.BubbleSort();

            CollectionAssert.AreEqual(expected, list);
        }
    }
}
