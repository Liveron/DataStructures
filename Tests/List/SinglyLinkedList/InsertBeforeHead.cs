using L.DataStructures.List;

namespace Tests.List.SinglyLinkedList;

public class InsertBeforeHead
{
    [Fact]
    public void Node_ShouldUpdateHead()
    {
        var list = new SinglyLinkedList<int>();
        var node = new SinglyLinkedListNode<int>(0);

        list.InsertBeforeHead(node);

        Assert.Equal(0, list.Head.Value);
    }

    [Fact]
    public void Value_ShouldUpdateHead()
    {
        var list = new SinglyLinkedList<int>();

        list.InsertBeforeHead(0);

        Assert.Equal(0, list.Head.Value);
    }
}
