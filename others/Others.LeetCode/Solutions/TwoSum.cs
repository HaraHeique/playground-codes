namespace Others.LeetCode.Solutions;

// TODO: Utilizar o https://github.com/dotnet/BenchmarkDotNet para medir performance das implementações e alocações de recursos com grande volume de dados
public class TwoSumSequence 
{
    public static void ShowSolution(params string[] _) 
    {
        int[] nums = [2, 11, 7, 15, -1, 6, 5, 150, 20];
        int target = 22;

        var positions = ExecuteBruteForceSolution(nums, target);
        Console.WriteLine($"[{positions.Item1},{positions.Item2}]");

        positions = ExecuteTwoPointersSolution(nums, target);
        Console.WriteLine($"[{positions.Item1},{positions.Item2}]");

        positions = ExecuteHashmapSolution(nums, target);
        Console.WriteLine($"[{positions.Item1},{positions.Item2}]");
    }

    private static (int, int) ExecuteBruteForceSolution(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int currentElemRef = nums[i];

            for (int nextI = i + 1; nextI < nums.Length; nextI++)
            {
                int elemToSum = nums[nextI];

                int sumResult = currentElemRef + elemToSum;

                if (sumResult == target) return (i, nextI);
            }
        }

        return (-1, -1);
    }

    /// <summary>
    /// Eu posso mudar a posição dos elementos no Array ao fornecer a posição em que se encontram?
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static (int, int) ExecuteTwoPointersSolution(int[] numsInput, int target)
    {
        // Talvez n log(n) no pior caso
        var nums = new int[numsInput.Length];
        numsInput.CopyTo(nums, 0);
        Array.Sort(nums);

        int firstPointer = 0;
        int lastPointer = nums.Length - 1;

        while (firstPointer != lastPointer)
        {
            int result = nums[firstPointer] + nums[lastPointer];
            
            if (result == target) return (firstPointer, lastPointer);

            if (result > target) 
                lastPointer--;
            else 
                firstPointer++;
        }

        return (-1, -1);
    }

    /// <summary>
    /// Best solution. Complexidade O(n)
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static (int, int) ExecuteHashmapSolution(int[] nums, int target)
    {
        Dictionary<int, int> numsFoundIt = [];

        for (int i = 0; i < nums.Length; i++)
        {
            int currentElem = nums[i];
            int complementElem = target - currentElem;

            if (numsFoundIt.TryGetValue(complementElem, out int posElem))
                return (posElem, i);

            numsFoundIt.Add(currentElem, i);
        }

        return (-1, -1);
    }
}