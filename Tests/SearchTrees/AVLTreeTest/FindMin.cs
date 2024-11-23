using L.DataStructures.SearchTrees;

namespace Tests.SearchTrees.AVLTreeTest;

public class FindMin
{
    [Theory]
    [InlineData(new int[] { -1 }, -1)]
    [InlineData(new int[] { 1, 0,-1 }, -1)]
    [InlineData(new int[] { 5, 3, 8, 2, 4, 7, 9 }, 2)]
    public void ShouldReturnMinimalValue(int[] values, int expectedMin)
    {
        var tree = new AvlTree<int>(values);

        Assert.Equal(expectedMin, tree.FindMin());
    }

    [Fact]
    public void EmptyArray_ShouldThrowException()
    {
        var tree = new AvlTree<int>([]);

        Assert.Throws<InvalidOperationException>(() => tree.FindMin());
    }

    [Fact]
    public void NoElements_ShouldThrowException()
    {
        var tree = new AvlTree<int>();

        Assert.Throws<InvalidOperationException>(() => tree.FindMin());
    }
}
