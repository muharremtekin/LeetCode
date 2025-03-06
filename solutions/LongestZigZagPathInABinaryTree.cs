public class LongestZigZagPathInABinaryTree
{

    public int LongestZigZag(TreeNode root)
    {
        if (root is null) return 0;
        if (root.right is null && root.left is null) return 0;

        int maxL = DFS(root.left, true, 0);
        int maxR = DFS(root.right, false, 0);

        return maxL > maxR ? maxL : maxR;
    }

    private int DFS(TreeNode node, bool isLeft, int count)
    {
        if (node is null) return count;

        count++;
        int maxL = 0;
        int maxR = 0;
        if (isLeft)
        {
            maxR = DFS(node.right, false, count);
            maxL = DFS(node.left, true, 0);
        }
        else
        {
            maxL = DFS(node.left, true, count);
            maxR = DFS(node.right, false, 0);
        }

        return maxL > maxR ? maxL : maxR;
    }
}