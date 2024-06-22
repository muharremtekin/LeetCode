using System.Collections;

public class UniqueNumberOfOccurrences
{
    // Zaman Karmaşıklığı: O(n * k), en kötü durumda O(n^2)
    // Uzay Karmaşıklığı: O(k), en kötü durumda O(n)
    // Not: O(k)'daki k = arr dizisinden kalandır.
    public static bool Solution(int[] arr)
    {
        // Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
        // Output: true

        // Input: arr = [1,2,2,1,1,3]
        // Output: true

        // Input: arr = [1,2,2,1,1,3]
        // Output: true
        // Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

        HashSet<int> numbers = arr.ToHashSet();

        HashSet<int> counts = new();

        foreach (int num in numbers)
        {
            int count = arr.Where(a => a == num).Count();
            bool isAdded = counts.Add(count);
            if (!isAdded)
                return false;
        }

        return true;
    }
}