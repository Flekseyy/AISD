namespace Task.CustomListWithTail;
public class ProcessTail
{
    public static void Run()
    {
        Console.WriteLine("============================================ CustomList Tail ============================================");
        
        CustomListWithTail<int> emptyList = new CustomListWithTail<int>();
        
        CustomListWithTail<int> singleList = new CustomListWithTail<int>(42);
        Console.WriteLine("Один элемент:");
        singleList.Print();
        
        CustomListWithTail<int> numbers = new CustomListWithTail<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("Из массива:");
        numbers.Print();

        CustomListWithTail<string> fruits = new CustomListWithTail<string>();
        
        fruits.AddLast("Apple");
        fruits.AddLast("Banana");
        Console.WriteLine("\nПосле AddLast:");
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

        CustomListWithTail<int> toRemove = new CustomListWithTail<int>(new[] { 10, 20, 30, 40, 50 });
        
        toRemove.RemoveFirst();
        Console.WriteLine("\nПосле RemoveFirst:");
        toRemove.Print();
        
        toRemove.RemoveLast();
        Console.WriteLine("После RemoveLast:");
        toRemove.Print();
        
        toRemove.RemoveAt(2);
        Console.WriteLine("После RemoveAt(2):");
        toRemove.Print();
        
        CustomListWithTail<int> twoElements = new CustomListWithTail<int>(new[] { 100, 200, 300 });
        twoElements.RemoveSecond();
        Console.WriteLine("После RemoveSecond:");
        twoElements.Print();
        
        CustomListWithTail<int> rangeRemove = new CustomListWithTail<int>(new[] { 1, 2, 3, 4, 5 });
        rangeRemove.RemoveRange(2);
        Console.WriteLine("После RemoveRange(2):");
        rangeRemove.Print();
        
        CustomListWithTail<int> duplicates = new CustomListWithTail<int>(new[] { 5, 10, 5, 15, 5, 20 });
        duplicates.RemoveAllOccurrences(5);
        Console.WriteLine("После RemoveAllOccurrences(5):");
        duplicates.Print();

        CustomListWithTail<int> searchList = new CustomListWithTail<int>(new[] { 7, 14, 21, 14, 28 });
        
        bool has14 = searchList.Contains(14);
        bool has99 = searchList.Contains(99);
        Console.WriteLine($"\nContains(14): {has14}");
        Console.WriteLine($"Contains(99): {has99}");
        
        Console.WriteLine("FindAllIndices(14):");
        searchList.FindAllIndices(14);
        
        Console.WriteLine($"\nSize: {searchList.Size()}");
        
        Console.WriteLine($"IsEmpty: {searchList.IsEmpty()}");
        Console.WriteLine($"Empty.IsEmpty: {new CustomListWithTail<int>().IsEmpty()}");

        CustomListWithTail<int> toReverse = new CustomListWithTail<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine("\nДо Reverse:");
        toReverse.Print();
        
        toReverse.Reverse();
        Console.WriteLine("После Reverse:");
        toReverse.Print();

        CustomListWithTail<int> empty = new CustomListWithTail<int>();
        Console.WriteLine("\nПустой список:");
        empty.Print();
        
        empty.RemoveFirst();
        
        empty.AddInsert(1, 42);
        Console.WriteLine("После AddInsert(1, 42) в пустой:");
        empty.Print();
        
        CustomListWithTail<int> one = new CustomListWithTail<int>(999);
        one.RemoveLast();
        Console.WriteLine("\nПосле удаления из [999]:");
        one.Print();

        CustomListWithTail<string> words = new CustomListWithTail<string>(new[] { "Hello", "World" });
        words.AddLast("C#");
        words.AddFirst("Welcome");
        Console.WriteLine("\nСтроки:");
        words.Print();
        
        words.Reverse();
        Console.WriteLine("После Reverse:");
        words.Print();

        Console.WriteLine("\nВсе примеры завершены");
    }
}