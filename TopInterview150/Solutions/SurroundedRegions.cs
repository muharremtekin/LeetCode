public sealed class SurroundedRegions
{
    // https://leetcode.com/problems/surrounded-regions
    // Not: kendim çözemedim bunu :(
    public void Solve(char[][] board)
    {
        // Strateji:
        // 1. Kenarlardan başlayarak erişilebilen O'ları geçici olarak 'T' ile işaretle
        // 2. Kalan O'lar çevrelenmiştir -> X'e çevir
        // 3. T'leri tekrar O'ya çevir (bunlar güvendeydi)

        int rows = board.Length;
        int cols = board[0].Length;

        // Adım 1: Kenarlardan DFS başlat
        // Sol ve sağ kenarlar
        for (int i = 0; i < rows; i++)
        {
            if (board[i][0] == 'O')
                MarkSafe(board, i, 0);
            if (board[i][cols - 1] == 'O')
                MarkSafe(board, i, cols - 1);
        }

        // Üst ve alt kenarlar
        for (int j = 0; j < cols; j++)
        {
            if (board[0][j] == 'O')
                MarkSafe(board, 0, j);
            if (board[rows - 1][j] == 'O')
                MarkSafe(board, rows - 1, j);
        }

        // Adım 2 ve 3: Board'u güncelle
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i][j] == 'O')
                    board[i][j] = 'X';  // Çevrelenmiş O -> X
                else if (board[i][j] == 'T')
                    board[i][j] = 'O';  // Güvenli T -> O
            }
        }
    }

    private static void MarkSafe(char[][] board, int row, int col)
    {
        // Sınır kontrolü
        if (row < 0 || row >= board.Length ||
            col < 0 || col >= board[0].Length ||
            board[row][col] != 'O')
            return;

        // Bu O güvende, T ile işaretle
        board[row][col] = 'T';

        // 4 yöne DFS
        MarkSafe(board, row + 1, col);  // aşağı
        MarkSafe(board, row - 1, col);  // yukarı
        MarkSafe(board, row, col + 1);  // sağ
        MarkSafe(board, row, col - 1);  // sol
    }
}