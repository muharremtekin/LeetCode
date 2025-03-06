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

    public static TreeNode CreateBinaryTree(int?[] nums)
    {
        if (nums is null || !nums.Any()) return new TreeNode();

        var head = new TreeNode(val: nums[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(head);

        for (int i = 1; i < nums.Length; i += 2)
        {
            var current = queue.Dequeue();

            if (i < nums.Length && nums[i].HasValue)
            {
                current.left = new TreeNode(nums[i].Value);
                queue.Enqueue(current.left);
            }

            if (i + 1 < nums.Length && nums[i + 1].HasValue)
            {
                current.right = new TreeNode(nums[i + 1].Value);
                queue.Enqueue(current.right);
            }
        }

        return head;
    }
}