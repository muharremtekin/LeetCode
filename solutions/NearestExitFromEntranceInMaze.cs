public sealed class NearestExitFromEntranceInMaze
{
    public static int NearestExit(char[][] maze, int[] entrance)
    {
        Queue<(int x, int y, int step)> queue = new();

        int m = maze.Length;
        int n = maze[0].Length;


        bool[,] visited = new bool[m, n];

        queue.Enqueue((x: entrance[1], y: entrance[0], 0));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (visited[current.y, current.x]) continue;

            visited[current.y, current.x] = true;

            // is it an exit point
            // should be empty and at the border
            // and it shouldn't at the step zero "0"

            if (current.step != 0 && maze[current.y][current.x] == '.' &&
                (current.x == n - 1 || current.x == 0 || current.y == 0 || current.y == m - 1))
                return current.step;

            // up = y - 1;
            if (current.y - 1 >= 0 && maze[current.y - 1][current.x] == '.')
                queue.Enqueue((current.x, current.y - 1, current.step + 1));

            // left = x - 1
            if (current.x - 1 >= 0 && maze[current.y][current.x - 1] == '.')
                queue.Enqueue((current.x - 1, current.y, current.step + 1));

            // down = y + 1
            if (current.y + 1 <= m - 1 && maze[current.y + 1][current.x] == '.')
                queue.Enqueue((current.x, current.y + 1, current.step + 1));

            // right = x + 1
            if (current.x + 1 <= n - 1 && maze[current.y][current.x + 1] == '.')
                queue.Enqueue((current.x + 1, current.y, current.step + 1));

        }

        return -1;
    }


    public static int NearestExitRefactored(char[][] maze, int[] entrance)
    {
        Queue<(int x, int y, int step)> queue = new();
        int m = maze.Length;
        int n = maze[0].Length;
        bool[,] visited = new bool[m, n];

        int startRow = entrance[0];
        int startCol = entrance[1];

        queue.Enqueue((startCol, startRow, 0));

        visited[startRow, startCol] = true;

        int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        while (queue.Count > 0)
        {
            (int x, int y, int step) current = queue.Dequeue();

            bool isAtBorder = current.x == 0 || current.x == n - 1 || current.y == 0 || current.y == m - 1;
            bool isStartCell = current.y == startRow && current.x == startCol;

            if (isAtBorder && !isStartCell)
                return current.step;


            foreach (var dir in directions)
            {
                int nextY = current.y + dir[0];
                int nextX = current.x + dir[1];

                if (nextY >= 0 && nextY < m && nextX >= 0 && nextX < n &&
                    maze[nextY][nextX] == '.' && !visited[nextY, nextX])
                {
                    visited[nextY, nextX] = true;
                    queue.Enqueue((nextX, nextY, current.step + 1));
                }
            }
        }
        return -1;
    }

}