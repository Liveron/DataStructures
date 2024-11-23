using L.DataStructures.Queue;

namespace Tests.Queue.ListBasedQueue;

public class Size
{
    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 1 }, 1)]
    public void ShouldReturnCorrectSize(int[] initialValues, int expectedSize)
    {
        var queue = new ListBasedQueue<int>();

        foreach (var value in initialValues)
            queue.Push(value);

        Assert.Equal(expectedSize, queue.Size);
    }
}
