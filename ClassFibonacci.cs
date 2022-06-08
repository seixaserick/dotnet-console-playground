using System.Collections.Generic;
using System.Diagnostics;
namespace Playground;

class ClassFibonacci
{
   
    public static void RunFibs(int n)
    {
        TimeSpan duration;
        int fibRec, fibDPA, fibDPL;
        DateTime start;
        Console.WriteLine("Starting Fibonacci calculations...");

        start = DateTime.Now;
        fibRec = CalculateFibonacciTailRecursive(n);
        duration = DateTime.Now - start;
        Console.WriteLine($"FibRec({n}) is {fibRec} and execution time is {duration.TotalMilliseconds.ToString().PadLeft(10)} ms");

        start = DateTime.Now;
        fibDPA = CalculateFibonacciDynamicProgrammingArray(n);
        duration = DateTime.Now - start;
        Console.WriteLine($"FibDPA({n})  is {fibDPA} and execution time is {duration.TotalMilliseconds.ToString().PadLeft(10)} ms");

        start = DateTime.Now;
        fibDPL = CalculateFibonacciDynamicProgrammingList(n);
        duration = DateTime.Now - start;
        Console.WriteLine($"FibDPL({n})  is {fibDPL} and execution time is {duration.TotalMilliseconds.ToString().PadLeft(10)} ms");

 
    }
    public static int CalculateFibonacciTailRecursive(int n, int previous = 0, int current = 1)
    {
        if (n == 0) { return previous; }
        if (n == 1) { return current; }
        return CalculateFibonacciTailRecursive(n - 1, current, previous + current);
    }
    public static int CalculateFibonacciDynamicProgrammingArray(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0; dp[1] = 1;
        if (n < 2) { return dp[n]; }
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
    public static int CalculateFibonacciDynamicProgrammingList(int n)
    {
        List<int> dp = new List<int>(n + 1);
        dp.AddRange(new int[] { 0, 1 });
        if (n < 2) { return dp[n]; }
        for (int i = 2; i <= n; i++)
        {
            dp.Add(dp[i - 1] + dp[i - 2]);
        }
        return dp[n];
    }

    public static int find_it(int[] seq)
    //Given an array of integers, find the one that appears an odd number of times.
    {

        if (seq.Length == 0) { return -1; }
        if (seq.Length == 1) { return seq[0]; }

        Array.Sort(seq);
        int[,] myDistictElements = new int[seq.Length, 2];

        int distictElementCount = 1;
        myDistictElements[distictElementCount - 1, 0] = seq[0]; //first item value
        myDistictElements[distictElementCount - 1, 1] = 1; //first item count
        //for other elemtns after the first one
        for (int i = 1; i < seq.Length; i++)
        {
            if (seq[i] != seq[i - 1])
            {
                distictElementCount++; //more one distinct element found
                myDistictElements[distictElementCount - 1, 0] = seq[i];
            }

            myDistictElements[distictElementCount, 1]++;

        }

        for (int j = 0; j < myDistictElements.GetLength(0); j++)
        {
            Console.WriteLine($" myDistictElements[{j},0]= {myDistictElements[j, 0]} and count {myDistictElements[j, 1]}");
        }



        return 1;

    }
    //private static void Sort<T>(T[][] data, int col)
    //{
    //    Comparer<T> comparer = Comparer<T>.Default;
    //    Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
    //}

    //private static int[] SortArray(int[,] inputArray)
    //{

    //    List<Order> SortedList = myList.OrderBy(o => o.OrderDate).ThenBy(order => order.OrderId).ToList();


    //}


 

}

