using L.DataStructures.Stack;

namespace Tests.Stack.VectorBasedStackTest;

public class Pop
{
    [Fact]
    public void ShouldRemoveElement()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);
        stack.Push(2);

        stack.Pop();

        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void ShouldReturnLastElement()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);
        stack.Push(2);

        Assert.Equal(2, stack.Pop());
    }

    [Fact]
    public void OnEmptyStack_ThrowsException()
    {
        var stack = new VectorBasedStack<int>();

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}
