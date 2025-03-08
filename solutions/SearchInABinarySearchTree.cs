public class SearchInABinarySearchTree
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null) return root;

        if (root.val == val) return root;
        else if (root.val > val) return SearchBST(root.left, val);
        else return SearchBST(root.right, val);
    }
}