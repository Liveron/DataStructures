using L.DataStructures.List;

namespace L.DataStructures.Stack;

public sealed class ListBasedStack<T>
{
    private readonly SinglyLinkedList<T> _values = [];
    private int _elementsCount = 0;

    public bool IsEmpty => _elementsCount == 0;
    public int Count => _elementsCount;

    // O(1)
    public void Push(T value)
    {
        _elementsCount++;
        _values.InsertBeforeHead(value);
    }

    // O(1)
    public T Pop()
    {
        if (_values.Head == null)
            throw new InvalidOperationException("There are no elements in the stack.");

        _elementsCount--;
        T result = _values.Head.Value;
        _values.RemoveHead();
        return result;
    }
}
