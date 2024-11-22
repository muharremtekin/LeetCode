public class OnlineAssesmentDemoQuestionTwo
{

    // DFS Fonksiyonu
    static void DFS(int[,] matrix, int person, bool[] visited)
    {
        // Bu kişiyi ziyaret ettiğimizi işaretleyelim
        visited[person] = true;

        // Bu kişinin diğer kişilerle olan ilişkilerini kontrol edelim
        for (int other = 0; other < matrix.GetLength(1); other++)
        {
            // Eğer person ile other arasında bir bağlantı varsa (matrix[person, other] == 1)
            // ve other henüz ziyaret edilmediyse, DFS ile derinlemesine git
            if (matrix[person, other] == 1 && !visited[other])
            {
                DFS(matrix, other, visited);
            }
        }
    }

    // Grupların sayısını bulan ana fonksiyon
    public static int CountGroups(int[,] matrix)
    {
        int n = matrix.GetLength(0);  // Matrisin satır sayısı, yani kişi sayısı
        bool[] visited = new bool[n]; // Ziyaret edilen kişileri tutmak için dizi
        int groupCount = 0;           // Grup sayacı

        // Her kişiyi ziyaret etmeyi deniyoruz
        for (int person = 0; person < n; person++)
        {
            // Eğer bu kişi ziyaret edilmemişse, yeni bir gruba aittir
            if (!visited[person])
            {
                // DFS ile bu kişi ve ona bağlı olan tüm kişileri ziyaret edelim
                DFS(matrix, person, visited);
                groupCount++; // Yeni bir grup bulduk, sayacı artır
            }
        }

        return groupCount; // Toplam grup sayısını döndür
    }

    public void TestArray(bool[] bools)
    {
        for (int i = 0; i < bools.Length; i++)
        {
            bools[i] = false;
        }
    }
}

class QuestionTwoSelfStudy
{
    public static int CountGroups(int[,] matrix)
    {

        int n = matrix.GetLength(0);
        bool[] visited = new bool[n];
        int groupCount = 0;

        for (int person = 0; person < n; person++)
        {
            if (!visited[person])
            {
                DFS(matrix, visited, person);
                groupCount++;
            }
        }

        return groupCount;
    }

    static void DFS(int[,] matrix, bool[] visited, int person)
    {
        visited[person] = true;
        for (int other = 0; other < matrix.GetLength(1); other++)
        {
            // Eğer person ile other arasında bir bağlantı varsa (matrix[person, other] == 1)
            // ve other henüz ziyaret edilmediyse, DFS ile derinlemesine git
            if (matrix[person, other] == 1 && !visited[other])
            {
                DFS(matrix, visited, other);
            }
        }
    }

}