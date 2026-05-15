namespace Structure;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public int Height;

    public Node(int value)
    {
        Value  = value;
        Height = 1;
    }
}