using L.DataStructures.Stack;

namespace Tests.Stack.VectorBasedStackTest;

public class Push
{
    [Fact]
    public void ShouldAddElement()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);

        Assert.False(stack.IsEmpty);
    }
}
