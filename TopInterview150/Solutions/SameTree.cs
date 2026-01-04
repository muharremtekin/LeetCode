public sealed class SameTree
{
    // https://leetcode.com/problems/same-tree/description/
    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p is null && q is null)
            return true;

        if (p is null || q is null)
            return false;

        if (p.val != q.val)
            return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}