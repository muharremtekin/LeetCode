// You are given an array of CPU tasks, each labeled with a letter from A to Z, and a number n. 
// Each CPU interval can be idle or allow the completion of one task. Tasks can be completed in any order, 
//but there's a constraint: there has to be a gap of at least n intervals between two tasks with the same label.

// Return the minimum number of CPU intervals required to complete all tasks.


// Example 1:
// Input: tasks = ["A","A","A","B","B","B"], n = 2
// Output: 8
// Explanation: A possible sequence is: A -> B -> idle -> A -> B -> idle -> A -> B.
// After completing task A, you must wait two intervals before doing A again. 
// The same applies to task B. In the 3rd interval, neither A nor B can be done, 
// so you idle. By the 4th interval, you can do A again as 2 intervals have passed.

// Example 2:
// Input: tasks = ["A","C","A","B","D","B"], n = 1
// Output: 6
// Explanation: A possible sequence is: A -> B -> C -> D -> A -> B.
// With a cooling interval of 1, you can repeat a task after just one other task.

// Example 3:
// Input: tasks = ["A","A","A", "B","B","B"], n = 3
// Output: 10
// Explanation: A possible sequence is: A -> B -> idle -> idle -> A -> B -> idle -> idle -> A -> B.
// There are only two types of tasks, A and B, which need to be separated by 3 intervals. This leads to idling twice between repetitions of these tasks.

// Constraints:

// 1 <= tasks.length <= 104
// tasks[i] is an uppercase English letter.
// 0 <= n <= 100


public class TaskScheduler
{
    public static int LeastInterval(char[] tasks, int n)
    {
        // Size verilen görevler bir dizi harften oluşuyor(A'dan Z'ye).
        // Her görev 1 birim zaman alıyor.
        // Aynı türden iki görev arasında en az 'n' birim zaman olmalı.
        // Amacımız, tüm görevleri tamamlamak için gereken minimum zaman birimini bulmak(idle süreleri dahil).

        int[] frequency = new int[26];

        foreach (char ch in tasks)
        {
            var i = ch - 'A';
            frequency[i]++;
        }

        // priority queue
        PriorityQueue<int, int> priorityQueue = new();
        // greedy algorithm
        var a = tasks.Length + n;
        return 0;
    }

    // Greedy / matematiksel çözüm.
    // En sık geçen görevler, aralarında n boşluk olacak şekilde zaman çizelgesinin
    // iskeletini oluşturur. Diğer görevler bu boşlukları doldurur.
    // Time: O(tasks.Length) | Space: O(1) — görev türü A-Z ile sınırlı.
    public static int LeastIntervalV2(char[] tasks, int n)
    {
        if (tasks.Length == 0)
            return 0;

        int[] frequencies = new int[26];

        foreach (char task in tasks)
            frequencies[task - 'A']++;

        int maxFrequency = 0;
        int maxFrequencyCount = 0;

        foreach (int frequency in frequencies)
        {
            if (frequency > maxFrequency)
            {
                maxFrequency = frequency;
                maxFrequencyCount = 1;
            }
            else if (frequency == maxFrequency)
            {
                maxFrequencyCount++;
            }
        }

        // (maxFrequency - 1) adet tam blok vardır. Her blokta en sık görev ile
        // bir sonraki aynı görev arasında n + 1 zaman aralığı bulunur.
        int minimumFrameLength = (maxFrequency - 1) * (n + 1) + maxFrequencyCount;

        // Yeterli farklı görev varsa idle zamanı oluşmaz; toplam süre görev sayısıdır.
        return Math.Max(tasks.Length, minimumFrameLength);
    }
}
