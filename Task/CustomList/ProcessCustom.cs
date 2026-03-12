using System;
namespace Task.CustomList;


class ProcessCustom
{
    public static void Run()
    {
        Console.WriteLine("============================================ CustomList ============================================");
        CustomList<int> emptyList = new CustomList<int>();
        
        CustomList<int> singleList = new CustomList<int>(42);
        Console.WriteLine("Один элемент:");
        singleList.Print();
        
        CustomList<int> numbers = new CustomList<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("Из массива:");
        numbers.Print();

        CustomList<string> fruits = new CustomList<string>();
        
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

        CustomList<int> toRemove = new CustomList<int>(new[] { 10, 20, 30, 40, 50 });
        
        toRemove.RemoveFirst();
        Console.WriteLine("После RemoveFirst:");
        toRemove.Print();
        
        toRemove.RemoveLast();
        Console.WriteLine("После RemoveLast:");
        toRemove.Print();
        
        toRemove.RemoveAt(2);
        Console.WriteLine("После RemoveAt(2):");
        toRemove.Print();
        
        CustomList<int> twoElements = new CustomList<int>(new[] { 100, 200, 300 });
        twoElements.RemoveSecond();
        Console.WriteLine("После RemoveSecond:");
        twoElements.Print();
        
        CustomList<int> rangeRemove = new CustomList<int>(new[] { 1, 2, 3, 4, 5 });
        rangeRemove.RemoveRange(2);
        Console.WriteLine("После RemoveRange(2):");
        rangeRemove.Print();
        
        CustomList<int> duplicates = new CustomList<int>(new[] { 5, 10, 5, 15, 5, 20 });
        duplicates.RemoveAllOccurrences(5);
        Console.WriteLine("После RemoveAllOccurrences(5):");
        duplicates.Print();

        CustomList<int> searchList = new CustomList<int>(new[] { 7, 14, 21, 14, 28 });
        
        bool has14 = searchList.Contains(14);
        bool has99 = searchList.Contains(99);
        Console.WriteLine($"Contains(14): {has14}");
        Console.WriteLine($"Contains(99): {has99}");
        
        Console.WriteLine("FindAllIndices(14):");
        searchList.FindAllIndices(14);
        
        Console.WriteLine($"Size: {searchList.Size()}");
        
        Console.WriteLine($"IsEmpty: {searchList.IsEmpty()}");
        Console.WriteLine($"Empty.IsEmpty: {new CustomList<int>().IsEmpty()}");

        CustomList<int> toReverse = new CustomList<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("До Reverse:");
        toReverse.Print();
        
        toReverse.Reverse();
        Console.WriteLine("После Reverse:");
        toReverse.Print();

        CustomList<int> empty = new CustomList<int>();
        Console.WriteLine("Пустой список:");
        empty.Print();
        
        empty.RemoveFirst();
        
        empty.AddInsert(1, 42);
        Console.WriteLine("После AddInsert(1, 42) в пустой:");
        empty.Print();
        
        CustomList<int> one = new CustomList<int>(999);
        one.RemoveLast();
        Console.WriteLine("После удаления из [999]:");
        one.Print();

        CustomList<string> words = new CustomList<string>(new[] { "Hello", "World" });
        words.AddLast("C#");
        words.AddFirst("Welcome");
        Console.WriteLine("Строки:");
        words.Print();
        
        words.Reverse();
        Console.WriteLine("После Reverse:");
        words.Print();

        Console.WriteLine("Все примеры завершены");
    }
}