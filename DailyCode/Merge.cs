using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int[][] Merge(int[][] intervals)
    {
        //按照首元素排序
        //把每个最大值去循环查找是否在后面的的范围，在的话就合并
        if (intervals.Length == 1) return intervals;
        int lens = intervals.Length;
        int[][] ints = new int[lens][];
        Array.Sort(intervals,(x,y)=>x[0].CompareTo(y[0]));
        ints[0] = intervals[0];
        var  temp = 0;
        for (var i = 1; i < lens; i++)
        {
            if (intervals[i][0] <= ints[temp][1])
            {
                ints[temp][1] = Math.Max(intervals[i][1], ints[temp][1]);
            }
            else
            {
                temp++;
                ints[temp] = new int[]{intervals[i][0],intervals[i][1]};
            }
        }

        ints = ints.Where(x => x != null).ToArray();
        return ints;
    }
    
}