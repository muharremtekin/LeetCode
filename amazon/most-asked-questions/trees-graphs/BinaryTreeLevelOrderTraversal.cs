public class BinaryTreeLevelOrderTraversal
{
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        // Input: root = [3,9,20,null,null,15,7]
        // Output: [[3],[9,20],[15,7]]
        IList<IList<int>> result = [[]];
        result.RemoveAt(0);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var lvlWeight = queue.Count;
            var lvlList = new List<int>();
            for (int i = 0; i < lvlWeight; i++)
            {
                var current = queue.Dequeue();
                lvlList.Add(current.val);

                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            result.Add(lvlList);
        }

        return result;
    }
}