using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Aisd;
class Program
{
    public static void Run()
    {
        CustomList cl1 = new CustomList(1);
        cl1.Print();
        cl1.RemoveLast();
        cl1.Print();
        cl1.RemoveLast();
        
        CustomList cl2 = new CustomList(new[] { 1, 2, 3, 4, 5 });
        cl2.Print();
        cl2.RemoveLast();
        cl2.Print();
        
    }
}