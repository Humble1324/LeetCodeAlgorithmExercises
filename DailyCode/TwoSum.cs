using System.Collections.Generic;

public partial class DailyCode
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashSum = new Dictionary<int, int>();
        var lens = nums.Length;
        for (var i = 0; i < lens; i++)
            if (!hashSum.ContainsKey(nums[i]))
                hashSum.TryAdd(target - nums[i], i);
            else
                return new[] { hashSum[nums[i]], i };

        return null;
    }
}