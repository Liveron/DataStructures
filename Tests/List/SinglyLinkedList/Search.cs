using L.DataStructures.List;

namespace Tests.List.SinglyLinkedList;

public class Search
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 3, 2)]
    public void ExistingValue_ShouldReturnNode(int[] initialValues, int find, int position)
    {
        var list = new SinglyLinkedList<int>(initialValues);

        SinglyLinkedListNode<int> nodeToFind = list.ElementAt(position);

        SinglyLinkedListNode<int>? found = list.Search(find);

        Assert.Equal(nodeToFind, found);
    }

    [Fact]
    public void NotExistingValue_ShouldReturnNull()
    {
        var list = new SinglyLinkedList<int>([1, 2, 3]);

        var result = list.Search(4);

        Assert.Null(result);
    }
}
