using System.Text.Json;
using ClosedXML.Excel;
namespace Sort;

public static class DataGenerator
{
    public static int[] GetSizes()
    {
        int[] sizes = new int[50];
        for (int i = 0; i < 50; i++)
            sizes[i] = 100 + i * (9900 / 49);
        return sizes;
    }

    public static void GenerateFiles(string folder, int seed = 42)
    {
        if (Directory.Exists(folder))
            Directory.Delete(folder, true);
        
        Directory.CreateDirectory(folder);
        var rng = new Random(seed);

        foreach (int n in GetSizes())
        {
            int[] random = new int[n];
            for (int i = 0; i < n; i++)
                random[i] = rng.Next(0, 100000);
            
            File.WriteAllText(
                Path.Combine(folder, $"random_{n}.json"), 
                JsonSerializer.Serialize(random));
        }

        Console.WriteLine($"Сгенерировано {GetSizes().Length} файлов в папке '{folder}'.");
    }
}

