using System.Diagnostics;

public sealed class MoveZeroes
{
    //Example 1:

    // Input: nums = [0, 1, 0, 3, 12]
    // Output: [1, 3, 12, 0, 0]
    // Example 2:

    // Input: nums = [0]
    // Output: [0]
    public static void Solution(int[] nums)
    {
        // kaç tane sıfır olduğunu bul
        // sıfırların sayısını dizinin uzunluğundan çıkar
        // bir döngüde 
        // if(nums.Length < 2)
        //     return;
        var test = nums.Where(a => a == 0).Count();
        List<int> res = new();

        int zeroCount = 0;

        foreach (int num in nums)
        {
            if (num is 0)
                zeroCount++;
            else
                res.Add(num);
        }

        for (int i = 1; i <= zeroCount; i++)
            res.Add(0);

        Array.Clear(nums);
        res.CopyTo(nums);

        Console.WriteLine(res);
    }
    public static void SolutionV2(int[] nums)
    {
        int nonZeroIndex = 0; 

        foreach (int num in nums)
        {
            if (num != 0)
            {
                nums[nonZeroIndex] = num;
                nonZeroIndex++;
            }
        }

        for (int i = nonZeroIndex; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}
