using System;

namespace LeetCode75.solutions;

// 994. Rotting Oranges
// https://leetcode.com/problems/rotting-oranges/description/?envType=study-plan-v2&envId=leetcode-75
public class RottingOranges
{
    // 0 representing an empty cell,
    // 1 representing a fresh orange, or
    // 2 representing a rotten orange.

    // Constraints:
    // m == grid.length
    // n == grid[i].length
    // 1 <= m, n <= 10
    // grid[i][j] is 0, 1, or 2.

    // Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
    // Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
    private static readonly int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    public static int OrangesRotting(int[][] grid)
    {
        Queue<(int x, int y)> queue = new();

        int m = grid.Length;
        int n = grid[0].Length;

        bool[,] visited = new bool[m, n];

        int freshCount = 0;

        // search rotten one

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int val = grid[i][j];
                if (val is 1)
                {
                    freshCount++;
                }
                else if (val is 2)
                {
                    queue.Enqueue((x: j, y: i));
                }
            }
        }

        int minute = 0;
        while (queue.Count > 0)
        {
            int batchSize = queue.Count;

            for (int i = 0; i < batchSize; i++)
            {
                var current = queue.Dequeue();

                if (visited[current.y, current.x]) continue;

                visited[current.y, current.x] = true;

                foreach (int[] dir in directions)
                {
                    int nextY = current.y + dir[0];
                    int nextX = current.x + dir[1];

                    if (nextY >= 0
                        && nextY < m
                        && nextX >= 0
                        && nextX < n
                        && visited[nextY, nextX] == false
                        && grid[nextY][nextX] is 1)
                    {
                        freshCount--;
                        grid[nextY][nextX] = 2;
                        queue.Enqueue((x: nextX, y: nextY));
                    }
                }

            }
            if (queue.Count > 0)
                minute++;
        }

        return freshCount == 0 ? minute : -1;
    }
}
