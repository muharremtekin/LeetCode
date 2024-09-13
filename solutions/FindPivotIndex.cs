
public class FindPivotIndex
{
    public static int PivotIndex(int[] nums)
    {
        // dizinin ortancasını bul 7 eleman varsa ortanca 4 olur
        // eleman sayısı çift ise eleman sayısını ikiye böl sola yakın olandan başla örn: 6 eleman varsa 3. den başla
        // int middle = nums.Length % 2 == 1 ? ((nums.Length - 1) / 2) + 1 : nums.Length / 2;


        for (int i = 0; i <= nums.Length - 1; i++)
        {
            int leftSum = 0;
            int rightSum = 0;
            // leftSum = index + soldaki elemanlar
            for (int left = 0; left <= i; left++)
                leftSum += nums[left];

            // right sum = index + sağ elemanlar
            for (int right = nums.Length - 1; right >= i; right--)
                rightSum += nums[right];

            if (leftSum == rightSum)
                return i;
        }

        return -1;
    }
}