public class MaxDepthOfBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    /// <summary>
    /// Calculates the maximum depth of a binary tree.
    /// </summary>
    /// <param name="root">The root node of the binary tree.</param>
    /// <returns>The maximum depth of the binary tree.</returns>
    public static int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);
        return Math.Max(leftDepth, rightDepth) + 1;
    }

}