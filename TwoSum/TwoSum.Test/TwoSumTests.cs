namespace TwoSum.Test;

public class TwoSumTests
{
    [Fact]
    public void TestTarget9()
    {
        int[] nums = [2, 7, 11, 15];
        const int target = 9;

        var sut = new Solution();
        var actual = sut.TwoSum(nums, target);
        int[] expected = [0, 1];
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestTargetLeet()
    {
        int[] nums = [1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1];
        
        const int target = 11;

        var sut = new Solution();
        var actual = sut.TwoSum(nums, target);
        int[] expected = [5, 11];
        
        Assert.Equal(expected, actual);
    }
}