using System.Diagnostics;

using Task.CustomListWithTail;
using Task.CustomList;
using Task.LinkedList;
using Task;
public class Program
{
    public static void Main(string[] args)
    {
        ProcessCustom.Run();
        ProcessTail.Run();
        ProcessLinked.Run();
        ProcessUniversal();
    }

    public static void ProcessUniversal()
    {
        Console.WriteLine(" CustomList ");
        ICustomCollection<int> list1 = new CustomList<int>(new[] { 1, 2, 3 });
        list1.Print();
        list1.AddLast(4);
        list1.Print();

        Console.WriteLine(" CustomListWithTail ");
        ICustomCollection<int> list2 = new CustomListWithTail<int>(new[] { 1, 2, 3 });
        list2.Print();
        list2.AddLast(4);
        list2.Print();

        Console.WriteLine(" CustomLinkedList ");
        ICustomCollection<int> list3 = new CustomLinkedList<int>(new[] { 1, 2, 3 });
        list3.Print();
        list3.AddLast(4);
        list3.Print();
        
        Console.WriteLine("Все коллекции работают через интерфейс!");
    }
}