namespace AllOneTest;

public class AllOTest : IDisposable
{
    [Fact]
    public void TestGetMaxMin()
    {
        var one = new AllOne.AllOne();
        one.Inc("hello");
        Assert.Equal("hello", one.GetMaxKey());
        Assert.Equal("hello", one.GetMinKey());
    }

    [Fact]
    public void TestLeetCode1()
    {
        var allOne = new AllOne.AllOne();
        allOne.Inc("hello");
        allOne.Inc("hello");
        Assert.Equal("hello", allOne.GetMaxKey()); // return "hello"
        Assert.Equal("hello", allOne.GetMinKey()); // return "hello"
        allOne.Inc("leet");
        Assert.Equal("hello", allOne.GetMaxKey()); // return "hello"
        Assert.Equal("leet", allOne.GetMinKey()); // return "leet"
    }

    [Fact]
    public void TestLeetCode2()
    {
        var allOne = new AllOne.AllOne();
        
        allOne.Inc(["AllOne","inc","inc","inc","inc","inc","inc","inc","inc","inc","inc","inc","inc","dec","dec","dec","dec","dec","dec","inc","inc","inc","inc","getMaxKey","getMinKey","inc","inc","getMaxKey","getMinKey","inc","dec","getMaxKey","getMinKey"]);
    }

    public void Dispose()
    {

    }
}