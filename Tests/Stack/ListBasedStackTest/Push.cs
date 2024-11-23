using L.DataStructures.Stack;

namespace Tests.Stack.ListBasedStackTest;

public class Push
{
    [Fact]
    public void ShouldAddElementToStack()
    {
        var stack = new ListBasedStack<int>();

        stack.Push(1);

        Assert.False(stack.IsEmpty);
    }
}
