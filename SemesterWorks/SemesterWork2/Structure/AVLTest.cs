namespace Structure;

public static class AvlTests
{
    static int passed = 0, failed = 0;
    static Random rng = new Random(77);

    static void Assert(string name, bool condition)
    {
        if (condition)
        {
            Console.WriteLine($"  [OK]   {name}"); 
            passed++;
        }
        else
        {
            Console.WriteLine($"  [FAIL] {name}"); 
            failed++;
        }
    }

    static void TestInsert()
    {
        Console.WriteLine("\n--- Вставка ---");

        var t = new AvlTree();
        t.Insert(10);
        Assert("Один элемент: поиск находит его", t.Search(10));

        t.Insert(20); t.Insert(5);
        Assert("Три элемента: все находятся", t.Search(20) && t.Search(5));

        t.Insert(10);
        Assert("Дубликат не добавляется", t.InOrderTraversal().Count(x => x == 10) == 1);

        var t2 = new AvlTree();
        for (int i = 1; i <= 100; i++) t2.Insert(i);
        Assert("100 последовательных: In-order возвращает 100 элементов", t2.InOrderTraversal().Count == 100);

        var t3 = new AvlTree();
        for (int i = 100; i >= 1; i--) t3.Insert(i);
        var sorted = t3.InOrderTraversal();
        Assert("Вставка в обратном порядке: In-order отсортирован",
            sorted.Zip(sorted.Skip(1), (a, b) => a <= b).All(x => x));
    }

    static void TestSearch()
    {
        Console.WriteLine("\n--- Поиск ---");

        var t = new AvlTree();
        Assert("Поиск в пустом дереве: false", !t.Search(42));

        t.Insert(15); t.Insert(7); t.Insert(25);
        Assert("Поиск корня: true", t.Search(15));
        Assert("Поиск левого потомка: true", t.Search(7));
        Assert("Поиск правого потомка: true", t.Search(25));
        Assert("Поиск несуществующего: false", !t.Search(99));

        var t2 = new AvlTree();
        for (int i = 0; i < 1000; i++) t2.Insert(rng.Next(10000));
        Assert("Поиск -1 в большом дереве: false", !t2.Search(-1));
    }

    static void TestDelete()
    {
        Console.WriteLine("\n--- Удаление ---");

        var t = new AvlTree();
        t.Insert(10); t.Insert(5); t.Insert(20);
        t.Delete(5);
        Assert("Удаление листа: элемент не найден", !t.Search(5));
        Assert("Удаление листа: остальные на месте", t.Search(10) && t.Search(20));

        var t2 = new AvlTree();
        t2.Insert(10); t2.Insert(5); t2.Insert(20); t2.Insert(15);
        t2.Delete(20);
        Assert("Удаление узла с одним потомком", !t2.Search(20) && t2.Search(15));

        var t3 = new AvlTree();
        t3.Insert(10); t3.Insert(5); t3.Insert(20);
        t3.Delete(10);
        Assert("Удаление корня с двумя потомками: корень удалён", !t3.Search(10));
        Assert("Удаление корня: потомки на месте", t3.Search(5) && t3.Search(20));

        var t4 = new AvlTree();
        t4.Delete(42);
        Assert("Удаление из пустого дерева: без исключений", true);
    }

    static void TestTraversal()
    {
        Console.WriteLine("\n--- Обходы ---");

        var t = new AvlTree();
        t.Insert(10); t.Insert(5); t.Insert(20); t.Insert(3); t.Insert(7);

        var inOrder = t.InOrderTraversal();
        Assert("In-order: все 5 элементов", inOrder.Count == 5);
        Assert("In-order: элементы по возрастанию",
            inOrder.Zip(inOrder.Skip(1), (a, b) => a <= b).All(x => x));

        var bfs = t.BfsTraversal();
        Assert("BFS: все 5 элементов", bfs.Count == 5);

        var empty = new AvlTree();
        Assert("In-order пустого дерева: пустой список", empty.InOrderTraversal().Count == 0);
        Assert("BFS пустого дерева: пустой список", empty.BfsTraversal().Count == 0);
    }

    public static void RunAll()
    {
        Console.WriteLine("ТЕСТЫ AVL-ДЕРЕВА");
        TestInsert();
        TestSearch();
        TestDelete();
        TestTraversal();
        Console.WriteLine($"\n Пройдено: {passed}, Провалено: {failed} ");
    }
}