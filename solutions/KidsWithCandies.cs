public sealed class KidsWithCandies
{
    /// <summary>
    /// Time complexty O(2n) = O(n),
    /// 
    /// Space complexty O(n)
    /// </summary>
    /// <param name="candies"></param>
    /// <param name="extraCandies"></param>
    /// <returns></returns>
    public static IList<bool> Solution(int[] candies, int extraCandies)
    {
        // candies[i] + extraCandies dizinin en büyük elemanı oluyorsa true 
        // aksi durumda false

        // cevap dizisini oluşturuyoruz
        bool[] response = new bool[candies.Length];
        // dizinin en büyük elemanını bul
        int maxVal = candies.Max();
        // candies[index] + extraCandies < maxVal response[index] = false;
        for (int index = 0; index < candies.Length; index++)
        {
            if (candies[index] + extraCandies < maxVal)
                response[index] = false;
            else
                response[index] = true;
        }
        return response;
    }
}