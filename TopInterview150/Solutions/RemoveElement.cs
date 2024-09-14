public class RemoveElement
{
    public static int Solution(int[] nums, int val)
    {
        int result = 0;
        foreach (var item in nums)
        {
            if(item != val)
            {
                nums[result] = item;
                result++;
            }
        }   

        return result;
    }
}