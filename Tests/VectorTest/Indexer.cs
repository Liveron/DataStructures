using L.DataStructures;

namespace Tests.VectorTest;

public class Indexer
{
    [Fact]
    public void Get_ShouldReturnCorrectValue()
    {
        var vector = new Vector<int>([1, 2, 3]);

        Assert.Equal(2, vector[1]);
    }

    [Fact]  
    public void Set_ShouldUpdateValue()
    {
        var vector = new Vector<int>([1, 2, 3]);

        vector[1] = 10;

        Assert.Equal(10, vector[1]);
    }
}
