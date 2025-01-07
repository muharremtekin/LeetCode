public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
}

public class TreeNode<T>
{
    public T Data { get; set; }
    public int Size { get; set; }
    public TreeNode<T> Parent { get; set; }
    public TreeNode<T> FisrtChild { get; set; }
    public TreeNode<T> NextSibling { get; set; }


}