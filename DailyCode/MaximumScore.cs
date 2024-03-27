using System;

namespace LeetCode.DailyCode;

public partial class DailyCode

{
    public int MaximumScore(int[] nums, int k)
    {
        //下标范围内的最小值 *下标差  求最大值
        //  1:下标差越大&&最小值没有跳变
        //从最左开始,加入右,如果变大就继续,变小就记录当前最大值 右变左 继续?
        //
        var lens = nums.Length;
        var left = k - 1;
        var right = k + 1;
        var min = nums[k];
        int width = 1;
        var maxValue = nums[k];
        while (width<lens)
        {
            width++;
            if (left >= 0 && right < lens)
            {
                if (nums[left] > nums[right])
                {
                    min = Math.Min(min, nums[left--]);
                }
                else
                {
                    min = Math.Min(min, nums[right++]);
                }
            }
            else if (left >= 0)
            {
                min = Math.Min(min, nums[left--]);
            }
            else
            {
                min = Math.Min(min, nums[right++]);
            }
        }

        maxValue = Math.Max(min * width, maxValue);

        return maxValue;
    }
}