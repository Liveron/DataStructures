using L.DataStructures.List;

namespace Tests.List.SinglyLinkedList;

public class RemoveAfter
{
    [Fact]
    public void ShouldRemoveNodeAfterGivenNode()
    {
        var list = new SinglyLinkedList<int>([1, 2, 3]);
        var node = list.Head;

        list.RemoveAfter(node!);

        Assert.Equal(3, list.Head!.Next!.Value);
    }
}
