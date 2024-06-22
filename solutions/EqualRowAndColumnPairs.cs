using System.Collections;

public class EqualRowAndColumnPairs
{
    // Input: grid = 
    // [
    //     [3,1,2,2],
    //     [1,4,4,5],
    //     [2,4,2,2],
    //     [2,4,2,2]
    // ]
    // Output: 3
    // Explanation: There are 3 equal row and column pairs:
    // - (Row 0, Column 0): [3,1,2,2]
    // - (Row 2, Column 2): [2,4,2,2]
    // - (Row 3, Column 2): [2,4,2,2]

    // eğer 
    public static int Solution(int[][] grid)
    {
        int n = grid.Length;
        var rowCount = new Dictionary<int, int>();
        
        // Satırları hash kodları ile sakla
        for (int i = 0; i < n; i++) {
            var row = grid[i];
            int rowHash = row.GetHashCode();
            if (!rowCount.ContainsKey(rowHash)) {
                rowCount[rowHash] = 0;
            }
            rowCount[rowHash]++;
        }
        
        int count = 0;
        
        // Sütunları kontrol et ve satırlarla eşleştir
        for (int j = 0; j < n; j++) {
            var col = new int[n];
            for (int i = 0; i < n; i++) {
                col[i] = grid[i][j];
            }
            int colHash = col.GetHashCode();
            if (rowCount.ContainsKey(colHash)) {
                count += rowCount[colHash];
            }
        }
        
        return count;
    }
}