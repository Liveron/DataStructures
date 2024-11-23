using L.DataStructures.Queue;

namespace Tests.Queue.ListBasedQueue;

public class Push
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 10, 20 }, new int[] { 10, 20 })]
    public void ShouldAddElements(int[] initialValues, int[] expectedValues)
    {
        var queue = new ListBasedQueue<int>();

        foreach (var value in initialValues)
        {
            queue.Push(value);
        }

        var actualValues = new List<int>();
        while (!queue.IsEmpty)
        {
            actualValues.Add(queue.Pop());
        }

        Assert.Equal(expectedValues, actualValues);
    }
}