using L.DataStructures.List;

namespace L.DataStructures.Queue;

public class ListBasedQueue<T>
{
    private SinglyLinkedListNode<T>? _tail;
    private SinglyLinkedListNode<T>? _head;

    public int Size { get; private set; } = 0;
    public bool IsEmpty => Size == 0;

    public void Push(T element)
    {
        var newNode = new SinglyLinkedListNode<T>(element);
        if (IsEmpty)
        {
            _head = newNode;
            _tail = _head;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = _tail.Next;
        }
        Size++;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("There are no elements in the queue.");

        T element = _head!.Value;
        _head = _head.Next;
        Size--;

        if (IsEmpty)
            _tail = null;

        return element;
    }
}
