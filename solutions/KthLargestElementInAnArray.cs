

namespace LeetCode75.solutions;

/// <summary>
/// 215. Kth Largest Element in an Array
/// https://leetcode.com/problems/kth-largest-element-in-an-array/description/?envType=study-plan-v2&envId=leetcode-75
/// </summary>
public class KthLargestElementInAnArray
{
    // Given an integer array nums and an integer k, return the kth largest element in the array.
    // Note that it is the kth largest element in the sorted order, not the kth distinct element.
    // Can you solve it without sorting?
    public static int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> queue = new(new MaxHeapComparer());

        foreach (int num in nums)
            queue.Enqueue(num, num);

        for (int i = 0; i <= k; i++)
        {
            if (i == k)
            {
                return queue.Dequeue();
            }

        }


        return 0;
    }

    public class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}
