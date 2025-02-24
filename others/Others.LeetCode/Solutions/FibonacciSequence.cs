namespace Others.LeetCode.Solutions;

public class FibonacciSequence 
{
    public static void ShowSolution(params string[] @params) 
    {
        int fiboNumber = int.Parse(@params[0]);

        int result = ExecuteSolution(fiboNumber);

        Console.WriteLine($"F({fiboNumber}) = {result}");

        result = ExecuteRecursiveSolution(fiboNumber);

        Console.WriteLine($"F_Recursive({fiboNumber}) = {result}");
    }

    private static int ExecuteSolution(int fiboNumber) 
    {
        int n_2 = 0;
        int n_1 = 1;

        if (fiboNumber == 0) return n_2;
        if (fiboNumber == 1) return n_1;

        int currentFiboNumber = 2;
        int fiboNumberResult = 0;

        while (currentFiboNumber <= fiboNumber)
        {
            fiboNumberResult = n_1 + n_2;
            
            n_2 = n_1;
            n_1 = fiboNumberResult;

            currentFiboNumber++;
        }

        return fiboNumberResult;
    }

    private static int ExecuteRecursiveSolution(int fiboNumber) 
    {
        return F(fiboNumber);

        static int F(int n) 
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            return F(n - 1) + F(n - 2);
        }
    }
}