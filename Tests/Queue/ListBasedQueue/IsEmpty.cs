using L.DataStructures.Queue;

namespace Tests.Queue.ListBasedQueue;

public class IsEmpty
{
    [Theory]
    [InlineData(new int[] { })]
    public void EmptyQueue_ShouldReturnTrue(int[] initialValues)
    {
        var queue = new ListBasedQueue<int>();

        foreach (var value in initialValues)
            queue.Push(value);

        Assert.True(queue.IsEmpty);
    }

    [Theory]
    [InlineData(new int[] { 1 })]
    public void NotEmptyQueue_ShouldReturnFalse(int[] initialValues)
    {
        var queue = new ListBasedQueue<int>();

        foreach (var value in initialValues)
            queue.Push(value);

        Assert.False(queue.IsEmpty);
    }
}