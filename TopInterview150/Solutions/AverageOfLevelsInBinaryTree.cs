public sealed class AverageOfLevelsInBinaryTree
{
    // https://leetcode.com/problems/average-of-levels-in-binary-tree
    public static IList<double> AverageOfLevels(TreeNode root)
    {
        Queue<TreeNode> queue = new([root]);
        List<double> avgValues = new();

        while (queue.Count > 0)
        {
            double lvlSum = 0;
            double lvlCount = queue.Count;
            for (int i = 0; i < lvlCount; i++)
            {
                TreeNode current = queue.Dequeue();

                lvlSum += current.val;

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }

            avgValues.Add(lvlSum / lvlCount);
        }

        return avgValues;
    }
}