using L.DataStructures.Stack;

namespace Tests.Stack.ListBasedStackTest;

public class IsEmpty
{
    [Fact]
    public void EmptyStack_ShouldReturnTrue()
    {
        var stack = new ListBasedStack<int>();

        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void NotEmptyStack_ShouldReturnFalse()
    {
        var stack = new ListBasedStack<int>();

        stack.Push(1);

        Assert.False(stack.IsEmpty);
    }
}
