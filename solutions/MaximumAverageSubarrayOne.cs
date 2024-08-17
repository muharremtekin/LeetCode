public static class MaximumAverageSubarrayOne
{
    // sliding window algoritması
    // zaman karmaşıklığı: O(n)
    // hafıza karmaşıklığı: O(1)
    // amacı: n elemanlı bir dizinin içerisinden k elemanlı alt dizilerini taramak ve belirli işlemler yapmak
    public static double Solution(int[] nums, int k)
    {
        if (nums.Length < k) return -1; // eğer dizi k'den küçükse -1 döndürüyoruz

        double maxSum = 0; // maxSum değişkeni oluşturuyoruz
        for (int i = 0; i < k; i++) // dizinin ilk k elemanını topluyoruz
            maxSum += nums[i];

        // dizinin k'dan sonraki elemanları için bir pencere oluşturuyoruz
        double windowSum = maxSum; // windowSum değişkenine maxSum değerini atıyoruz
        for (int i = k; i < nums.Length; i++) // dizinin k. elemanından başlayarak son elemanına kadar dönüyoruz
        {
            windowSum += nums[i] - nums[i - k]; // windowsSum'a yeni elemanı ekliyoruz ve pencerenin ilk elemanını çıkarıyoruz
            maxSum = Math.Max(maxSum, windowSum); // maxSum'u ve windowSum'u karşılaştırıp büyük olanı maxSum'a atıyoruz
        }

        return maxSum / k; // maxSum'u k'ya bölüp döndürüyoruz
    }
}