namespace Task.CustomListWithTail;
using Task.CustomList;


public class CustomListWithTail<T> : CustomList<T>
{
    private Node<T> _tailNode;
    
    public CustomListWithTail() : base()
    {
        _tailNode = null;
    }

    public CustomListWithTail(T value) : base(value)
    {
        _tailNode = _firstNode;
    }

    public CustomListWithTail(T[] values) : base(values)
    {
        if (_firstNode != null)
        {
            Node<T> tempNode = _firstNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            _tailNode = tempNode;
        }
    }

    public override void AddFirst(T value)
    {
        base.AddFirst(value);
        if (_tailNode == null)
        {
            _tailNode = _firstNode;
        }
    }

    public override void AddLast(T value)
    {
        Node<T> newNode = new Node<T>(value);
        
        if (_firstNode == null)
        {
            _firstNode = newNode;
            _tailNode = newNode;
            return;
        }
        
        _tailNode.NextNode = newNode;
        _tailNode = newNode;
    }

    public override void AddInsert(int index, T value)
    {
        base.AddInsert(index, value);
        
        if (index == Size())
        {
            Node<T> tempNode = _firstNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            _tailNode = tempNode;
        }
    }
    

    public override void RemoveFirst()
    {
        base.RemoveFirst();
        if (_firstNode == null)
        {
            _tailNode = null;
        }
    }

    public override void RemoveLast()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (_firstNode.NextNode == null)
        {
            _firstNode = null;
            _tailNode = null;
            return;
        }
        
        Node<T> tempNode = _firstNode;
        while (tempNode.NextNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
        }
        tempNode.NextNode = null;
        _tailNode = tempNode;
    }

    public override void RemoveAt(int index)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        
        if (Size() < index || index < 1)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }
        
        if (index == 1)
        {
            RemoveFirst();
            return;
        }
  
        Node<T> tempNode = _firstNode;
        int count = 1;
        
        while (tempNode?.NextNode != null)
        {
            if (count == index - 1)
            {
                if (tempNode.NextNode == _tailNode)
                {
                    _tailNode = tempNode;
                }
                tempNode.NextNode = tempNode.NextNode.NextNode;
                return;
            }
            count++;
            tempNode = tempNode.NextNode;
        }
    }
    
    public override void RemoveRange(int index)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        if (Size() < index || index < 1)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 1)
        {
            _firstNode = null;
            _tailNode = null;
            return;
        }
        
        Node<T> tempNode = _firstNode;
        int pos = 1;
        
        while (tempNode.NextNode != null)
        {
            if (pos == index - 1)
            {
                tempNode.NextNode = null;
                _tailNode = tempNode;
                return;
            }
            tempNode = tempNode.NextNode;
            pos++;
        }
    }

    public override void Reverse()
    {
        base.Reverse();
        _tailNode = _firstNode;
    }
}