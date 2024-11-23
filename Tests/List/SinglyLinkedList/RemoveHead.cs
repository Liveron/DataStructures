using L.DataStructures.List;

namespace Tests.List.SinglyLinkedList;

public class RemoveHead
{
    [Fact]
    public void ShouldRemoveHeadNode()
    {
        var list = new SinglyLinkedList<int>([1, 2, 3]);

        list.RemoveHead();

        Assert.Equal(2, list.Head!.Value);
    }
}
