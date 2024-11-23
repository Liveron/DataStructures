using L.DataStructures.Queue;

namespace Tests.Queue.ListBasedQueue;

public class Pop
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 1)]
    [InlineData(new int[] { 10, 20 }, 10)]
    public void ShouldReturnFirstElement(int[] initialValues, int expectedValue)
    {
        var queue = new ListBasedQueue<int>();

        foreach (var value in initialValues)
            queue.Push(value);

        var poppedValue = queue.Pop();
        Assert.Equal(expectedValue, poppedValue);
    }

    [Fact]
    public void Pop_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new ListBasedQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Pop());
    }
}
