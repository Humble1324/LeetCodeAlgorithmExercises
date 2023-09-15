using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode;

public class RecentCounter
{
    private readonly Queue<int> tQueue = new();

    public RecentCounter()
    {
        tQueue.Clear();
    }

    public int Ping(int t)
    {
        tQueue.Enqueue(t);
        while (tQueue.Count > 0 && tQueue.Peek() > t - 3000) tQueue.Dequeue();

        return tQueue.Count;
    }

    public static int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        var time = new int[timeSeries.Max() + duration];
        var lens = timeSeries.Length;
        for (var i = 0; i < lens; i++)
        {
            var temp = duration;
            while (temp > 0)
            {
                time[timeSeries[i] + temp - 1] = 1;
                temp--;
            }
        }

        var sum = 0;
        foreach (var bigtime in time)
            if (bigtime == 1)
                sum++;

        return sum;
    }

    public string PredictPartyVictory(string senate)
    {
        var lens = senate.Length;
        var sb = new StringBuilder(senate, lens);
        if (lens < 2) return sb[0] == 'D' ? "Dire" : "Radiant";
        var flag = 0;
        bool D = false, R = false;
        while (D && R)
        {
            R = false;
            D = false;
            for (var i = 0; i < lens; i++)
            {
                if (sb[i] == 'D')
                {
                    if (flag < 0) sb[i] = ' ';
                    else R = true;
                    flag++;
                }

                if (sb[i] == 'R')
                {
                    if (flag < 0) sb[i] = ' ';
                    else D = true;
                    flag--;
                }
            }
        }

        return R ? "Radiant" : "Dire";
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var temp = 0;
        for (var i = m; i < nums1.Length; i++) nums1[i] = nums2[temp++];

        Array.Sort(nums1);
    }

    public void MergeII(int[] nums1, int m, int[] nums2, int n)
    {
    }

    // public static void Main()
    // {
    //     Console.Write(FindPoisonedDuration(new int[] { 2, 4, 6, 8, 10 }, 2));
    // }
}