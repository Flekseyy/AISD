namespace Aisd2;

class Program
{
    static void Main()
    {
        CustomList list = new CustomList(new[] { 10, 20, 30, 20, 40 });
        
        Console.WriteLine($"Размер: {list.Size()}");
        Console.WriteLine($"Пустой? {list.IsEmpty()}");
        Console.WriteLine($"Содержит 20? {list.Contains(20)}");
       
        
        list.Print();
        list.Reverse();
        list.Print();
    }
}