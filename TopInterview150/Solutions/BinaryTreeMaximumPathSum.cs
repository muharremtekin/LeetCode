public sealed class BinaryTreeMaximumPathSum
{
    // https://leetcode.com/problems/binary-tree-maximum-path-sum
    public int MaxPathSum(TreeNode root)
    {
        int maximum = int.MinValue;

        DFS(root, ref maximum);

        return maximum;
    }

    private int DFS(TreeNode node, ref int maximum)
    {
        if (node is null) return 0;

        int left = Math.Max(0, DFS(node.left, ref maximum));
        int right = Math.Max(0, DFS(node.right, ref maximum));

        int pathSum = left + node.val + right;

        maximum = Math.Max(pathSum, maximum);

        return node.val + Math.Max(left, right);
    }
}