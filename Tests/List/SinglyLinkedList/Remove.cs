using L.DataStructures.List;

namespace Tests.List.SinglyLinkedList;

public class Remove
{
    [Fact]
    public void ShouldRemoveNodeWithValue()
    {
        var list = new SinglyLinkedList<int>([1, 2, 3]);

        list.Remove(2);

        Assert.Null(list.Search(2));
    }

    [Fact]
    public void ShoulNotRemoveAnyIfValueNotFound()
    {
        var list = new SinglyLinkedList<int>([1, 2, 3]);

        list.Remove(4);

        var values = list.Select(x => x.Value);

        Assert.Equal([1, 2, 3], values);
    }
}
