using L.DataStructures.SearchTrees;

namespace Tests.SearchTrees.AVLTreeTest;

public class Remove
{
    [Theory]
    [InlineData(new int[] { 0 }, new int[] { }, 1 )]
    [InlineData(new int[] { 0 }, new int[] { 0 }, 0)]
    [InlineData(new int[] { 0, 0 }, new int[] { 0 }, 1)]
    public void ShouldDecreaseHeight(int[] initialValues, int[] valuesToRemove, int expectedHeight)
    {
        var tree = new AvlTree<int>(initialValues);

        foreach (int valueToRemove in valuesToRemove)
        {
            tree.Remove(valueToRemove);
        }

        Assert.Equal(expectedHeight, tree.Height);
    }

    [Fact]
    public void NotExistingValue_ShouldNotChange()
    {
        var tree = new AvlTree<int>([0, 1, 2]);

        tree.Remove(-1);

        Assert.Equal(2, tree.Height);
    }
}
