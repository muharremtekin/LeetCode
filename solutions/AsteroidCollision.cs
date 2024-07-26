public class AsteroidCollision
{
    // Example 1:
    // Input: asteroids = [5,10,-5]
    // Output: [5,10]
    // Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.

    // Example 2:
    // Input: asteroids = [8,-8]
    // Output: []
    // Explanation: The 8 and -8 collide exploding each other.

    // Example 3:
    // Input: asteroids = [10,2,-5]
    // Output: [10]
    // Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide resulting in 10.

    // input
    // [-2,-1,1,2]
    // Output
    // [1]
    // Expected
    // [-2,-1,1,2]

    public static int[] Solution(int[] asteroids)
    {
        Stack<int> stack = new();

        foreach (var asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
            }
            else
            {
                while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroid))
                {
                    stack.Pop();
                }
                if (stack.Count > 0 && stack.Peek() == Math.Abs(asteroid))
                {
                    stack.Pop();
                }
                else if (stack.Count == 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
            }
        }

        int[] result = new int[stack.Count];
        for (int i = stack.Count - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }

        return result;
    }
}