public class BinaryTreeRightSideView
{
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> result = new();
        if (root is null) return result;
        if (root.right is null && root.left is null) 
        {
            result.Add(root.val);
            return result;
        }

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        int level = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            Console.WriteLine($"Level: {level}");

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode current = queue.Dequeue();
                Console.Write(current.val + " ");

                if(i==0)
                    result.Add(current.val);

                if (current.right != null)
                    queue.Enqueue(current.right);

                if (current.left != null)
                    queue.Enqueue(current.left);
            }

            Console.WriteLine();
            level++;
        }

        return result;
    }
}