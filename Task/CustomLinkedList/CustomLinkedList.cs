
namespace Task.LinkedList;

public class CustomLinkedList<T>: ICustomCollection<T>
{
    private LinkedNode<T> _firstNode;

    public CustomLinkedList()
    {
        _firstNode = null;
    }

    public CustomLinkedList(T value)
    {
        _firstNode = new LinkedNode<T>(value);
    }

    public CustomLinkedList(T[] values)
    {
        if (values == null || values.Length == 0)
        {
            _firstNode = null;
            return;
        }

        _firstNode = new LinkedNode<T>(values[0]);
        LinkedNode<T> tempNode = _firstNode;

        for (int i = 1; i < values.Length; i++)
        {
            tempNode.NextNode = new LinkedNode<T>(values[i]);
            tempNode.NextNode.PrevNode = tempNode;
            tempNode = tempNode.NextNode;
        }
    }
    public void AddFirst(T value)
    {
        LinkedNode<T> newNode = new LinkedNode<T>(value);
        
        if (_firstNode == null)
        {
            _firstNode = newNode;
            return;
        }

        newNode.NextNode = _firstNode; 
        _firstNode.PrevNode = newNode;  
        _firstNode = newNode;
    }

    public void AddLast(T value)
    {
        LinkedNode<T> newNode = new LinkedNode<T>(value);

        if (_firstNode == null)
        {
            _firstNode = newNode;
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        while (tempNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
        }

        tempNode.NextNode = newNode;
        newNode.PrevNode = tempNode; 
    }

    public void AddInsert(int index, T value)
    {
        if (_firstNode == null)
        {
            if (index == 1)
            {
                AddFirst(value);
                return;
            }
            Console.WriteLine("Список пуст!");
            return;
        }

        if (index < 1 || index > Size() + 1)
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 1)
        {
            AddFirst(value);
            return;
        }

        LinkedNode<T> newNode = new LinkedNode<T>(value);
        LinkedNode<T> tempNode = _firstNode;
        int count = 1;

        while (tempNode != null)
        {
            if (count == index - 1)
            {
                newNode.NextNode = tempNode.NextNode;
                newNode.PrevNode = tempNode;
                
                if (tempNode.NextNode != null)
                {
                    tempNode.NextNode.PrevNode = newNode;
                }
                
                tempNode.NextNode = newNode;
                return;
            }
            count++;
            tempNode = tempNode.NextNode;
        }
    }

    public void AddRange(T[] values)
    {
        if (values == null || values.Length == 0) return;

        foreach (T value in values)
        {
            AddLast(value);
        }
    }

    public void Print()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пустой!");
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        while (tempNode != null)
        {
            Console.Write($"{tempNode.Info}" + (tempNode.NextNode == null ? "" : " -> "));
            tempNode = tempNode.NextNode;
        }
        Console.WriteLine();
    }

    public void RemoveFirst()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        _firstNode = _firstNode.NextNode;
        
        if (_firstNode != null)
        {
            _firstNode.PrevNode = null;  
        }
    }
    public void RemoveLast()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (_firstNode.NextNode == null)
        {
            _firstNode = null;
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        
        while (tempNode.NextNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
        }
        
        tempNode.NextNode = null;
    }

    public void RemoveAt(int index)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (index < 1 || index > Size())
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 1)
        {
            RemoveFirst();
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        int count = 1;

        while (tempNode.NextNode != null)
        {
            if (count == index - 1)
            {
                var nodeToDelete = tempNode.NextNode;
                tempNode.NextNode = nodeToDelete.NextNode;
                
                if (nodeToDelete.NextNode != null)
                {
                    nodeToDelete.NextNode.PrevNode = tempNode;
                }
                return;
            }
            count++;
            tempNode = tempNode.NextNode;
        }
    }

    public void RemoveSecond()
    {
        RemoveAt(2);
    }

    public void RemoveRange(int index)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (index < 1 || index > Size())
        {
            Console.WriteLine("Индекс выходит за границы");
            return;
        }

        if (index == 1)
        {
            _firstNode = null;
            return;
        }

        LinkedNode<T> tempNode = _firstNode;
        int pos = 1;

        while (tempNode.NextNode != null)
        {
            if (pos == index - 1)
            {
                tempNode.NextNode = null;
                return;
            }
            tempNode = tempNode.NextNode;
            pos++;
        }
    }

    public void RemoveAllOccurrences(T value)
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        List<int> indices = new List<int>();
        int index = 1;
        LinkedNode<T> tempNode = _firstNode;

        while (tempNode != null)
        {
            if (Equals(tempNode.Info, value))
            {
                indices.Add(index);
            }
            tempNode = tempNode.NextNode;
            index++;
        }

        for (int i = indices.Count - 1; i >= 0; i--)
        {
            RemoveAt(indices[i]);
        }
    }



    public void Reverse()
    {
        if (_firstNode == null) return;

        LinkedNode<T> temp = null;
        LinkedNode<T> current = _firstNode;

        while (current != null)
        {
            temp = current.PrevNode;
            current.PrevNode = current.NextNode;
            current.NextNode = temp;
            current = current.PrevNode;
        }
        
        if (temp != null)
        {
            _firstNode = temp.PrevNode;
        }
    }

    public int Size()
    {
        int count = 0;
        LinkedNode<T> tempNode = _firstNode;
        while (tempNode != null)
        {
            tempNode = tempNode.NextNode;
            count++;
        }
        return count;
    }

    public bool IsEmpty()
    {
        return _firstNode == null;
    }

    public bool Contains(T value)
    {
        LinkedNode<T> tempNode = _firstNode;
        while (tempNode != null)
        {
            if (Equals(tempNode.Info, value))
            {
                return true;
            }
            tempNode = tempNode.NextNode;
        }
        return false;
    }

    public void FindAllIndices(T value)
    {
        LinkedNode<T> tempNode = _firstNode;
        int count = 1;
        while (tempNode != null)
        {
            if (Equals(tempNode.Info, value))
            {
                Console.WriteLine($"Index {count} of {value}");
            }
            tempNode = tempNode.NextNode;
            count++;
        }
    }
}