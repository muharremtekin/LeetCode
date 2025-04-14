public class DeleteNodeInABST
{
    public static TreeNode DeleteNode(TreeNode root, int key)
    {
        // Base case: if the tree is empty
        if (root == null)
            return root;

        // First, find the node to be deleted
        if (key < root.val)
            // If the key is smaller than root's value, it must be in the left subtree.
            root.left = DeleteNode(root.left, key);
        else if (key > root.val)
            // If the key is larger than root's value, it must be in the right subtree.
            root.right = DeleteNode(root.right, key);

        else
        {
            // This is the node to be deleted.

            // Case 1: Node with only one child or no child.
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;

            // Case 2: Node with two children.
            // Get the in-order successor (smallest in the right subtree).
            TreeNode successor = GetSuccessor(root.right);
            // Copy the successor's value to this node.
            root.val = successor.val;
            // Delete the in-order successor.
            root.right = DeleteNode(root.right, successor.val);
        }
        return root;
    }

    // Helper method to find the in-order successor (minimum value node in the subtree)
    private static TreeNode GetSuccessor(TreeNode node)
    {
        TreeNode current = node;
        // Loop to find the leftmost leaf.
        while (current.left != null)
            current = current.left;
        return current;
    }
}