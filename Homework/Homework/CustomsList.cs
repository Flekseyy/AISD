namespace Aisd2;
public class CustomList
{
    private Node _firstNode;
    private int _count; 

    public CustomList(int num)
    {
        _firstNode = new Node(num);
        _count = 1; 
    }

    public CustomList(int[] nums)
    {
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            Add(nums[i]); 
        }
    }
    
    /// <summary>
    /// Добавление в начало 
    /// </summary>
    public void Add(int num)
    {
        var newNode = new Node(num);
        newNode.NextNode = _firstNode;
        _firstNode = newNode;
        _count++;  
    }

    /// <summary>
    /// Удаление последнего элемента
    /// </summary>
    public void RemoveLast()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пуст. Удаление невозможно.");
            return;
        }

        if (_firstNode.NextNode == null)
        {
            _firstNode = null;
            _count = 0;  
            return;
        }
        
        Node tempNode = _firstNode;
        while (tempNode.NextNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
            
        }
        tempNode.NextNode = null;
        _count--;  
    }

    public void Print()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пустой!");
            return;
        }
        
        Node tempNode = _firstNode;
        while (tempNode != null)
        {
            Console.Write($"{tempNode.Info} "+ (tempNode.NextNode==null?"":"-> "));
            tempNode = tempNode.NextNode;
            
        }
        Console.WriteLine();
    }

   

    /// <summary>
    /// Размер линейного списка
    /// </summary>
    public int Size()
    {
        return _count;
    }

    /// <summary>
    /// Проверка на пустоту
    /// </summary>
    public bool IsEmpty()
    {
        return _firstNode == null;
    }

    /// <summary>
    /// Проверка на наличие какого-то элемента
    /// </summary>
    public bool Contains(int value)
    {
        Node current = _firstNode;
        while (current != null)
        {
            if (current.Info == value)
                return true;
            current = current.NextNode;
        }
        return false;
    }

    /// <summary>
    /// Выдать индексы вхождения некоторого значения (индексы с 1)
    /// </summary>


    /// <summary>
    /// Перевернуть линейный список за 1 проход
    /// </summary>
    public void Reverse()
    {
        if (_firstNode == null || _firstNode.NextNode == null)
            return;
        
        Node previous = null;
        Node current = _firstNode;
        Node next = null;
        
        while (current != null)
        {
            next = current.NextNode;  
            current.NextNode = previous; 
            previous = current;  
            current = next;  
        }
        
        _firstNode = previous;  
    }
}