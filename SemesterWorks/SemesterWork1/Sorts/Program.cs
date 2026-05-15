using System.Globalization;
using System.Text.Json;

namespace Sort;  

public class Program
{
    public static void Main(string[] args)
    {
        string folder = "data";
        string output = "результаты.txt";

        Console.WriteLine("Генерация входных данных");
        DataGenerator.GenerateFiles(folder);

        Console.WriteLine("\nЗапуск замеров ");
        BenchmarkRunner.Run(folder, output);

        Console.WriteLine("\n Готово! ");
        Console.WriteLine($"Результаты в файле: {output}");
    }
}
public static class BenchmarkRunner
{
    public static void Run(string dataFolder, string outputFile)
    {
        var results = new List<ResultRow>();

        foreach (int n in DataGenerator.GetSizes())
        {
            string file = Path.Combine(dataFolder, $"random_{n}.json");
            if (!File.Exists(file)) continue;

            int[] originalData = JsonSerializer.Deserialize<int[]>(File.ReadAllText(file))!;
            
            if (n <= 600) 
            {
                int[] dataClone = (int[])originalData.Clone();
                var (itA, msA, itL, msL) = StoogeSort.Measure(dataClone);
                
                results.Add(new ResultRow
                {
                    Algorithm = "StoogeSort",
                    Size = n,
                    DataType = "Массив",
                    TimeMs = msA,
                    Iterations = itA
                });
                
                results.Add(new ResultRow
                {
                    Algorithm = "StoogeSort",
                    Size = n,
                    DataType = "Список",
                    TimeMs = msL,
                    Iterations = itL
                });
            }
            
            {
                int[] dataClone = (int[])originalData.Clone();
                var (itA, msA, itL, msL) = CombSort.Measure(dataClone);
                
                results.Add(new ResultRow
                {
                    Algorithm = "CombSort",
                    Size = n,
                    DataType = "Массив",
                    TimeMs = msA,
                    Iterations = itA
                });
                
                results.Add(new ResultRow
                {
                    Algorithm = "CombSort",
                    Size = n,
                    DataType = "Список",
                    TimeMs = msL,
                    Iterations = itL
                });
            }
        }

        ResultWriter.WriteTxt(results, outputFile);
    }
}
public static class ResultWriter
{
    public static void WriteTxt(List<ResultRow> data, string path)
    {
        var culture = CultureInfo.InvariantCulture;

        using var writer = new StreamWriter(path, false, System.Text.Encoding.UTF8);
        
        writer.WriteLine("Алгоритм;Размер;Тип_данных;Время_мс;Итераций");

        foreach (var r in data)
        {
            writer.WriteLine(
                $"{r.Algorithm};{r.Size};{r.DataType};" +
                $"{r.TimeMs.ToString("F3", culture)};{r.Iterations}");
        }

        Console.WriteLine($"Результаты сохранены в '{path}'.");
    }
}