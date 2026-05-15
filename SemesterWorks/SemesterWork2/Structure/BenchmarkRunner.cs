using System.Diagnostics;
using System.Text.Json;

namespace Structure;

public class ResultRow
{
    public string Variant   { get; set; } = "";
    public int    Size      { get; set; }
    public double InsertMs  { get; set; }
    public double SearchMs  { get; set; }
    public double DeleteMs  { get; set; }
    public double BfsMs     { get; set; }
    public double InOrderMs { get; set; }
}

public static class BenchmarkRunner
{
    private static double TicksToMs(long ticks) =>
        (double)ticks / Stopwatch.Frequency * 1000.0;

    public static void Run(string dataFolder, string outputFile)
    {
        var results = new List<ResultRow>();
        var sw = new Stopwatch();

        string[] variants     = { "random",    "sorted",          "reversed" };
        string[] variantNames = { "случайный", "отсортированный", "обратный" };

        for (int v = 0; v < variants.Length; v++)
        {
            foreach (string file in Directory.GetFiles(dataFolder, $"{variants[v]}_*.json"))
            {
                int[] data = JsonSerializer.Deserialize<int[]>(File.ReadAllText(file))!;
                int n = data.Length;

                var tree = new AvlTree();

                sw.Restart();
                foreach (int x in data) tree.Insert(x);
                sw.Stop();
                double insertMs = TicksToMs(sw.ElapsedTicks);

                sw.Restart();
                foreach (int x in data) tree.Search(x);
                sw.Stop();
                double searchMs = TicksToMs(sw.ElapsedTicks);

                sw.Restart();
                tree.BfsTraversal();
                sw.Stop();
                double bfsMs = TicksToMs(sw.ElapsedTicks);

                sw.Restart();
                tree.InOrderTraversal();
                sw.Stop();
                double inOrderMs = TicksToMs(sw.ElapsedTicks);

                sw.Restart();
                foreach (int x in data) tree.Delete(x);
                sw.Stop();
                double deleteMs = TicksToMs(sw.ElapsedTicks);

                results.Add(new ResultRow {
                    Variant   = variantNames[v],
                    Size      = n,
                    InsertMs  = insertMs,
                    SearchMs  = searchMs,
                    DeleteMs  = deleteMs,
                    BfsMs     = bfsMs,
                    InOrderMs = inOrderMs
                });
            }
        }

        using var w = new StreamWriter(outputFile);
        w.WriteLine("Вариант Размер Вставка_мс Поиск_мс Удаление_мс BFS_мс InOrder_мс");
        foreach (var r in results)
            w.WriteLine($"{r.Variant} {r.Size} {r.InsertMs:F4} {r.SearchMs:F4} {r.DeleteMs:F4} {r.BfsMs:F4} {r.InOrderMs:F4}");

        Console.WriteLine($"Результаты записаны в '{outputFile}'.");
    }
}
public static class DataGenerator
{
    public static int[] GetSizes()
    {
        int[] sizes = new int[50];
        for (int i = 0; i < 50; i++)
            sizes[i] = 100 + i * (99900 / 49);
        return sizes;
    }

    public static void GenerateFiles(string folder, int seed = 42)
    {
        Directory.CreateDirectory(folder);
        var rng = new Random(seed);

        foreach (int n in GetSizes())
        {
            int[] random = new int[n];
            for (int i = 0; i < n; i++)
                random[i] = rng.Next(0, 1000000);

            int[] sorted = (int[])random.Clone();
            Array.Sort(sorted);

            int[] reversed = (int[])sorted.Clone();
            Array.Reverse(reversed);

            File.WriteAllText(Path.Combine(folder, $"random_{n}.json"),   JsonSerializer.Serialize(random));
            File.WriteAllText(Path.Combine(folder, $"sorted_{n}.json"),   JsonSerializer.Serialize(sorted));
            File.WriteAllText(Path.Combine(folder, $"reversed_{n}.json"), JsonSerializer.Serialize(reversed));
        }

        Console.WriteLine($"Сгенерировано {GetSizes().Length * 3} файлов в папке '{folder}'.");
    }
}