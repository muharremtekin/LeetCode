
namespace LeetCode75.solutions;
// https://leetcode.com/problems/smallest-number-in-infinite-set/description/?envType=study-plan-v2&envId=leetcode-75

// You have a set which contains all positive integers [1, 2, 3, 4, 5, ...].
// Implement the SmallestInfiniteSet class:

// SmallestInfiniteSet() Initializes the SmallestInfiniteSet object to contain all positive integers.
// int popSmallest() Removes and returns the smallest integer contained in the infinite set.
// void addBack(int num) Adds a positive integer num back into the infinite set, if it is not already in the infinite set.
public class SmallestInfiniteSet
{
    private PriorityQueue<int, int> _priorityQueue;
    private HashSet<int> _set;
    private int _nextInt;

    public SmallestInfiniteSet()
    {
        _priorityQueue = new();
        _set = new();
        _nextInt = 1;
    }

    public int PopSmallest()
    {
        if (_priorityQueue.Count > 0 && _priorityQueue.Peek() < _nextInt)
        {
            int smallest = _priorityQueue.Dequeue();
            _set.Remove(smallest);
            return smallest;
        }
        if (_priorityQueue.Count > 0 && _priorityQueue.Peek() == _nextInt)
        {
            _priorityQueue.Dequeue();
            _set.Remove(_nextInt);
        }

        return _nextInt++;
    }

    public void AddBack(int num)
    {
        if (num < _nextInt && !_set.Contains(num))
        {
            _set.Add(num);
            _priorityQueue.Enqueue(num, num);
        }
    }

}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */