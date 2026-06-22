
// var reuslt1 = NearestExitFromEntranceInMaze.NearestExit([['+', '+', '.', '+'], ['.', '.', '.', '+'], ['+', '+', '+', '.']], [1, 2]);

// Console.WriteLine(reuslt1);



// var reuslt2 = NearestExitFromEntranceInMaze.NearestExit([['+', '+', '+'], ['.', '.', '.'], ['+', '+', '+']], [1, 0]);

// Console.WriteLine(reuslt2);

// var reuslt3 = NearestExitFromEntranceInMaze.NearestExit([['.','+','+','+','+'],
//                                                          ['.','+','.','.','.'],
//                                                          ['.','+','.','+','.'],
//                                                          ['.','.','.','+','.'],
//                                                          ['+','+','+','+','.']],
//                                                          [0, 0]);

// Console.WriteLine(reuslt3);
using System.Text;


var root = TreeNode.CreateBinaryTree([3,9,20,null,null,15,7]);

var res = BinaryTreeLevelOrderTraversal.LevelOrder(root);
Console.WriteLine(res);