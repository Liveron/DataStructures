using L.DataStructures.Stack;

namespace Tests.Stack.ListBasedStackTest;

public class Pop
{
    [Fact]
    public void ShouldRemoveFromStack()
    {
        var stack = new ListBasedStack<int>();

        stack.Push(1);

        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void ShouldReturnElementFromStack()
    {
        var stack = new ListBasedStack<int>();

        stack.Push(1);
        int result = stack.Pop();

        Assert.Equal(1, result);
    }

    [Fact]
    public void EmptyStack_shouldThrowException()
    {
        var stack = new ListBasedStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}
