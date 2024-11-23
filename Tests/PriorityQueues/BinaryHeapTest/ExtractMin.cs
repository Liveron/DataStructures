using L.DataStructures.PriorityQueues;

namespace Tests.PriorityQueues.BinaryHeapTest;

public class ExtractMin
{
    [Theory]
    [InlineData(new int[] { 5, 3, 8 }, 3)]
    [InlineData(new int[] { 10, 15, 20, 17, 25 }, 10)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
    public void ShouldReturnMinElement(int[] elements, int expectedMin)
    {
        var heap = new BinaryHeap<int>(elements);

        var min = heap.ExtractMin();

        Assert.Equal(expectedMin, min);
    }

    [Theory]
    [InlineData(new int[] { 5, 3, 8 }, new int[] { 3, 5, 8 })]
    [InlineData(new int[] { 10, 15, 20, 17, 25 }, new int[] { 10, 15, 17, 20, 25 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
    public void ShouldRemoveAndReturnMinElementsInOrder(int[] elements, int[] expectedOrder)
    {
        var heap = new BinaryHeap<int>(elements);

        var result = new List<int>(elements.Length);

        while (heap.Size > 0) 
            result.Add(heap.ExtractMin());

        Assert.Equal(expectedOrder, result);
    }

    [Fact]
    public void ZeroSize_ShouldThrowException()
    {
        var heap = new BinaryHeap<int>();

        Assert.Throws<InvalidOperationException>(
            () => heap.ExtractMin());
    }
}
