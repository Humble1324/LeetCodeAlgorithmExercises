using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public static int OrangesRotting(int[][] grid)
    {
        //每分钟遍历所有橘子，只要有烂的就给他四周打上当前时间+1，如果已经被标记就无视
        //第二轮开始遍历所有时间为+1的橘子
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };
        int m = grid.Length;
        int n = grid[0].Length;
        int time = 0;
        Queue<int> Que = new Queue<int>();
        Dictionary<int, int> Dic = new Dictionary<int, int>();
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 2)
                {
                    Dic.Add(i * n + j, 0);
                    Que.Enqueue(i * n + j);
                }
            }
        }
        while ( Que.Count > 0)
        {
            var t = Que.Dequeue();
            for (var d = 0; d < 4; d++)
            {
                var x = t / n + dx[d];
                var y = t % n + dy[d];
               // Console.WriteLine($"m={m},n={n},x={x},y={y}");
                if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] == 1)
                {
                    if (Dic.ContainsKey(x * m + y))
                    {
                        Dic[x * n + y] = Dic[t] + 1;
                    }
                    else
                    {
                        Dic.Add(x * n + y, Dic[t] + 1);
                    }

                    grid[x][y] = 2;
                    Que.Enqueue(x * n + y);
                    time = Dic[x * n + y];
                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    return -1;
                }
            }
        }


        return time;
    }

    // public static void Main()
    // {
    //     int[][] test = new int[][] { new int[] { 2,2,2,1,1 } };
    //     Console.WriteLine(OrangesRotting(test));
    // }
}