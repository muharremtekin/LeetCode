public class KeysAndRooms
{
    public static bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        int n = rooms.Count;          // Toplam oda sayısı
        bool[] visited = new bool[n]; // Ziyaret edilen odaları tutar

        // Oda 0'dan DFS ile başla
        DFS(0, rooms, visited);

        // Tüm odalar ziyaret edildi mi kontrol et
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])          // Eğer bir oda ziyaret edilmediyse
                return false;         // Tüm odalara gidemedik
        }
        return true;                  // Tüm odalar ziyaret edildi
    }

    private static void DFS(int room, IList<IList<int>> rooms, bool[] visited)
    {
        visited[room] = true;         // Bu odayı ziyaret ettik

        // Odadaki tüm anahtarları kontrol et
        foreach (int key in rooms[room])
        {
            if (!visited[key])        // Eğer anahtar başka bir odayı açıyorsa ve o oda ziyaret edilmediyse
            {
                DFS(key, rooms, visited); // O odaya git
            }
        }
    }
}
