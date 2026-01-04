public sealed class SumRootToLeafNumbers
{
    public static int SumNumbers(TreeNode root)
    {
        List<int> paths = new();

        if (root.left is null && root.right is null) return root.val;

        DFS(root.left, paths, root.val);
        DFS(root.right, paths, root.val);

        return paths.Sum();
    }
    private static void DFS(TreeNode node, List<int> paths, int currentNum)
    {
        if (node is null) return;

        currentNum = int.Parse($"{currentNum}{node.val}");

        if (node.left is null && node.right is null) // leaf mi kontrol et
        {
            paths.Add(currentNum);
            return;
        }

        DFS(node.left, paths, currentNum);
        DFS(node.right, paths, currentNum);

    }
}