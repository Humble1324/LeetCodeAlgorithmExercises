using System.Collections.Generic;

namespace LeetCode.Solution;

public class Sort
{
    public void QuickSort(int[] nums)
    {
        //取中间值 放到合适的位置，左右固定
        //循环这个操作
        if (nums.Length <= 1) return;
        var left = new List<int>();
        var right = new List<int>();
        var mid = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < mid)
                left.Add(nums[i]);
            else
                right.Add(nums[i]);
        }
    }
}