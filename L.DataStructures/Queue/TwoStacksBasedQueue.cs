namespace L.DataStructures.Queue;

public class TwoStacksBasedQueue<T>
{
    private readonly Stack<T> left = new();
    private readonly Stack<T> right = new();

    public int Size => left.Count + right.Count;
    public bool IsEmpty => Size == 0;

    // O(1)
    public void Push(T element) => left.Push(element);

    // O*(1)
    public T Pop()
    {
        if (right.Count != 0)
            return right.Pop();
        else
            while(left.Count != 0)
                right.Push(left.Pop());
        return right.Pop();
    }
}
