public class MaximumLevelSumOfABinaryTree
{
    public int MaxLevelSum(TreeNode root)
    {
        if (root is null) return 0;
        if (root.left is null && root.right is null) return root.val;

        Queue<TreeNode> queue = new();

        int maxSum = root.val;
        int maxLevel = 1;
        int level = 1;

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            int currrentSum = 0;

            for (int i = 0; i < lvlSize; i++)
            {
                var current = queue.Dequeue();

                currrentSum += current.val;

                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }

            if (currrentSum > maxSum)
            {
                maxSum = currrentSum;
                maxLevel = level;
            }
            level++;
        }

        return maxLevel;
    }
}