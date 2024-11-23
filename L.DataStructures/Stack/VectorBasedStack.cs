namespace L.DataStructures.Stack;

public class VectorBasedStack<T>
{
    private readonly Vector<T> values = [];
    private int _elementsCount = 0;

    public int Count => _elementsCount;
    public bool IsEmpty => _elementsCount == 0;

    public void Push(T value)
    {
        _elementsCount++;
        values.Add(value);
    }

    public T Pop()
    {
        if (_elementsCount == 0)
            throw new InvalidOperationException("There are no elements in the stack.");

        _elementsCount--;
        return values.Remove();
    }
}
