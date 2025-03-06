public class PathSumIII
{
    public int PathSum(TreeNode root, int targetSum)
    {
        // Prefix sum sözlüğü: toplam değeri ve bu toplamın kaç kere oluştuğunu tutar.
        // Başlangıçta, toplam 0'ın 1 kere oluştuğunu belirtiriz.
        var prefix = new Dictionary<long, int>();
        prefix[0] = 1;
        return DFS(root, 0, targetSum, prefix);
    }

    private int DFS(TreeNode node, long currentSum, int targetSum, Dictionary<long, int> prefix)
    {
        if (node == null)
            return 0;

        // Mevcut düğümün değerini ekleyerek toplamı güncelle
        currentSum += node.val;

        // currentSum - targetSum'ı daha önce elde etmişsek, bu kadar yol targetSum değerine ulaşmış demektir.
        int count = prefix.ContainsKey(currentSum - targetSum) ? prefix[currentSum - targetSum] : 0;

        // Şu anki currentSum'u sözlüğe ekle veya sayısını artır
        if (prefix.ContainsKey(currentSum))
            prefix[currentSum]++;
        else
            prefix[currentSum] = 1;

        // Sol ve sağ alt ağaçlarda DFS yaparak yolu ara
        count += DFS(node.left, currentSum, targetSum, prefix);
        count += DFS(node.right, currentSum, targetSum, prefix);

        // Backtracking: Bu düğümün katkısını sözlükten geri al
        prefix[currentSum]--;

        return count;
    }
}