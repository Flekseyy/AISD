namespace Task.LinkedList;

public class LinkedNode<T>
{
    public T Info;
    public LinkedNode<T> NextNode;
    public LinkedNode<T> PrevNode;

    public LinkedNode(T info)
    {
        Info = info;
    }    
}