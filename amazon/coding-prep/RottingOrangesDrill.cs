// ─────────────────────────────────────────────────────────────
// ROTTING ORANGES  (mock drill — 2026-07-05)
//
// You're given an m x n grid where each cell can be:
//   0 = empty cell
//   1 = a fresh orange
//   2 = a rotten orange
//
// Every minute, any fresh orange that is 4-directionally adjacent
// (up/down/left/right) to a rotten orange becomes rotten.
//
// Return the minimum number of minutes that must elapse until no
// cell has a fresh orange. If this is impossible, return -1.
//
// Example:
//   grid = [[2,1,1],
//           [1,1,0],
//           [0,1,1]]
//   Answer: 4
//
//   grid = [[2,1,1],
//           [0,1,1],
//           [1,0,1]]
//   Answer: -1   (the bottom-left orange is never reached)
// ─────────────────────────────────────────────────────────────


public class RottingOrangesDrill
{
    public int OrangesRotting(int[][] grid)
    {
        // your solution here
        int m = grid.Length;
        int n = grid[0].Length;
        int freshCount = 0;
        int minute = 0;
        Queue<(int x, int y)> queue = new();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 2) queue.Enqueue((i, j));
                else if (grid[i][j] == 1) freshCount++;
            }
        }

        while (queue.Count > 0)
        {
            int batcSize = queue.Count;

            for (int i = 0; i < batcSize; i++)
            {
                // take a rotten orange 
                var current = queue.Dequeue();
                // check four dimension to find fresh ones

                // check left
                if (current.y - 1 >= 0)
                {
                    if (grid[current.x][current.y - 1] == 1)
                    {
                        grid[current.x][current.y - 1] = 2;
                        freshCount--;
                        queue.Enqueue((current.x, current.y - 1));
                    }
                }

                // check right
                if (current.y + 1 < n)
                {
                    if (grid[current.x][current.y + 1] == 1)
                    {
                        grid[current.x][current.y + 1] = 2;
                        freshCount--;
                        queue.Enqueue((current.x, current.y + 1));
                    }
                }

                // check for up
                if (current.x + 1 < m)
                {
                    if (grid[current.x + 1][current.y] == 1)
                    {
                        grid[current.x + 1][current.y] = 2;
                        freshCount--;
                        queue.Enqueue((current.x + 1, current.y));
                    }
                }


                // check for down
                if (current.x - 1 >= 0)
                {
                    if (grid[current.x - 1][current.y] == 1)
                    {
                        grid[current.x - 1][current.y] = 2;
                        freshCount--;
                        queue.Enqueue((current.x - 1, current.y));
                    }
                }

                // do theese steps for each dimension
                // if you find, make it rotten
                // add it to queue
                // decrease freshCount
            }

            if (queue.Count > 0)
                minute++;
        }

        return freshCount == 0 ? minute : -1;
        //   grid = [[2,1,1],
        //           [1,1,0],
        //           [0,1,1]]
        // frescount = 6
        // minutes = 0

        // current = (0,0), minutes = 1
        // left:  current.y - 1 = -1  →  guard (-1 >= 0) cant move left
        // right: current.y + 1 = 1   →  guard (1 < 3)?  we found 1 and rotted and queued it. fresCount = 5
        // up:    current.x + 1 = 1   →  guard (1 < 3)?  cant go up
        // down:  current.x - 1 = ??? →  guard (??? )?   found fresh and rotted and queued it. fresCount = 4

        // current = (0,1), minutes = 2
        // left:  current.y - 1 = -1  →  guard (-1 >= 0) couldnt found fresh
        // right: current.y + 1 = 1   →  guard (1 < 3)?  found fresh and rotted and queued it. fresCount = 3
        // up:    current.x + 1 = 1   →  guard (1 < 3)?  cant move up
        // down:  current.x - 1 = ??? →  guard (??? )?   found fresh and rotted and queued it. fresCount = 2
    }
}
