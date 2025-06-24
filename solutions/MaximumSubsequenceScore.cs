public class MaximumSubsequenceScore
{
    // https://leetcode.com/problems/maximum-subsequence-score/description/?envType=study-plan-v2&envId=leetcode-75

    // You are given two 0-indexed integer arrays nums1 and nums2 of equal length n and a positive integer k. 
    // You must choose a subsequence of indices from nums1 of length k.

    // For chosen indices i0, i1, ..., ik - 1, your score is defined as:
    // The sum of the selected elements from nums1 multiplied with the minimum of the selected elements from nums2.
    // It can defined simply as: (nums1[i0] + nums1[i1] +...+ nums1[ik - 1]) * min(nums2[i0] , nums2[i1], ... ,nums2[ik - 1]).
    // Return the maximum possible score.

    // A subsequence of indices of an array is a set that can be derived from the set {0, 1, ..., n-1} by deleting some or no elements.
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        PriorityQueue<int, int> pq = new();

        int maximum = 0;



        return 0;
    }


    // it was a medium-hard level and i couldn't solve it

    /// <remarks>
    /// Time Complexity: O(n log n) where n is the length of the input arrays.
    /// The sorting step takes O(n log n) and the heap operations over n elements take O(n log k).
    ///
    /// Space Complexity: O(n) for the pairs array.
    /// Additional O(k) space is used for the heap, which is within the O(n) overall space.
    /// </remarks>
    public long MaxScoreGeneratedByGemini(int[] nums1, int[] nums2, int k)
    {
        int n = nums1.Length;

        // 1. (nums1, nums2) çiftlerini oluştur.
        (int n1, int n2)[] pairs = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            pairs[i] = (nums1[i], nums2[i]);
        }

        // 2. Çiftleri, nums2 değerine göre büyükten küçüğe sırala.
        Array.Sort(pairs, (a, b) => b.n2.CompareTo(a.n2));

        // 3. k eleman tutacak bir Minimum Yığın (PriorityQueue) oluştur.
        // PriorityQueue<eleman, öncelik>
        PriorityQueue<int, int> top_k_heap = new PriorityQueue<int, int>();

        long current_sum = 0;
        long max_score = 0;

        // 4. Sıralanmış çiftler üzerinde döngüye başla.
        foreach (var pair in pairs)
        {
            int current_n1 = pair.n1;
            int current_n2 = pair.n2;

            // 5a. current_n1'i yığına ve toplama ekle.
            top_k_heap.Enqueue(current_n1, current_n1);
            current_sum += current_n1;

            // 5c. Yığının boyutu k'yı geçerse en küçüğü çıkar.
            if (top_k_heap.Count > k)
            {
                int smallest = top_k_heap.Dequeue();
                current_sum -= smallest;
            }

            // 5d. Yığının boyutu tam k ise skoru hesapla.
            if (top_k_heap.Count == k)
            {
                max_score = Math.Max(max_score, current_sum * current_n2);
            }
        }

        return max_score;
    }
}