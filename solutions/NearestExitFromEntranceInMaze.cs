public sealed class NearestExitFromEntranceInMaze
{
    public static int NearestExit(char[][] maze, int[] entrance)
    {
        Queue<(int x, int y, int step)> queue = new();

        int m = maze.Length; ; // satır/line
        int n = maze[0].Length; // sütun/column


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

            if (current.step != 0 && maze[current.y][current.x] == '.' && (current.x == n - 1 || current.x == 0))
                return current.step;

            if (current.step != 0 && maze[current.y][current.x] == '.' && (current.y == 0 || current.y == m - 1))
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

}