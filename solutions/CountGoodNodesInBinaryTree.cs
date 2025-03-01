public class CountGoodNodesInBinaryTree
{
    public static int GoodNodes(TreeNode root)
    {
        int goodCount = 0;

        DFSCount(root, root.val, ref goodCount);

        return goodCount;
    }

    static void DFSCount(TreeNode root, int max, ref int goodCount)
    {
        if (root is null) return;

        if (root.val >= max)
        {
            goodCount++;
            DFSCount(root.left, root.val, ref goodCount);
            DFSCount(root.right, root.val, ref goodCount);
        }
        else
        {
            DFSCount(root.left, max, ref goodCount);
            DFSCount(root.right, max, ref goodCount);
        }
    }
}



