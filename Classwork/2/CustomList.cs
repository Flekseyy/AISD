namespace Aisd;
public class CustomList<T>
{
    private Node<T> _firstNode;
    
    public bool IsEmpty() => _firstNode == null;
    
 
    public void Add(T num)
    {
        var newNode = new Node<T>(num);
        newNode.NextNode = _firstNode;
        _firstNode = newNode;
    }
    public void Print()
    {
        if (_firstNode == null)
        {
            Console.WriteLine("Список пустой!");
            return;
        }
        
        Node<T> tempNode = _firstNode;
        while (tempNode != null)
        {
            Console.Write($"{tempNode.Info} "+ (tempNode.NextNode==null?"":"-> "));
            tempNode = tempNode.NextNode;
            
        }
        Console.WriteLine();
    }
    public void InsertPos(T num, int pos)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Список пуст");
        }
        if (this.GetLength() < pos)
        {
            Console.WriteLine("Индекс выходит за границы");
        }
        Node<T> tempNode = _firstNode;
     
        int index = 1;
        while (tempNode != null)
        {
            if( index == pos - 1)
            {
                Node<T> newNode = new Node<T>(num);
                newNode.NextNode = tempNode.NextNode;
                tempNode.NextNode = newNode;
                return;
            }
            index++;
            tempNode = tempNode.NextNode;
        }
                
     
  
    }

    public int GetLength()
    {
        int count = 0;   
        Node<T> tempNode = _firstNode;
        while (tempNode != null)
        {
            tempNode = tempNode.NextNode;
            count++;
        }
        return count;
    }
}