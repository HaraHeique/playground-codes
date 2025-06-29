using System.Text;

namespace Others.LeetCode.Solutions;

public class ReverseInteger
{
    private const char NegativeSignal = '-';

    public static void ShowSolution(params string[] @params)
    {
        int num = 1534236;

        var result = InvertNumber(num);

        Console.WriteLine($"{num}: {result}");
    }

    private static int InvertNumber(int num)
    {
        string numAsString = num.ToString();
        StringBuilder newNum = new();
        bool isNegativeNumber = num < 0;

        for (int i = numAsString.Length - 1; i >= 0; i--)
        {
            char currentChar = numAsString[i];

            if (IsNegativeSignal(currentChar)) continue;

            newNum.Append(currentChar);
        }

        long result = long.Parse(newNum.ToString());

        if (isNegativeNumber)
            result *= -1;

        if (result > int.MaxValue)
            return 0;

        return (int)result;

        static bool IsNegativeSignal(char token) => token == NegativeSignal;
    }
}