using L.DataStructures.SearchTrees;

namespace Tests.SearchTrees.AVLTreeTest;
public class Insert
{
    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 0 }, 1)]
    [InlineData(new int[] { 0 , 0 }, 2)]
    public void ShouldIncreaseCount(int[] values, int expectedHeight)
    {
        var tree = new AvlTree<int>(values);

        Assert.Equal(expectedHeight, tree.Height);
    }
}
