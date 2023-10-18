using System.Collections.Generic;
using System.Windows;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int[] DistinctDifferenceArray(int[] nums)
    {
        var lens = nums.Length;
        var temp = new int[lens];
        for (var i = 0; i < lens; i++)
        {
            HashSet<int> leftSet = new HashSet<int>(), rightSet = new HashSet<int>();
            for (var left = 0; left < i; left++)
            {
                leftSet.Add(nums[left]);
            }

            for (var right = i + 1; right < lens; right++)
            {
                rightSet.Add(nums[right]);
            }

            temp[i] = leftSet.Count - rightSet.Count;
        }

        return temp;
    }
    
}