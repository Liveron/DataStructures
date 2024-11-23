using L.DataStructures;

namespace Tests.VectorTest;

public class Constructor
{
    [Fact]
    public void Empty_SetsInitialCapacity()
    {
        var vector = new Vector<int>();
        Assert.Equal(4, vector.Capacity);
    }

    [Fact]
    public void Empty_SetsInitialLengthToZero()
    {
        var vector = new Vector<int>();
        Assert.Equal(0, vector.Length);
    }

    [Fact]
    public void WithCapacity_SetsCapacity()
    {
        var vector = new Vector<int>(10);
        Assert.Equal(10, vector.Capacity);
    }

    [Fact]
    public void WithCapacity_SetsLengthToZero()
    {
        var vector = new Vector<int>(10);
        Assert.Equal(0, vector.Length);
    }

    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 1, 2, 3 }, 3)]
    public void WithValues_SetsLength(int[] initialValues, int expectedLenght)
    {
        var vector = new Vector<int>(initialValues);
        Assert.Equal(expectedLenght, vector.Length);
    }

    [Theory]
    [InlineData(new int[] { }, 4)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, 2, 3 }, 3)]
    public void WithValuesSetsCapacity(int[] initialValues, int expectedLenght)
    {
        var vector = new Vector<int>(initialValues);
        Assert.Equal(expectedLenght, vector.Capacity);
    }
}
