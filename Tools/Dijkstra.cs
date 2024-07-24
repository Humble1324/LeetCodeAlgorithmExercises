using System;
using System.Collections.Generic;

namespace LeetCode.Tools;

public class Dijkstra
{
    public int[] MinimumTime(int n, int[][] edges, int[] disappear)
    {
        const int INF = Int32.MaxValue / 2;
        //初始数组填满最大值
        int[][] g = new int[n][];
        for (var i = 0; i < g.Length; i++)
        {
            g[i] = new int[n];
            Array.Fill(g[i], INF);
        }

        //给g赋值 g是展示顶点之间是否联通以及有联通的当前两节点之间的权重
        foreach (var t in edges)
        {
            g[t[0]][t[1]] = t[2];
        }

        
        int maxDis = 0;
        int[] dis = new int[n]; //从点i到各个点的最少路径
        Array.Fill(dis, INF);
        dis[0] = 0; //出发点值为0
        
        bool[] isDone = new bool[n]; //记录是否完成最少路径计算
        while (true)
        {
            int x = -1;
            for (var i = 0; i < n; i++)
            {
                if (!isDone[i] && (x < 0 || dis[i] < dis[x])) //没完成且 当前格子没值 或者新的值小于当前值
                {
                    x = i;
                }
            }

            // if (x < 0)
            // {
            //     return maxDis;
            // }
            //
            // if (dis[x] == INF)
            // {
            //     return -1;
            // }

            maxDis = dis[x];
            isDone[x] = true;
            for (int y = 0; y < n; y++)
            {
                dis[y] = Math.Min(dis[y], dis[x] + g[x][y]); //每更新一个点就看看所有店有没有更小的路径
            }
        }
        for (var i = 1; i < dis.Length; i++)
        {
            dis[i]=dis[i]<=disappear[i]?dis[i]:-1;
        }
        return dis;

    }

    public static int NetworkDelayTime(int[][] times, int n, int k)
    {
        const int INF = Int32.MaxValue / 2;
        //初始数组填满最大值
        int[][] g = new int[n][];
        for (var i = 0; i < g.Length; i++)
        {
            g[i] = new int[n];
            Array.Fill(g[i], INF);
        }

        //给g赋值 g是展示顶点之间是否联通以及有联通的当前两节点之间的权重
        foreach (var t in times)
        {
            g[t[0] - 1][t[1] - 1] = t[2];
        }

        int maxDis = 0;
        int[] dis = new int[n]; //从点i到各个点的最少路径
        Array.Fill(dis, INF);
        dis[k - 1] = 0; //出发点值为0
        bool[] isDone = new bool[n]; //记录是否完成最少路径计算
        while (true)
        {
            int x = -1;
            for (var i = 0; i < n; i++)
            {
                if (!isDone[i] && (x < 0 || dis[i] < dis[x])) //没完成且 当前格子没值 或者新的值小于当前值
                {
                    x = i;
                }
            }

            if (x < 0)
            {
                return maxDis;
            }

            if (dis[x] == INF)
            {
                return -1;
            }

            maxDis = dis[x];
            isDone[x] = true;
            for (int y = 0; y < n; y++)
            {
                dis[y] = Math.Min(dis[y], dis[x] + g[x][y]); //每更新一个点就看看所有店有没有更小的路径
            }
        }

        return -1;
    }

    public static int NetworkDelayTimeByHeap(int[][] times, int n, int k)
    {
        List<int[]>[] g =new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = new List<int[]>();
        }

        int maxDis = 0;
        int left = n;
        int[] dis =new int[n];
        Array.Fill(dis, Int32.MaxValue);
        dis[k - 1] = 0;
        //PriorityQueue<int> pq = new PriorityQueue<int>((a,b)->(a[0]-b[0]));
        return -1;
    }
    // public  static void Main()
    // {
    //     NetworkDelayTime(new[] { new[] { 2,1,1 } ,new[] { 2,3,1 },new[] { 3,4,1 }}, 4, 2);
    // }
}