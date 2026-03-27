using System;
using Task.LinkedList;

class ProcessLinked
{
    public static void Run()
    {
        Console.WriteLine("============================================ CustomLinkedList ============================================");

        CustomLinkedList<int> emptyList = new CustomLinkedList<int>();
        
        CustomLinkedList<int> singleList = new CustomLinkedList<int>(42);
        Console.WriteLine("Один элемент:");
        singleList.Print();
        
        CustomLinkedList<int> numbers = new CustomLinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("Из массива:");
        numbers.Print();

        CustomLinkedList<string> fruits = new CustomLinkedList<string>();
        
        fruits.AddLast("Apple");
        fruits.AddLast("Banana");
        Console.WriteLine("После AddLast:");
        fruits.Print();
        
        fruits.AddFirst("Orange");
        Console.WriteLine("После AddFirst:");
        fruits.Print();
        
        fruits.AddInsert(2, "Mango");
        Console.WriteLine("После AddInsert(2, Mango):");
        fruits.Print();
        
        fruits.AddRange(new[] { "Grape", "Kiwi" });
        Console.WriteLine("После AddRange:");
        fruits.Print();

        CustomLinkedList<int> toRemove = new CustomLinkedList<int>(new[] { 10, 20, 30, 40, 50 });
        
        toRemove.RemoveFirst();
        Console.WriteLine("После RemoveFirst:");
        toRemove.Print();
        
        toRemove.RemoveLast();
        Console.WriteLine("После RemoveLast:");
        toRemove.Print();
        
        toRemove.RemoveAt(2);
        Console.WriteLine("После RemoveAt(2):");
        toRemove.Print();
        
        CustomLinkedList<int> twoElements = new CustomLinkedList<int>(new[] { 100, 200, 300 });
        twoElements.RemoveSecond();
        Console.WriteLine("После RemoveSecond:");
        twoElements.Print();
        
        CustomLinkedList<int> rangeRemove = new CustomLinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        rangeRemove.RemoveRange(2);
        Console.WriteLine("После RemoveRange(2):");
        rangeRemove.Print();
        
        CustomLinkedList<int> duplicates = new CustomLinkedList<int>(new[] { 5, 10, 5, 15, 5, 20 });
        duplicates.RemoveAllOccurrences(5);
        Console.WriteLine("После RemoveAllOccurrences(5):");
        duplicates.Print();

        CustomLinkedList<int> searchList = new CustomLinkedList<int>(new[] { 7, 14, 21, 14, 28 });
        
        bool has14 = searchList.Contains(14);
        bool has99 = searchList.Contains(99);
        Console.WriteLine($"Contains(14): {has14}");
        Console.WriteLine($"Contains(99): {has99}");
        
        Console.WriteLine("FindAllIndices(14):");
        searchList.FindAllIndices(14);
        
        Console.WriteLine($"Size: {searchList.Size()}");
        
        Console.WriteLine($"IsEmpty: {searchList.IsEmpty()}");
        Console.WriteLine($"Empty.IsEmpty: {new CustomLinkedList<int>().IsEmpty()}");

        CustomLinkedList<int> toReverse = new CustomLinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("До Reverse:");
        toReverse.Print();
        
        toReverse.Reverse();
        Console.WriteLine("После Reverse:");
        toReverse.Print();

        CustomLinkedList<int> empty = new CustomLinkedList<int>();
        Console.WriteLine("Пустой список:");
        empty.Print();
        
        empty.RemoveFirst();
        
        empty.AddInsert(1, 42);
        Console.WriteLine("После AddInsert(1, 42) в пустой:");
        empty.Print();
        
        CustomLinkedList<int> one = new CustomLinkedList<int>(999);
        one.RemoveLast();
        Console.WriteLine("После удаления из [999]:");
        one.Print();

        CustomLinkedList<string> words = new CustomLinkedList<string>(new[] { "Hello", "World" });
        words.AddLast("C#");
        words.AddFirst("Welcome");
        Console.WriteLine("\nСтроки:");
        words.Print();
        
        words.Reverse();
        Console.WriteLine("После Reverse:");
        words.Print();

        Console.WriteLine("Все примеры завершены");
    }
}