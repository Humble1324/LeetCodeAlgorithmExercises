using System;
using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public static IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
    {
        //     在一个 8x8 的棋盘上，放置着若干「黑皇后」和一个「白国王」。
        //     给定一个由整数坐标组成的数组 queens ，表示黑皇后的位置；以及一对坐标 king ，表示白国王的位置，返回所有可以攻击国王的皇后的坐标(任意顺序)。

        int x = king[0], y = king[1];
        Dictionary<string, int> queen = new();
        IList<IList<int>> returnNums = new List<IList<int>>();
        foreach (int[] littleQueen in queens)
        {
            queen.Add(littleQueen[0]+littleQueen[1].ToString(), 0);
        }

        for (int i = 1; i < 8; i++)
        {
            int tempY = y + i;
            if (tempY >= 8) break;
            if (queen.ContainsKey(x+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { x, tempY });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempY = y - i;
            if (tempY < 0) break;
            if (queen.ContainsKey(x+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { x, tempY });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x + i;
            if (tempX >= 8) break;
            if (queen.ContainsKey(tempX+y.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, y });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x - i;
            if (tempX < 0) break;
            if (queen.ContainsKey(tempX+y.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, y });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x - i;
            int tempY = y - i;
            if (tempX < 0 || tempY < 0) break;
            if (queen.ContainsKey(tempX+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, tempY });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x + i;
            int tempY = y + i;
            if (tempX >= 8 || tempY >= 8) break;
            if (queen.ContainsKey(tempX+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, tempY });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x - i;
            int tempY = y + i;
            if (tempX < 0 || tempY >= 8) break;
            if (queen.ContainsKey(tempX+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, tempY });
                break;
            }
        }

        for (int i = 1; i < 8; i++)
        {
            int tempX = x + i;
            int tempY = y - i;
            if (tempY < 0 || tempX >= 8) break;
            if (queen.ContainsKey(tempX+tempY.ToString()))
            {
                returnNums.Add(new List<int>() { tempX, tempY });
                break;
            }
        }

        return returnNums;
    }

    // public static void Main(string[] args)
    // {
    //     //int[][] candies =new [] {{0,1},[1,0],[4,0],[0,4],[3,3],[2,4]]};
    //     Console.WriteLine("Test Log");
    //     var leet = new LeetCode75();
    //     Console.WriteLine(QueensAttacktheKing(
    //         new int[][]
    //         {
    //             new[] { 0, 1 }, new[] { 1, 0 }, new[] { 4, 0 }, new[] { 0, 4 }, new[] { 3, 3 }, new[] { 2, 4 },
    //         }, new int[] { 0, 0 }));
    // }
}