 using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static long MaximumSumOfHeights(IList<int> maxHeights)
    {
        //按山峰高度排序存入新数组
        //依次计算最大结果
        List<int> tempMax = new List<int>();
        tempMax = (List<int>)maxHeights;
        tempMax = tempMax.OrderByDescending(x => x).ToList();
        long max = 0;
        int repeat = 0;
        for (var i = 0; i < maxHeights.Count; i++)
        {
            if (i > 0)
            {
                if (tempMax[i] == tempMax[i - 1])
                    repeat++;
                else repeat = 0;
            }

            var temp = FindIndex((List<int>)maxHeights, tempMax[i], repeat);
            max = Math.Max(max, MaximumSum(maxHeights, temp));
        }

        return max;
    }

    public static int FindIndex(List<int> nums, int num, int repeat)
    {
        int index = -1;
        int re = 0;
        for (var i = 0; i < nums.Count; i++)
        {
            if (nums[i] != num) continue;
            if (re != repeat) re++;
            else
            {
                return i;
            }
        }

        return index;
    }

    public static long MaximumSum(IList<int> moun, int maxIndex)
    {
        int[] mountain = moun.ToArray();
        var lens = mountain.Length - 1;
        int right = maxIndex, left = maxIndex;
        long max = 0;
        while (left > 0 || right < lens)
        {
            if (left > 0)
            {
                left--;
                if (mountain[left] <= mountain[left + 1]) continue;
                mountain[left] = mountain[left + 1];
            }

            if (right < lens)
            {
                right++;
                if (mountain[right] <= mountain[right - 1]) continue;
                mountain[right] = mountain[right - 1];
            }
        }

        foreach (var i in mountain)
        {
            max += i;
        }

        return max;
    }

    // public static void Main()
    // {
    //     List<int> test = new List<int>() { 1, 5, 2, 5, 6, 4, 6, 3, 4, 5 };
    //
    //     Console.WriteLine(MaximumSumOfHeights(test));
    // }
}