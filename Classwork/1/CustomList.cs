namespace Aisd;

public class CustomList
{
    private Node firstNode;

    public CustomList(int num)
    {
        firstNode = new Node(num);
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
    /// <param name="num"></param>
    public void Add(int num)
    {
        var newNode = new Node(num);
        newNode.NextNode = firstNode;
        firstNode = newNode;
    }

    /// <summary>
    /// Удаление последнего элемента
    /// </summary>
    public void RemoveLast()
    {
        if (firstNode == null)
        {
            Console.WriteLine("Список пуст. Удаление невозможно.");
            return;
        }

        if (firstNode.NextNode == null)
        {
            firstNode = null;
            return;
        }
        
        Node tempNode = firstNode;
        while (tempNode.NextNode.NextNode != null)
        {
            tempNode = tempNode.NextNode;
            
        }
        tempNode.NextNode = null;
        
    }

    public void Print()
    {
        if (firstNode == null)
        {
            Console.WriteLine("Список пустой!");
            return;
        }
        
        Node tempNode = firstNode;
        while (tempNode != null)
        {
            Console.Write($"{tempNode.Info} "+ (tempNode.NextNode==null?"":"-> "));
            tempNode = tempNode.NextNode;
            
        }
        Console.WriteLine();
    }

}