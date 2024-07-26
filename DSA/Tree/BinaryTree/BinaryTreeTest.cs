// using NUnit.Framework;

// [Test]
// public void InOrder_ReturnsEmptyList_WhenRootIsNull()
// {
//     // Arrange
//     BinaryTree<int> binaryTree = new BinaryTree<int>();

//     // Act
//     List<Node<int>> result = binaryTree.InOrder(null);

//     // Assert
//     Assert.IsEmpty(result);
// }

// [Test]
// public void InOrder_ReturnsNodesInOrder_WhenRootIsNotNull()
// {
//     // Arrange
//     BinaryTree<int> binaryTree = new BinaryTree<int>();
//     Node<int> root = new Node<int>(5);
//     Node<int> left = new Node<int>(3);
//     Node<int> right = new Node<int>(7);
//     root.Left = left;
//     root.Right = right;

//     // Act
//     List<Node<int>> result = binaryTree.InOrder(root);

//     // Assert
//     Assert.AreEqual(3, result.Count);
//     Assert.AreEqual(left, result[0]);
//     Assert.AreEqual(root, result[1]);
//     Assert.AreEqual(right, result[2]);
// }