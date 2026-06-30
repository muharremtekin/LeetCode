/*
======================================================================
 TOP K FREQUENT ELEMENTS  —  Heap (priority queue)
======================================================================

PROBLEM
  Given int[] nums and an integer k, return the k most frequent
  elements. You may return the answer in any order.

  Example: nums = [1,1,1,2,2,3], k = 2  ->  [1,2]
           nums = [1],            k = 1  ->  [1]

  Follow-up: your algorithm's time complexity must be better than
  O(n log n), where n is the array's size.

----------------------------------------------------------------------
 YOUR TURN  (mock interview — interviewer is "Marco")
   1. Clarifying questions first (out loud).
   2. State the approach + complexity BEFORE coding.
      (Think about why a heap of size k beats sorting everything.)
   3. Implement below.
   4. Hand-trace with a per-iteration table (real values, not symbols).
----------------------------------------------------------------------
*/
public class Heap
{
  public int[] TopKFrequent(int[] nums, int k)
  {
    // i define to store distinct elements and their frequencies
    Dictionary<int, int> frequencies = new();

    // here i add them to dictionary and increasing their freq
    foreach (int number in nums)
      frequencies[number] = frequencies.GetValueOrDefault(number) + 1;

    PriorityQueue<int, int> priorityQueue = new();

    // i read each num and freq
    foreach (var (num, freq) in frequencies)
    {
      // i add them to queue (it's a min heap)
      priorityQueue.Enqueue(num, freq);

      // i cut out min freqs here cuz 
      // first element has least freq value cuz its a min heap
      // and i guarantee we only have top k freq eleement here 

      while (priorityQueue.Count > k)
        priorityQueue.Dequeue();
    }

    // i just create result arr thats it
    int[] result = new int[k];

    for (int i = 0; i < k; i++)
      result[i] = priorityQueue.Dequeue();

    return result;

    // trace:
    // nums = [1,1,1,2,2,3], k = 2

    // after first for loop 
    // we have dictionary like that: 
    // [
    //   [1-3]
    //   [2-2]
    //   [3-1]
    // ]

    // in foreach loop
    // iteration 1: queue [[1-3]]
    // iteration 2: queue [[2-2],[1-3]]
    // iteration 3: queue [[3-1],[2-2],[1-3]] we remove [3-1] from queue
    // final queue: queue [[2-2],[1-3]]

    // we create and retun result array
  }
}
