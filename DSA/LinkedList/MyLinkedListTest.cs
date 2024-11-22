using System;
using Xunit;

public class MyLinkedListTest
{

    public void Append_ToEmptyList_ShouldSetHead()
    {
        // Arrange
        var list = new MyLinkedList<string>();

        // Act
        list.Append("first");

        // Assert
        Assert.NotNull(list.Head);
        Assert.Equal("first", list.Head.Value);
    }


    public void Append_ToNonEmptyList_ShouldAddToEnd()
    {
        // Arrange
        var list = new MyLinkedList<string>();
        list.Append("first");

        // Act
        list.Append("second");

        // Assert
        Assert.NotNull(list.Head);
        Assert.Equal("first", list.Head.Value);
        Assert.NotNull(list.Head.Next);
        Assert.Equal("second", list.Head.Next.Value);
    }


    public void Append_MultipleItems_ShouldMaintainOrder()
    {
        // Arrange
        var list = new MyLinkedList<string>();
        list.Append("first");
        list.Append("second");
        list.Append("third");

        // Act
        var node = list.Head;
        var values = new[] { "first", "second", "third" };
        int index = 0;

        // Assert
        while (node != null)
        {
            Assert.Equal(values[index], node.Value);
            node = node.Next;
            index++;
        }
    }
}