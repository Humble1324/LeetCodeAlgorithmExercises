using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long MaxKelements(int[] nums, int k)
    {
        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            q.Enqueue(num,-num);
        }
        long temp = 0;
        for (int i = 0; i < k; i++)
        {
            var x = q.Dequeue();
            temp += x;
            q.Enqueue((x+2)/3,-(x+2)/3);
        }

        return temp;
    }

    public int FindMax(int[] nums)
    {
        int index=0;
        int temp = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > temp)
            {
                temp = nums[i];
                index = i;
            }
        }

        return index;
    }
}