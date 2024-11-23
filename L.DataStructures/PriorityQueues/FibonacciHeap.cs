namespace L.DataStructures.PriorityQueues;

public partial class FibonacciHeap<T>
{
    class Node
    {
        public Node(T value)
        {
            Value = value;
            Left = this;
            Right = this;
        }

        public T Value { get; set; } 
        public int Degree { get; set; }
        public bool Mark { get; set; }
        public Node? Parent { get; set; }
        public Node? Child { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

    }
}

public partial class FibonacciHeap<T> where T : IComparable<T>
{
    public int Size { get; private set; }
    private Node? _minNode;

    public void Insert(T value)
    {
        var newNode = new Node(value);
        if (_minNode == null) _minNode = newNode;
        else
        {
            Node prevRigh = _minNode.Right;
            _minNode.Right = newNode;
            newNode.Left = _minNode;
            newNode.Right = prevRigh;
            prevRigh.Left = newNode;
        }
        if (newNode.Value.CompareTo(_minNode.Value) < 0) 
            _minNode = newNode;
        Size++;
    }

    public void Union(FibonacciHeap<T> heap)
    {
        if (_minNode == null || heap._minNode == null)
        {
            _minNode = heap._minNode;
            Size = heap.Size;
        }
        else
        {
            Node left = _minNode.Left;
            Node right = heap._minNode.Right;
            heap._minNode.Right = heap._minNode;
            _minNode.Left = heap._minNode;
            left.Right = right;
            right.Left = left;
        }
    }
}
