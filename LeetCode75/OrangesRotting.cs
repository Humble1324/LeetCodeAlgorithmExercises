using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public int OrangesRotting(int[][] grid)
    {
        //每分钟遍历所有橘子，只要有烂的就给他四周打上当前时间+1，如果已经被标记就无视
        //第二轮开始遍历所有时间为+1的橘子
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };
        Queue<Tuple<int, int, int>> Que = new Queue<Tuple<int, int, int>>();//坐标，时间
        


        return -1;
    }
}