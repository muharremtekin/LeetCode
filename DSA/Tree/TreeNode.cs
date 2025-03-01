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

    public static TreeNode CreateBinaryTree(int[] nums)
    {
        if (nums is null || !nums.Any()) return new TreeNode();

        var head = new TreeNode(val: nums[0]);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(head);

        for (int i = 1; i < nums.Length; i += 2)
        {
            var current = queue.Dequeue();

            if (i < nums.Length)
            {
                current.left = new TreeNode(nums[i]);
                queue.Enqueue(current.left);
            }

            if (i + 1 < nums.Length)
            {
                current.right = new TreeNode(nums[i + 1]);
                queue.Enqueue(current.right);
            }
        }

        return head;
    }
}