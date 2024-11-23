namespace L.DataStructures.SearchTrees;

public class AvlTree<T> where T : IComparable<T>
{
    private class Node(T key)
    {
        public T Key => key;
        public int Height { get; set; } = 1;
        public Node? Right { get; set; }
        public Node? Left { get; set; }
    }

    private Node? _root;
    public int Height => CalculateHeight(_root);

    private AvlTree(Node? node) => _root = node;
    public AvlTree(IEnumerable<T> values)
    {
        foreach (T value in values)
            Insert(value);
    }
    public AvlTree() : this(node: null) { }

    // O(log(n))
    public void Insert(T key) => _root = Insert(_root, key);
    private static Node Insert(Node? node, T key)
    {
        if (node is null) return new Node(key);

        if (key.CompareTo(node.Key) < 0)
        {
            node.Left = Insert(node.Left, key);
        }
        else
        {
            node.Right = Insert(node.Right, key);
        }

        return Balance(node);
    }

    // O(log(n))
    public void Remove(T key) => _root = Remove(_root, key);
    private static Node? Remove(Node? node, T key)
    {
        if (node is null) return null;

        if (key.CompareTo(node.Key) < 0)
        {
            node.Left = Remove(node.Left, key);
        }
        else if (key.CompareTo(node.Key) > 0)
        {
            node.Right = Remove(node.Right, key);
        }
        else
        {
            Node? left = node.Left, right = node.Right;

            if (right is null)
                return left;

            Node min = FindMin(right);
            min.Right = RemoveMin(right);
            min.Left = left;

            return Balance(min);
        }

        return Balance(node);
    }

    // O(log(n))
    public T FindMin()
    {
        if (_root is null)
            throw new InvalidOperationException("There are no elements in tree");

        return FindMin(_root).Key;
    }
    private static Node FindMin(Node node) =>
        node.Left is not null ? FindMin(node.Left) : node;

    // O(log(n))
    public void RemoveMin()
    {
        if (_root is not null)
            _root = RemoveMin(_root);
    }
    private static Node? RemoveMin(Node node)
    {
        if (node.Left is null)
            return node.Right;

        node.Left = RemoveMin(node.Left);
        return Balance(node);
    }

    // O(1)
    private static Node Balance(Node node)
    {
        FixHeight(node);

        if (BalanceFactor(node) == 2)
        {
            if (BalanceFactor(node.Right) < 0)
                node.Right = RotateRight(node.Right);

            return RotateLeft(node);
        }

        if (BalanceFactor(node) == -2)
        {
            if (BalanceFactor(node.Left) > 0)
                node.Left = RotateLeft(node.Left);

            return RotateRight(node);
        }

        return node;
    }


    // O(1)
    private static void FixHeight(Node node)
    {
        int leftHeight = CalculateHeight(node.Left);
        int rightHeight = CalculateHeight(node.Right);
        node.Height = Math.Max(leftHeight, rightHeight) + 1;
    }

    private static int BalanceFactor(Node? node) =>
        CalculateHeight(node?.Right) - CalculateHeight(node?.Left);

    private static int CalculateHeight(Node? node) =>
        node?.Height ?? 0;

    // O(1)
    private static Node RotateRight(Node? node)
    {
        Node q = node?.Left ?? 
            throw new InvalidOperationException("Left child of node is null");

        node.Left = q.Right;
        q.Right = node;
        FixHeight(node);
        FixHeight(q);
        return q;
    }

    // O(1)
    private static Node RotateLeft(Node? node)
    {
        Node p = node?.Right ??
            throw new InvalidOperationException("Right child of node is null");

        node.Right = p.Left;
        p.Left = node;
        FixHeight(node);
        FixHeight(p);
        return p;
    }
}