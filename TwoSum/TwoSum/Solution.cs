namespace TwoSum;

public class Solution
{
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            if (!map.TryAdd(nums[i], i))
            {
                Console.WriteLine("Error");
            }
        }

        return [];
    }
}