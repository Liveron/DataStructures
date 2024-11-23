using L.DataStructures.Stack;

namespace Tests.Stack.ListBasedStackTest;

public class Count
{
    [Fact]
    public void NotEmptyStack_ShouldReturnNumberOfElements()
    {
        var stack = new ListBasedStack<int>();

        stack.Push(1);
        stack.Push(2);

        Assert.Equal(2, stack.Count);
    }
}
