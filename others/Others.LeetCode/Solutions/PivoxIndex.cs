namespace Others.LeetCode.Solutions;

public class PivoxIndexSequence
{
    public static void ShowSolution(params string[] @params)
    {
        /*
            Input = [1,7,3,6,5,6]
            Output = 3
        */

        int[] nums = [100,1,50,50];

        var result = ExecuteBruteForceSolution(nums);
        var result2 = ExecuteSolution(nums);

        Console.WriteLine($"Resultado com brute force: {result}");
        Console.WriteLine($"Resultado com otimização: {result2}");
    }

    private static int ExecuteBruteForceSolution(int[] input)
    {
        int candidatePivoxIndex = 0;

        while (candidatePivoxIndex < input.Length)
        {
            int leftSum = 0;

            for (int i = 0; i < candidatePivoxIndex; i++)
            {
                leftSum += input[i];
            }

            int rightSum = 0;

            for (int i = candidatePivoxIndex + 1; i < input.Length; i++)
            {
                rightSum += input[i];
            }

            if (leftSum == rightSum) return candidatePivoxIndex;

            candidatePivoxIndex++;
        }

        return -1;
    }
    
    private static int ExecuteSolution(int[] input)
    {
        if (!input.Any()) return -1;

        int candidatePivoxIndex = 0;
        int leftSum = 0;
        int rightSum = input.Sum() - input[candidatePivoxIndex];

        while (true)
        {
            if (leftSum == rightSum) return candidatePivoxIndex;

            candidatePivoxIndex++;

            if (candidatePivoxIndex >= input.Length) return -1;

            leftSum += input[candidatePivoxIndex - 1];
            rightSum -= input[candidatePivoxIndex];
        }
    }
}