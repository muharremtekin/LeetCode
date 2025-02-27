namespace LeafSimilarTrees;

public class LeafSimilarTrees
{
    // 872. Leaf-Similar Trees
    // Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.

    // For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
    // Two binary trees are considered leaf-similar if their leaf value sequence is the same.
    // Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.


    // Example 1:
    // Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
    // Output: true

    // Example 2:
    // Input: root1 = [1,2,3], root2 = [1,3,2]
    // Output: false


    // Constraints:
    // The number of nodes in each tree will be in the range [1, 200].
    // Both of the given trees will have values in the range [0, 200].


    //Definition for a binary tree node.

    // [3, 5, 1, 6, 2, 9, 8, null, null, 7, 4]

    // [3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8]

    public static bool LeafSimilar(TreeNode root1, TreeNode root2)
    {

        var list1 = new List<int>();
        var list2 = new List<int>();

        DFS(root1, list1);
        DFS(root2, list2);

        if(list1.Count != list2.Count) return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }

    static void DFS(TreeNode node, List<int> list)
    {
        if (node is null) return;

        if (node.left is null && node.right is null)
            list.Add(node.val);

        DFS(node.left, list);
        DFS(node.right, list);
    }
}

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

    public static TreeNode CreateTree(int?[] arr)
    {
        if (arr == null || arr.Length == 0 || arr[0] == null)
            return null;

        TreeNode root = new TreeNode(arr[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < arr.Length)
        {
            TreeNode current = queue.Dequeue();

            // Sol çocuk
            if (i < arr.Length && arr[i] != null)
            {
                current.left = new TreeNode(arr[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Sağ çocuk
            if (i < arr.Length && arr[i] != null)
            {
                current.right = new TreeNode(arr[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }
}