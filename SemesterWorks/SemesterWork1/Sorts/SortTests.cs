namespace Sort;

public static class SortingTests
{
    private static int passed = 0, failed = 0;
    private static Random rng = new Random(99);

    private static void Assert(string name, bool condition)
    {
        if (condition)
        {
            Console.WriteLine($"  [OK]   {name}"); passed++;
        }
        else
        {
            Console.WriteLine($"  [FAIL] {name}"); failed++;
        }
    }

    private static int[] Rand(int n) =>
        Enumerable.Range(0, n).Select(_ => rng.Next(10000)).ToArray();

    private static void TestStoogeSort()
    {
        Console.WriteLine("\n--- Stooge Sort ---");

        int[] a1 = { 9, 3, 1, 7, 5, 2 };
        var (itA1, _, itL1, _) = StoogeSort.Measure(a1);
        Assert("Случайный массив: итераций > 0", itA1 > 0);
        Assert("Случайный массив: итераций массив == список", itA1 == itL1);

        int[] a2 = { 1, 2, 3, 4, 5 };
        var (itA2, _, _, _) = StoogeSort.Measure(a2);
        Assert("Уже отсортированный: итераций > 0", itA2 > 0);

        int[] a3 = { 9, 7, 5, 3, 1 };
        var (itA3, _, _, _) = StoogeSort.Measure(a3);
        Assert("Обратный порядок: итераций > 0", itA3 > 0);

        int[] a4 = { 42 };
        var (itA4, ms4, _, _) = StoogeSort.Measure(a4);
        Assert("Один элемент: 1 итерация", itA4 == 1);
        Assert("Один элемент: время >= 0", ms4 >= 0);

        int[] a5 = { 2, 1 };
        var (itA5, _, _, _) = StoogeSort.Measure(a5);
        Assert("Два элемента (перевёрнутые): итераций >= 1", itA5 >= 1);

        int[] a6 = { 5, 5, 5, 5 };
        var (itA6, _, _, _) = StoogeSort.Measure(a6);
        Assert("Все одинаковые: итераций > 0", itA6 > 0);

        int[] a7 = Rand(100);
        var (itA7, _, _, _) = StoogeSort.Measure(a7);
        Assert("n=100: итераций > 1000", itA7 > 1000);

        int[] a8 = Rand(50);
        var (_, ms8, _, _) = StoogeSort.Measure(a8);
        Assert("Stopwatch: время >= 0", ms8 >= 0);

        int[] a9 = { 3, 1 };
        var (itA9, _, itL9, _) = StoogeSort.Measure(a9);
        Assert("2 элемента: массив == список по итерациям", itA9 == itL9);

        int[] a10 = Rand(200);
        var (itA10, _, _, _) = StoogeSort.Measure(a10);
        Assert("n=200: итераций > n", itA10 > 200);
    }

    private static void TestCombSort()
    {
        Console.WriteLine("\n--- Comb Sort ---");

        int[] a1 = { 9, 3, 1, 7, 5, 2 };
        var (itA1, _, itL1, _) = CombSort.Measure(a1);
        Assert("Случайный массив: итераций > 0", itA1 > 0);
        Assert("Случайный массив: массив == список по итерациям", itA1 == itL1);

        int[] a2 = { 1, 2, 3, 4, 5 };
        var (itA2, _, _, _) = CombSort.Measure(a2);
        Assert("Уже отсортированный: итераций > 0", itA2 > 0);

        int[] a3 = { 9, 7, 5, 3, 1 };
        var (itA3, _, _, _) = CombSort.Measure(a3);
        Assert("Обратный порядок: итераций > 0", itA3 > 0);

        int[] a4 = { 42 };
        var (itA4, ms4, _, _) = CombSort.Measure(a4);
        Assert("Один элемент: 0 итераций", itA4 == 0);
        Assert("Один элемент: время >= 0", ms4 >= 0);

        int[] a5 = { 2, 1 };
        var (itA5, _, _, _) = CombSort.Measure(a5);
        Assert("Два элемента: итераций >= 1", itA5 >= 1);

        int[] a6 = { 5, 5, 5, 5 };
        var (itA6, _, _, _) = CombSort.Measure(a6);
        Assert("Все одинаковые: итераций > 0", itA6 > 0);

        int[] a7 = Rand(100);
        var (itA7C, _, _, _) = CombSort.Measure(a7);
        var (itA7S, _, _, _) = StoogeSort.Measure(a7);
        Assert("n=100: Comb меньше итераций чем Stooge", itA7C < itA7S);

        int[] a8 = Rand(1000);
        var (itA8, _, _, _) = CombSort.Measure(a8);
        Assert("n=1000: итераций > 1000", itA8 > 1000);

        int[] a9 = { 3, 1 };
        var (itA9, _, itL9, _) = CombSort.Measure(a9);
        Assert("2 элемента: массив == список по итерациям", itA9 == itL9);

        int[] a10 = Rand(5000);
        var (_, ms10, _, _) = CombSort.Measure(a10);
        Assert("n=5000: Stopwatch >= 0", ms10 >= 0);
    }

    public static void RunAll()
    {
        Console.WriteLine("ТЕСТЫ");
        TestStoogeSort();
        TestCombSort();
        Console.WriteLine($"\n Пройдено: {passed}, Провалено: {failed}");
    }
}
