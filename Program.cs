using System.Diagnostics;

class Playground
{
    public static void Main(string[] args)
    {
        RunFibs(4);
    }
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


        if (RunAgain()) { RunFibs(n); }
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
    private static bool RunAgain()
    {
        Console.WriteLine("Run again (Y/N)?");
        var inputText = Console.ReadLine();
        if (inputText.ToUpper() != "Y")
        {
            Console.WriteLine("Bye bye...");
            return false;
        }
        return true;
    }
}