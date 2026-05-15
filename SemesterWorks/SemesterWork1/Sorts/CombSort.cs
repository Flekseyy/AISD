using System.Diagnostics;

namespace Sort;

public static class CombSort
{
    private const double ShrinkFactor = 1.3;

    public static (long iterArray, double msArray, long iterList, double msList) Measure(int[] input)
    {
        int[] arrIter = (int[])input.Clone();
        long itA = 0;
        SortArray(arrIter, ref itA);

        double msA = TimeMeter.MeasureTime(() =>
        {
            int[] arr = (int[])input.Clone();
            long dummy = 0;
            SortArray(arr, ref dummy);
        });

        var listIter = new List<int>(input);
        long itL = 0;
        SortList(listIter, ref itL);

        double msL = TimeMeter.MeasureTime(() =>
        {
            var list = new List<int>(input);
            long dummy = 0;
            SortList(list, ref dummy);
        });

        return (itA, msA, itL, msL);
    }

    private static void SortArray(int[] a, ref long iter)
    {
        int n = a.Length;
        int gap = n;
        bool swapped = true;

        while (gap != 1 || swapped)
        {
            gap = Math.Max(1, (int)(gap / ShrinkFactor));
            swapped = false;

            for (int i = 0; i + gap < n; i++)
            {
                iter++;
                if (a[i] > a[i + gap])
                {
                    (a[i], a[i + gap]) = (a[i + gap], a[i]);
                    swapped = true;
                }
            }
        }
    }

    private static void SortList(List<int> a, ref long iter)
    {
        int n = a.Count;
        int gap = n;
        bool swapped = true;

        while (gap != 1 || swapped)
        {
            gap = Math.Max(1, (int)(gap / ShrinkFactor));
            swapped = false;

            for (int i = 0; i + gap < n; i++)
            {
                iter++;
                if (a[i] > a[i + gap])
                {
                    (a[i], a[i + gap]) = (a[i + gap], a[i]);
                    swapped = true;
                }
            }
        }
    }
}