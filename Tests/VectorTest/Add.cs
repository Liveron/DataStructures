using L.DataStructures;

namespace Tests.VectorTest;

public class Add
{
    [Fact]
    public void ShouldIncreaseLength()
    {
        var vector = new Vector<int>();

        vector.Add(1);

        Assert.Equal(1, vector.Length);
    }

    [Fact]
    public void ShouldIncreaseCapacityWhenNeeded()
    {
        var vector = new Vector<int>(2);

        int[] values = [1, 2, 3];

        Array.ForEach(values, vector.Add);

        Assert.Equal(4, vector.Capacity);
    }
}
