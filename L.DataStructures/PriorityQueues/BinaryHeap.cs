namespace L.DataStructures.PriorityQueues;

public class BinaryHeap<T> where T : IComparable<T>
{
    private readonly List<T> _heap;
    private int _size;

    public int Size => _size;

    public BinaryHeap()
    {
        _heap = [];
    }

    public BinaryHeap(IEnumerable<T> heap)
    {
        _heap = [.. heap];
        _size = _heap.Count;
        Heapify();
    }

    // O(log(n))
    private void SiftDown(int index)
    {
        while (2 * index + 1 < _size)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int j = left;

            if (right < _size && _heap[right].CompareTo(_heap[left]) < 0)
                j = right;

            if (_heap[index].CompareTo(_heap[j]) <= 0)
                break;

            (_heap[index], _heap[j]) = (_heap[j], _heap[index]);
            index = j;
        }
    }

    // O(log(n))
    private void SiftUp(int index)
    {
        if (index == 0) return;
        while (_heap[index].CompareTo(_heap[(index - 1) / 2]) < 0)
        {
            (_heap[index], _heap[(index - 1) / 2]) = (_heap[(index - 1) / 2], _heap[index]);
            index = (index - 1) / 2;
        }
    }

    // O(log(n))
    public T ExtractMin()
    {
        if (_size == 0)
            throw new InvalidOperationException("Heap is empty");

        T min = _heap[0];
        _heap[0] = _heap[--_size];
        _heap[_size] = min;
        SiftDown(0);
        return min;
    }

    // O(n)
    public T GetMin()
    {
        return _heap[0];
    }

    // O(log(n))
    public void Insert(T item)
    {
        _heap.Add(item);
        SiftUp(_size++);
    }

    // O(n)
    private void Heapify()
    {
        for (int i = _size / 2; i >= 0; i--)
            SiftDown(i);
    }

    // O(nlog(n))
    public static List<T> HeapSort(IEnumerable<T> values)
    {
        var heap = new BinaryHeap<T>(values);

        while (heap.Size  > 1)
            heap.ExtractMin();

        heap._heap.Reverse();

        return heap._heap;
    }
}
