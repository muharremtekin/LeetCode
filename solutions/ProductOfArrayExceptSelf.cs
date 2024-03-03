using System.Buffers;

// kafam karıştı
class ProductOfArrayExceptSelf
{
    // nums = [1,2,3,4];
    // answer[2] = 1 * 3 * 4;
    public static int[] Solution(int[] nums)
    {
        List<int> answer = new();

        for (int i = 0; i < nums.Length; i++)
        {
            answer[i] = Multiply(nums, i);
        }

        return answer.ToArray();
    }

    public static int Multiply(int[] nums, int skipIndex)
    {
        List<int> ints = new();

        int val = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                return 0;
            if (i == skipIndex)
                continue;
            ints.Add(val *= nums[i]);
        }
        return val;
    }
}