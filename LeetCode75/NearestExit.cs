using System;
using System.Collections.Generic;

namespace LeetCode;

public partial class LeetCode75
{
    public  int NearestExit(char[][] maze, int[] entrance)
    {
        //记录所有出口的路径找最短？
        Queue<Tuple<int, int, int>> Que = new Queue<Tuple<int, int, int>>(); 
        //队列存放待计算的路径，元祖内是坐标加上和起点的距离 
        //if() 
        var m = maze.Length;
        var n = maze[0].Length;
        
        Que.Enqueue(new Tuple<int, int, int>(entrance[0], entrance[1], 0));
        maze[entrance[0]][entrance[1]] = '+';
        
        //上下左右方向
        int[] dx = {0, 0, -1, 1};
        int[] dy = { -1, 1, 0, 0 };
        while (Que.Count > 0)
        {
            var temp = Que.Dequeue();
            for (var i = 0; i < 4; i++)
            {
                var x = temp.Item1 + dx[i];
                var y = temp.Item2 + dy[i];
                if (x >= 0 && x < m && y >= 0 && y < n && maze[x][y]=='.')
                {
                    if (x == 0 || x == m - 1 || y == 0 || y == n - 1)
                    {
                        return temp.Item3 + 1;
                    }

                    maze[x][y] = '+';
                    Que.Enqueue(new Tuple<int, int, int>(x,y,temp.Item3+1));
                }
                
            }
            
        }
        
        return -1;
    }
    
    // public static void Main()
    // {
    //     char[][] maze = new char[][] { new char[] {'+', '+', '+'}, new char[] { '.', '.', '.'}, new char[] {'+', '+', '+'} };
    //     int[] entrance = {1, 0};
    //     Console.WriteLine(NearestExit(maze, entrance));
    // }
}