using L.DataStructures.Stack;

namespace Tests.Stack.VectorBasedStackTest;

public class IsEmpty
{
    [Fact]
    public void OnEmptyStack_ShouldReturnTrue()
    {
        var stack = new VectorBasedStack<int>();

        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void AfterPushAndPop_ShouldReturnTrue()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);
        stack.Pop();

        Assert.True(stack.IsEmpty);
    }
}
