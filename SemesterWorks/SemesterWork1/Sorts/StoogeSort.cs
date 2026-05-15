using System.Diagnostics;

namespace Sort;

public static class StoogeSort
{
    public static (long iterArray, double msArray, long iterList, double msList) Measure(int[] input)
    {
        int[] arrIter = (int[])input.Clone();
        long itA = 0;
        SortArray(arrIter, 0, arrIter.Length - 1, ref itA);

        double msA = TimeMeter.MeasureTime(() =>
        {
            int[] arr = (int[])input.Clone();
            long dummy = 0;
            SortArray(arr, 0, arr.Length - 1, ref dummy);
        });
        
        var listIter = new List<int>(input);
        long itL = 0;
        SortList(listIter, 0, listIter.Count - 1, ref itL);

        double msL = TimeMeter.MeasureTime(() =>
        {
            var list = new List<int>(input);
            long dummy = 0;
            SortList(list, 0, list.Count - 1, ref dummy);
        });

        return (itA, msA, itL, msL);
    }

    private static void SortArray(int[] a, int l, int r, ref long iter)
    {
        iter++;
        if (l >= r) return;

        if (a[l] > a[r])
        {
            (a[l], a[r]) = (a[r], a[l]);
        }

        if (r - l + 1 > 2)
        {
            int t = (r - l + 1) / 3;
            SortArray(a, l, r - t, ref iter);
            SortArray(a, l + t, r, ref iter);
            SortArray(a, l, r - t, ref iter);
        }
    }

    private static void SortList(List<int> a, int l, int r, ref long iter)
    {
        iter++;
        if (l >= r) return;

        if (a[l] > a[r])
        {
            (a[l], a[r]) = (a[r], a[l]);
        }

        if (r - l + 1 > 2)
        {
            int t = (r - l + 1) / 3;
            SortList(a, l, r - t, ref iter);
            SortList(a, l + t, r, ref iter);
            SortList(a, l, r - t, ref iter);
        }
    }
}