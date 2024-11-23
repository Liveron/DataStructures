using System.Collections;

namespace L.DataStructures.List;

public class SinglyLinkedListNode<T>(T value, SinglyLinkedListNode<T>? node = null)
{
    public T Value { get; set; } = value;
    public SinglyLinkedListNode<T>? Next { get; internal set; } = node;
}

public class SinglyLinkedList<T> : IEnumerable<SinglyLinkedListNode<T>>
{
    private SinglyLinkedListNode<T>? _head;

    public SinglyLinkedListNode<T>? Head 
    { 
        get => _head;
        set
        {
            if (value == null) _head = null;
            else
            {
                value.Next = _head;
                _head = value;
            }
        }
    }

    public SinglyLinkedList(SinglyLinkedListNode<T>? head = null) =>
        _head = head;

    public SinglyLinkedList(IEnumerable<T> values) =>
        _head = SinglyLinkedList<T>.BuildNodesFrom(values);

    // O(n)
    private static SinglyLinkedListNode<T>? BuildNodesFrom(IEnumerable<T> values)
    {
        using IEnumerator<T> enumerator = values.GetEnumerator();

        if (!enumerator.MoveNext())
            return null;

        var head = new SinglyLinkedListNode<T>(enumerator.Current);
        SinglyLinkedListNode<T> current = head;

        while(enumerator.MoveNext())
        {
            current.Next = new SinglyLinkedListNode<T>(enumerator.Current);
            current = current.Next;
        }

        return head;
    }

    // O(1)
    public void InsertBeforeHead(SinglyLinkedListNode<T> node)
    {
        node.Next = Head;
        Head = node;
    }

    // O(1)
    public void InsertBeforeHead(T value)
    {
        Head = new SinglyLinkedListNode<T>(value, Head);
    }

    // O(n)
    public SinglyLinkedListNode<T>? Search(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        SinglyLinkedListNode<T>? currentNode = _head;

        while (currentNode != null && !value.Equals(currentNode.Value))
            currentNode = currentNode.Next;

        return currentNode;
    }

    // O(1)
    public void RemoveHead()
    {
        if (_head != null)
            _head = _head.Next;
    }

    // O(1)
    public void RemoveAfter(SinglyLinkedListNode<T> node)
    {
        if (node.Next != null)
            node.Next = node.Next.Next;
    }

    // O(n)
    public void Remove(SinglyLinkedListNode<T> node)
    {
        if (_head == null) return;
        if (_head == node)
        {
            RemoveHead();
            return;
        }

        SinglyLinkedListNode<T> currentNode = _head; 

        while (currentNode.Next != null && currentNode.Next != node)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode.Next == null) return;

        currentNode.Next = currentNode.Next.Next;
    }

    // O(n)
    public void Remove(T value)
    {
        if (value == null) 
            throw new ArgumentNullException(nameof(value));

        if (_head == null) return;
        if (value.Equals(_head.Value))
        {
            RemoveHead();
            return;
        }

        SinglyLinkedListNode<T> currentNode = _head;

        while (currentNode.Next != null && !value.Equals(currentNode.Next.Value))
            currentNode = currentNode.Next;

        if (currentNode.Next == null) return;

        currentNode.Next = currentNode.Next.Next;
    }

    public IEnumerator<SinglyLinkedListNode<T>> GetEnumerator()
    {
        SinglyLinkedListNode<T>? currentNode = _head;
        while (currentNode != null)
        {
            yield return currentNode;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
