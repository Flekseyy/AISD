using System.Diagnostics;

namespace Sort;

public static class TimeMeter
{
    public static double MeasureTime(Action action)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        action();
        sw.Stop();
        return sw.Elapsed.TotalMilliseconds;
    }
    
    public static double MeasureTimeAverage(Action action, int runs = 10)
    {
        action();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < runs; i++)
        {
            action();
        }
        sw.Stop();

        return sw.Elapsed.TotalMilliseconds / runs;
    }
}