using L.DataStructures;

namespace Tests.VectorTest;

public class Remove
{
    [Fact]
    public void ShouldDecreaseLength()
    {
        var vector = new Vector<int>([1 , 2, 3]);

        vector.Remove();

        Assert.Equal(2, vector.Length);
    }
}
