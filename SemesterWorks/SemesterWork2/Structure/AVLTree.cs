namespace Structure;

public class AvlTree
{
    private Node _root;

    private int Height(Node n) => n == null ? 0 : n.Height;
    private int Balance(Node n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

    private void UpdateHeight(Node n)
    {
        if (n != null)
            n.Height = 1 + Math.Max(Height(n.Left), Height(n.Right));
    }

    private Node RotateRight(Node y)
    {
        Node x  = y.Left;
        Node t2 = x.Right;
        x.Right = y;
        y.Left  = t2;
        UpdateHeight(y);
        UpdateHeight(x);
        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y  = x.Right;
        Node t2 = y.Left;
        y.Left  = x;
        x.Right = t2;
        UpdateHeight(x);
        UpdateHeight(y);
        return y;
    }

    private Node Rebalance(Node n)
    {
        UpdateHeight(n);
        int bal = Balance(n);

        if (bal > 1 && Balance(n.Left) >= 0)
            return RotateRight(n);

        if (bal > 1 && Balance(n.Left) < 0)
        {
            n.Left = RotateLeft(n.Left);
            return RotateRight(n);
        }

        if (bal < -1 && Balance(n.Right) <= 0)
            return RotateLeft(n);

        if (bal < -1 && Balance(n.Right) > 0)
        {
            n.Right = RotateRight(n.Right);
            return RotateLeft(n);
        }

        return n;
    }

    public void Insert(int value)
    {
        _root = InsertRec(_root, value);
    }

    private Node InsertRec(Node n, int value)
    {
        if (n == null) return new Node(value);
        if (value < n.Value)      n.Left  = InsertRec(n.Left,  value);
        else if (value > n.Value) n.Right = InsertRec(n.Right, value);
        else return n;
        return Rebalance(n);
    }

    public bool Search(int value)
    {
        return SearchRec(_root, value);
    }

    private bool SearchRec(Node n, int value)
    {
        if (n == null)        return false;
        if (value == n.Value) return true;
        return value < n.Value
            ? SearchRec(n.Left,  value)
            : SearchRec(n.Right, value);
    }

    public void Delete(int value)
    {
        _root = DeleteRec(_root, value);
    }

    private Node MinNode(Node n)
    {
        while (n.Left != null) n = n.Left;
        return n;
    }

    private Node DeleteRec(Node n, int value)
    {
        if (n == null) return null;

        if (value < n.Value)
            n.Left  = DeleteRec(n.Left,  value);
        else if (value > n.Value)
            n.Right = DeleteRec(n.Right, value);
        else
        {
            if (n.Left  == null) return n.Right;
            if (n.Right == null) return n.Left;
            Node successor = MinNode(n.Right);
            n.Value = successor.Value;
            n.Right = DeleteRec(n.Right, successor.Value);
        }

        return Rebalance(n);
    }

    public List<int> BfsTraversal()
    {
        var result = new List<int>();
        if (_root == null) return result;

        var queue = new Queue<Node>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            result.Add(node.Value);
            if (node.Left  != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
        }

        return result;
    }

    public List<int> InOrderTraversal()
    {
        var result = new List<int>();
        InOrderRec(_root, result);
        return result;
    }

    private void InOrderRec(Node n, List<int> result)
    {
        if (n == null) return;
        InOrderRec(n.Left, result);
        result.Add(n.Value);
        InOrderRec(n.Right, result);
    }

    public void Print()
    {
        PrintRec(_root, "", true);
    }

    private void PrintRec(Node n, string indent, bool isLast)
    {
        if (n == null) return;
        Console.Write(indent);
        Console.Write(isLast ? "└── " : "├── ");
        Console.WriteLine(n.Value);
        string childIndent = indent + (isLast ? "    " : "│   ");
        PrintRec(n.Left,  childIndent, false);
        PrintRec(n.Right, childIndent, true);
    }
}