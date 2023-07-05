using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode;

public class RecentCounter
{
    private Queue<int> tQueue = new();
    public RecentCounter() {
        tQueue.Clear();
    }
    
    public int Ping(int t)
    {
        tQueue.Enqueue(t);
        while(tQueue.Count>0&&tQueue.Peek()> t-3000){
   
                tQueue.Dequeue();
            
        }
        return tQueue.Count;
    }
    
    public static int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        int[] time = new int[timeSeries.Max()+duration];
        int lens = timeSeries.Length;
        for (int i = 0; i < lens; i++)
        {
            int temp = duration;
            while (temp > 0)
            {
                time[timeSeries[i]+temp-1] = 1;
                temp--;
            }

        }

        int sum = 0;
        foreach (var bigtime in time)
        {
            if (bigtime == 1) sum++;
        }
        return sum;
        
    }
    public static void Main()
    {
        Console.Write(FindPoisonedDuration(new int[]{2,4,6,8,10},2));
    }
}