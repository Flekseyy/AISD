namespace Aisd;

public class LinkedList<T>
{
    private LinkedNode<T> _firstNode;
    public LinkedList(T value)
    {
        _firstNode = new LinkedNode<T>(value);
    }

    public bool IsEmpty() => _firstNode == null;
    
    
    public void AddFirst(T num)
    {

        if (IsEmpty())
        {
            _firstNode = new LinkedNode<T>(num); 
            return;
        }
        LinkedNode<T> newNode = new LinkedNode<T>(num);
        newNode = _firstNode;
        _firstNode.PrevNode =  newNode;
        _firstNode = newNode;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Список пуст");
            return;
        }
        _firstNode =  _firstNode.NextNode;
        if (_firstNode != null)
        {
            _firstNode.PrevNode = null;
        }
    }

    public void AddLast(T num)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        
        while (tempNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
        }
        LinkedNode<T> newNode = new LinkedNode<T>(num);
        tempNode.NextNode = newNode;
        tempNode.NextNode.PrevNode = tempNode;
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (_firstNode.NextNode == null)
        {
            _firstNode = null;
        }
        LinkedNode<T> tempNode = _firstNode;
        while (tempNode.NextNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
            return;
        }
        tempNode.NextNode = null;
        
    }

    public void RemoveAt(int index)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Список пуст");
            return;
        }
        LinkedNode<T> tempNode = _firstNode;
        int count = 1;
        while (tempNode.NextNode != null)
        {
            if (count == index - 1)
            {
                tempNode.NextNode = tempNode.NextNode.NextNode;
                tempNode.NextNode.NextNode.PrevNode =  tempNode;
            }
            tempNode = tempNode.NextNode;
            count++;
        }
        
    }
    
    public void Print()
    {
        
    }
}