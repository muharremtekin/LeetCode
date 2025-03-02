using tree;

public class LowestCommonAncestorOfABinaryTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root is null || root == p || root == q) return root;

        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if(left != null && right != null) return root;

        if(left is null) return right;
        else return left;
    }

}
