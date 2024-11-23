namespace L.DataStructures.SearchTrees;

public class SplayTree<T> where T : IComparable<T>
{
    private class Node(T key)
    {
        public T Key => key;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public Node? Parent { get; set; }
    }

    private Node? _root;

    private static Node? Find(Node? root, T key)
    {
        if (root is null) return null;
        if (key.CompareTo(root.Key) == 0)
            return Splay(root);
        if (key.CompareTo(root.Key) < 0 && root.Left is not null)
            return Find(root.Left, key);
        if (key.CompareTo(root.Key) > 0 && root.Right is not null)
            return Find(root.Right, key);
        return Splay(root);
    }

    private static Node Splay(Node node)
    {
        if (node.Parent is null) return node;

        Node parent = node.Parent;
        Node? gParent = parent.Parent;

        if (gParent is null)
        {
            Rotate(parent, node);
            return node;
        }
        else
        {
            bool zigZig = gParent.Left == parent ==
                (parent.Left == node);

            if (zigZig)
            {
                Rotate(gParent, parent);
                Rotate(parent, node);
            }
            else
            {
                Rotate(parent, node);
                Rotate(gParent, node);
            }

            return Splay(node);
        }
    }

    private static void Rotate(Node parent, Node child)
    {
        Node? gParent = parent.Parent;

        if (gParent is not null)
        {
            if (gParent.Left == parent)
            {
                gParent.Left = child;
            }
            else gParent.Right = child;
        }

        if (parent.Left == child)
        {
            (parent.Left, child.Right) = (parent.Right, child.Left);
        }
        else (parent.Right, child.Left) = (parent.Left, child.Right);

        KeepParent(child);
        KeepParent(parent);

        child.Parent = gParent;
    }

    private static (Node? left, Node? right) Split(Node? root, T key)
    {
        if (root is null) return (null, null);

        root = Find(root, key);
        if (root?.Key.CompareTo(key) == 0)
        {
            SetParent(root.Left, null);
            SetParent(root.Right, null);
            return (root.Left, root.Right);
        }
        if (root?.Key.CompareTo(key) < 0)
        {
            Node? right = root.Right;
            root.Right = null;
            SetParent(right, null);
            return (root, right);
        }
        else
        {
            Node? left = root.Left;
            root.Left = null;
            SetParent(left, null);
            return (left, root);
        }
    }

    private static void SetParent(Node? node, Node? parent)
    {
        if (node is not null) 
            node.Parent = parent;
    }

    private static void KeepParent(Node node)
    {
        if (node is not null)
        {
            SetParent(node.Left, node);
            SetParent(node.Right, node);
        }
    }
}
