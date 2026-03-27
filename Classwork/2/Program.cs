namespace Aisd;
class Program1
{
    public static void Run2()
    {
        var list = new CustomList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);
        list.Add(50);
        list.Print();
        list.InsertPos(15,5);
        list.Print();
        Console.WriteLine($"Размер: {list.GetLength()}()");
        
        
    }
}