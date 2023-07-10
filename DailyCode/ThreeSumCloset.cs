using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int lens = nums.Length;
        int ans = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < lens; i++)
        {
            int slow = 1+i;
            int fast = lens - 1;
            while (slow < fast)
            {
                int temp = nums[fast] + nums[slow]+nums[i];
                if (Math.Abs(target - temp) < Math.Abs(ans - target))
                    ans = temp;
                if(temp>target)
                    fast--;
                else if (temp <target )
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