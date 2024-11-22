public class AmazonFresh
{
    // Yön vektörleri: sağ, sol, yukarı, aşağı
    private static int[] rowDir = new int[] { 0, 0, 1, -1 };
    private static int[] colDir = new int[] { 1, -1, 0, 0 };

    public static int MinDistanceToDeliver(List<List<int>> area)
    {
        int rows = area.Count;
        int cols = area[0].Count;

        // Kuyruk, BFS için kullanacağımız yapı
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        bool[,] visited = new bool[rows, cols];

        // Başlangıç noktasını kuyruk yapısına ekle
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 0)); // (row, col, distance)
        visited[0, 0] = true;

        // BFS Başlat
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int currRow = current.Item1;
            int currCol = current.Item2;
            int currDistance = current.Item3;

            // Hedef noktayı bulduğumuzda döndür
            if (area[currRow][currCol] == 9)
            {
                return currDistance;
            }

            // 4 yön için döngü
            for (int i = 0; i < 4; i++)
            {
                int newRow = currRow + rowDir[i];
                int newCol = currCol + colDir[i];

                // Yeni konum geçerli mi? Grid'in dışına çıkmamalı, ziyaret edilmemiş olmalı, ve yol olmalı (1 veya 9)
                if (IsValid(newRow, newCol, rows, cols, area, visited))
                {
                    // Yeni konumu ziyaret ettik olarak işaretle ve kuyruğa ekle
                    visited[newRow, newCol] = true;
                    queue.Enqueue(new Tuple<int, int, int>(newRow, newCol, currDistance + 1));
                }
            }
        }

        // Eğer hedef noktaya ulaşılamadıysa -1 döndür
        return -1;
    }

    // Geçerli bir hücre olup olmadığını kontrol eden yardımcı fonksiyon
    private static bool IsValid(int row, int col, int rows, int cols, List<List<int>> area, bool[,] visited)
    {
        return row >= 0 && col >= 0 
                        && row < rows 
                        && col < cols 
                        && !visited[row, col] 
                        && (area[row][col] == 1 || area[row][col] == 9);
    }
}