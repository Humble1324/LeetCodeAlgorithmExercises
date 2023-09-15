using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        var lens = nums.Length;
        var ans = nums[0] + nums[1] + nums[2];
        for (var i = 0; i < lens; i++)
        {
            var slow = 1 + i;
            var fast = lens - 1;
            while (slow < fast)
            {
                var temp = nums[fast] + nums[slow] + nums[i];
                if (Math.Abs(target - temp) < Math.Abs(ans - target))
                    ans = temp;
                if (temp > target)
                    fast--;
                else if (temp < target)
                    slow++;
                else return target;
            }
        }

        return ans;
    }

    // public static void Main()
    // {
    //     int[] candies = new int[] {-1,2,1,-4 };
    //     Console.WriteLine(ThreeSumClosest(candies,1));
    // }
}