namespace Task.CustomList;


public class Node<T>
{
    public T Info { get; set; }
    public Node<T> NextNode { get; set; }

    public Node(T value)
    {
        Info = value;
    }

 
}