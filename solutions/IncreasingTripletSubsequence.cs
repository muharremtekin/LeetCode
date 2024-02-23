public class IncreasingTripletSubsequence
{
    // wrong case 1
    // [6,7,1,2]
    // Output
    // true
    // Expected
    // false
    
    public static bool Solution(int[] nums)
    {
        List<int> list = nums.ToList();
        list.Sort();
        
        if (list.Count < 3)
            return false;

        int tempNum = 0;

        for (int i = 0; i < list.Count - 1; i++)
        {
            // TODO: ardışık olarak küçükten büyüğe doğru giden 3 sayı varsa true döndür.
            if (list[i] < list[i + 1])
                tempNum++;

            if (tempNum >= 2)
                return true;
        }

        return false;
    }
}