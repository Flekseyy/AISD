namespace Aisd;

public class Node<T>
{
    public T Info;
    public Node<T> NextNode;

    public Node(T info)
    {
         Info = info;
    }
}