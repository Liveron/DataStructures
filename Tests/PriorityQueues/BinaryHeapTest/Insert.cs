using L.DataStructures.PriorityQueues;

namespace Tests.PriorityQueues.BinaryHeapTest;

public class Insert
{
    [Theory]
    [InlineData(new int[] {5, 8, 3}, new int[] {3, 5, 8})]
    public void ShouldAddElementToHeap(int[] elementsToAdd, int[] expected)
    {
        var heap = new BinaryHeap<int>();

        var result = new List<int>(expected.Length);

        foreach (int element in elementsToAdd)
            heap.Insert(element);

        while (heap.Size > 0) 
            result.Add(heap.ExtractMin());

        Assert.Equal(result, expected);
    }
}
