using Structure;

public class Program
{
    public static void Main(string[] args)
    {
        string folder = "data";
        string output = "результаты_avl.txt";

        Console.WriteLine(" Генерация входных данных ");
        DataGenerator.GenerateFiles(folder);

        Console.WriteLine(" Запуск замеров ");
        BenchmarkRunner.Run(folder, output);

        Console.WriteLine("Готово!");
    }
}