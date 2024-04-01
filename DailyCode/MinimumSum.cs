using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static int MinimumSum(int[] nums)
    {
        int lens = nums.Length;
        var tempMin = int.MaxValue;
        for (var i = 1; i < lens - 1; i++)
        {
            var templeft = int.MaxValue;
            var tempright = int.MaxValue;
            for (var left = 0; left < i; left++)
            {
                if (nums[left] < nums[i] && templeft > nums[left])
                    templeft = nums[left];
            }

            for (var right = i + 1; right < lens; right++)
            {
                if (nums[right] < nums[i] && tempright > nums[right])
                    tempright = nums[right];
            }

            if (templeft != int.MaxValue && tempright != int.MaxValue)
                tempMin = Math.Min(tempMin, templeft + nums[i] + tempright);
        }

        tempMin = tempMin == int.MaxValue ? -1 : tempMin;
        return tempMin;
    }

    public static int MinimumSumII(int[] nums)
    {
        int lens = nums.Length;
        int tempMin = int.MaxValue;
        int[] left = new int[lens];
        int nm = 1000;
        for (var i = 1; i < lens; i++)
        {
            left[i] = nm = Math.Min(nm, nums[i - 1]);
        }

        //每个都是左边最小
        var right = nums[lens - 1];
        for (var rightIndex = lens - 2; rightIndex > 0; rightIndex--)
        {
            if(nums[rightIndex]>right&&nums[rightIndex]>left[rightIndex])
                tempMin=Math.Min(tempMin,left[rightIndex]+nums[rightIndex]+right);
            right = Math.Min(right, nums[rightIndex]);
        }
    

        return tempMin==int.MaxValue?-1:tempMin;
    }

    // public static void Main()
    // {
    //     Console.WriteLine(MinimumSum(new int[] { 5, 4, 8, 7, 10, 2 }));
    // }
}