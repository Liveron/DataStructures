using L.DataStructures.PriorityQueues;

namespace Tests.PriorityQueues.BinaryHeapTest;

public class Size
{
    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 1, 2 }, 2)]
    public void ShouldReturnSize(int[] initElements, int expectedSize)
    {
        var heap = new BinaryHeap<int>(initElements);

        Assert.Equal(expectedSize, heap.Size);
    }

    [Theory]
    [InlineData(new int[] { } ,new int[] { 1 }, 1)]
    [InlineData(new int[] { 1 }, new int[] { 1 }, 2)]
    public void ShouldReturnSizeAfterInsert(int[] initElements, int[] elementsToAdd, int expectedSize)
    {
        var heap = new BinaryHeap<int>(initElements);

        foreach (int element in elementsToAdd)
            heap.Insert(element);

        Assert.Equal(expectedSize, heap.Size);
    }

    [Theory]
    [InlineData(new int[] { 1 }, 1, 0)]
    [InlineData(new int[] { 1, 2 }, 1, 1)]
    public void ShouldReturnSizeAfterRemove(int[] initElements, int timesToRemove, int expectedSize)
    {
        var heap = new BinaryHeap<int>(initElements);

        for (int i = 0; i < timesToRemove; i++)
            heap.ExtractMin();

        Assert.Equal(expectedSize, heap.Size);
    }
}
