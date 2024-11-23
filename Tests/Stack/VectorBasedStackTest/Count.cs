using L.DataStructures.Stack;

namespace Tests.Stack.VectorBasedStackTest;
public class Count
{
    [Fact]
    public void OnNewStack_ShouldReturnZero()
    {
        var stack = new VectorBasedStack<int>();

        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void AfterPush_ShoulReturnCorrectCount()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);
        stack.Push(2);

        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void AfterPushAndPop_ReturnsCorrectCount()
    {
        var stack = new VectorBasedStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Pop();

        Assert.Equal(1, stack.Count);
    }
}
