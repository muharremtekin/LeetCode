using System.Text;

namespace LeetCode75.TopInterview150.Solutions;

public sealed class ZigZagConversation
{
    // https://leetcode.com/problems/zigzag-conversion/description

    // Simülasyon yaklaşımı: Her satır için bir StringBuilder tutulur,
    // string üzerinde gezilirken her karakter ilgili satıra eklenir.
    // Time: O(n) | Space: O(n) — numRows adet StringBuilder allocate edilir.
    public static string Convert(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length) return s;

        var rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new StringBuilder();

        int currentRow = 0;
        bool goingDown = false;

        foreach (char c in s)
        {
            rows[currentRow].Append(c);
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;
            currentRow += goingDown ? 1 : -1;
        }

        return string.Concat(rows);
    }

    // Optimize edilmiş Span yaklaşımı: Matematiksel index hesabıyla
    // hangi karakterin nereye gideceği doğrudan bulunur.
    // string.Create ile output string'in belleğine doğrudan yazılır —
    // hiç ara buffer, hiç kopya yok.
    // Time: O(n) | Space: O(1) ekstra (yalnızca output string'in kendisi)
    public static string ConvertOptimized(string s, int numRows)
    {
        if (numRows == 1 || numRows >= s.Length) return s;

        int cycle = 2 * (numRows - 1);

        return string.Create(s.Length, (s, numRows, cycle), static (span, state) =>
        {
            var (src, rows, cyc) = state;
            ReadOnlySpan<char> input = src.AsSpan(); // kopyasız, doğrudan bellek görünümü
            int outIdx = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int j = 0; j + row < input.Length; j += cyc)
                {
                    // Her satırın "aşağı" karakteri
                    span[outIdx++] = input[j + row];

                    // Orta satırların "çapraz" karakteri
                    bool isMiddleRow = row != 0 && row != rows - 1;
                    int diagIdx = j + cyc - row;
                    if (isMiddleRow && diagIdx < input.Length)
                        span[outIdx++] = input[diagIdx];
                }
            }
        });
    }
}