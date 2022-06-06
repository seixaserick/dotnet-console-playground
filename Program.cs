

class Playground
{
    public static void Main(string[] args)
    {
        RunFib();
    }
    public static void RunFib(){
        TimeSpan duration;
        DateTime start = DateTime.Now;
        int n = 44, fib = 0;
        fib = CalculateFibonacciTailRecursiveMethod(n);
        duration = DateTime.Now - start;
        Console.WriteLine($"Fib({n}) is {fib} and execution time is {duration.TotalMilliseconds} ms");
        if (RunAgain())
        {
            RunFib();
        }
    }
    public static int CalculateFibonacciTailRecursiveMethod(int n, int previous = 0, int current = 1)
    {
        if (n == 0) { return previous; }
        if (n == 1) { return current; }
        return CalculateFibonacciTailRecursiveMethod(n - 1, current, previous + current);
    }
    private static bool RunAgain() {
        Console.WriteLine("Run again (Y/N)?");
        var inputText = Console.ReadLine();
        Console.Clear();
        return inputText.ToUpper() == "Y";
 
    }
}