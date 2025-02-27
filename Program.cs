
using LeafSimilarTrees;

var root1 = TreeNode.CreateTree([3,5,1,6,7,4,2,null,null,null,null,null,null,9,11,null,null,8,10]);

var root2 = TreeNode.CreateTree([3,5,1,6,2,9,8,null,null,7,4]);

var reslt = LeafSimilarTrees.LeafSimilarTrees.LeafSimilar(root1,root2);

Console.WriteLine(reslt);