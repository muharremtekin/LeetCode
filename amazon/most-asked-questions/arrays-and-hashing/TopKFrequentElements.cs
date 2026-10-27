public class TopKFrequentElements
{
    // https://leetcode.com/problems/top-k-frequent-elements/
    // Time Complexity: O(n + m log m), where m is the number of unique values.
    // Space Complexity: O(m + k), O(m) if the output array is excluded.
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int current = nums[i];
            if (dict.ContainsKey(current))
                dict[current]++;
            else
                dict[current] = 1;
        }
        return dict
                .OrderByDescending(e => e.Value)
                .Take(k)
                .Select(e => e.Key)
                .ToArray();
    }

    // Bucket Sort: O(n) time, O(n) space.
    // Time Complexity: O(n + m), which is O(n) because m <= n.
    // Space Complexity: O(n + k), O(n) if the output array is excluded.
    // `buckets[f]` holds all numbers that occur exactly f times.
    public static int[] TopKFrequentV2(int[] nums, int k)
    {
        // 1. Count each number's frequency.
        var frequencies = new Dictionary<int, int>();
        foreach (int number in nums)
        {
            frequencies[number] = frequencies.GetValueOrDefault(number) + 1;
        }

        // 2. A frequency can be at most nums.Length, so it can be an array index.
        var buckets = new List<int>[nums.Length + 1];
        foreach (var (number, frequency) in frequencies)
        {
            buckets[frequency] ??= new List<int>();
            buckets[frequency].Add(number);
        }

        // 3. Visit frequencies from high to low until k elements are collected.
        var result = new List<int>(k);
        for (int frequency = buckets.Length - 1; frequency >= 0 && result.Count < k; frequency--)
        {
            if (buckets[frequency] is null)
                continue;

            foreach (int number in buckets[frequency])
            {
                result.Add(number);

                if (result.Count == k)
                    return result.ToArray();
            }
        }

        return result.ToArray();
    }


    // Min Heap: keeps only the top k frequent values in the heap.
    // Time Complexity: O(n + m log k), where m is the number of unique values.
    // Space Complexity: O(m + k).
    public static int[] TopKFrequentV3(int[] nums, int k)
    {
        var frequencies = new Dictionary<int, int>();

        foreach (int number in nums)
        {
            frequencies[number] = frequencies.GetValueOrDefault(number) + 1;
        }

        // C# PriorityQueue varsayılan olarak min-heap'tir:
        // En küçük priority (frekans) önce çıkar.
        var minHeap = new PriorityQueue<int, int>();

        foreach (var (number, frequency) in frequencies)
        {
            minHeap.Enqueue(number, frequency);

            // Heap'te yalnızca en sık k elemanı tut.
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        var result = new int[k];

        // Küçük frekanslıdan çıkar; diziyi sondan doldurarak
        // sonucu yüksek frekanstan düşüğe yakın biçimde oluşturuyoruz.
        for (int i = k - 1; i >= 0; i--)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }


    // Min Heap: same complexity as TopKFrequentV3.
    // Time Complexity: O(n + m log k), where m is the number of unique values.
    // Space Complexity: O(m + k).
    public static int[] TopKFrequentV4(int[] nums, int k)
    {
        Dictionary<int, int> frequencies = new();

        foreach (int num in nums)
            frequencies[num] = frequencies.GetValueOrDefault(num) + 1;

        PriorityQueue<int, int> minHeap = new();

        foreach (var (num, priority) in frequencies)
        {
            minHeap.Enqueue(num, priority);

            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        int[] result = new int[k];

        for (int i = k - 1; i >= 0; i--)
            result[i] = minHeap.Dequeue();

        return result;

    }
}
