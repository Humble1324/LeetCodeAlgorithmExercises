using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Animation;
using System.Xaml;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static int MaxResult(int[] nums, int k)
    {
        var lens = nums.Length;
        var temp = 0;
        var Max = 0;
        while (temp < lens)
        {
            var max = int.MinValue;
            var tempIndex = temp;
            for (var i = 0; temp + i < lens && i < k; i++)
            {
                //Console.WriteLine($"i={i},nums[i]={nums[i]}");
                if (nums[i + temp] > max)
                {
                    max = nums[i + temp];
                    tempIndex = i + temp;
                    Console.WriteLine($"temp={temp},i={i},max={max},tempIndex={tempIndex}");
                }
            }

            Max += max;
            temp = tempIndex + 1;
        }

        return Max;
    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var q = new LinkedList<int>();
        var ans = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            //维护单调队列尾
            while (q.Last != null && q.Count != 0 && nums[q.Last.Value] <= nums[i])
                q.RemoveLast();
            //新数字下标加入队列尾
            q.AddLast(i); 
            //出 
            if (q.First != null && i - q.First.Value >= k) q.RemoveFirst();
            //记录答案：遍历k-1次 记录一次答案
            if(i>=k-1)ans.Add(nums[q.First.Value]);
        }
        return ans.ToArray();
    }
    // public static void Main()
    // {
    //     List<int> test = new List<int>() { 1,-1,-2,4,-7,3 };
    //
    //     Console.WriteLine(MaxResult(test.ToArray(),2));
    // }
}