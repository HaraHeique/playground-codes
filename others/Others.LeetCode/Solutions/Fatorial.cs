namespace Others.LeetCode.Solutions;

public class Fatorial 
{
    public static void ShowSolution(params string[] @params) 
    {
        int n_factorial = int.Parse(@params[0]);

        int result = ExecuteSolution(n_factorial);

        Console.WriteLine($"N({n_factorial}) = {result}");

        result = ExecuteRecursiveSolution(n_factorial);

        Console.WriteLine($"N({n_factorial}) = {result}");
    }

    private static int ExecuteSolution(int n)
    {
        if (n <= 0) return 0;

        int productResult = 1;

        for (int fi = 1; fi <= n; fi++)
        {
            productResult *= fi;
        }

        return productResult;
    }

    private static int ExecuteRecursiveSolution(int n)
    {
        if (n <= 0) return 0;

        return Execute(n);

        static int Execute(int n)
        {
            if (n == 1) return 1;

            return n * Execute(n - 1);
        }
    }
}