public class NumberOfProvinces
{
    public static int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length; // Şehir sayısı
        bool[] visited = new bool[n]; // Ziyaret edilen şehirleri tutar
        int provinces = 0; // Eyalet sayacı

        // Tüm şehirleri kontrol et
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            { // Eğer şehir ziyaret edilmemişse
                DFS(i, isConnected, visited); // Bu eyaleti keşfet
                provinces++; // Yeni bir eyalet bulduk
            }
        }

        return provinces; // Toplam eyalet sayısını döndür
    }

    private static void DFS(int city, int[][] isConnected, bool[] visited)
    {
        visited[city] = true; // Şehir ziyaret edildi
        // Bu şehirle bağlantılı tüm şehirleri kontrol et
        for (int j = 0; j < isConnected.Length; j++)
        {
            if (isConnected[city][j] == 1 && !visited[j])
            {
                DFS(j, isConnected, visited); // Bağlantılı şehirleri ziyaret et
            }
        }
    }
}