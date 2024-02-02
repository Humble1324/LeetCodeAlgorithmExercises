using System;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int StoneGameVI(int[] aliceValues, int[] bobValues)
    {
        /*
         Alice 和 Bob 轮流玩一个游戏，Alice 先手。
        一堆石子里总共有 n 个石子，轮到某个玩家时，他可以 移出 一个石子并得到这个石子的价值。Alice 和 Bob 对石子价值有 不一样的的评判标准 。双方都知道对方的评判标准。
        给你两个长度为 n 的整数数组 aliceValues 和 bobValues 。aliceValues[i] 和 bobValues[i] 分别表示 Alice 和 Bob 认为第 i 个石子的价值。
        所有石子都被取完后，得分较高的人为胜者。如果两个玩家得分相同，那么为平局。两位玩家都会采用 最优策略 进行游戏。
        请你推断游戏的结果，用如下的方式表示：
        如果 Alice 赢，返回 1 。
        如果 Bob 赢，返回 -1 。
        如果游戏平局，返回 0 。
         */
        //找到双方最优解:取当前石头A+B分值最高的石头
        //每个拿取的分值是自己的减去对方的
        var temp = new int[aliceValues.Length][];
        int a = 0, b = 0;
        for (var i = 0; i < temp.Length; i++)
        {
            temp[i] = new int[3];
            temp[i][0] = aliceValues[i] + bobValues[i];
            temp[i][1] = aliceValues[i];
            temp[i][2] = bobValues[i];
        }

        //对于A和B都是选取当前分最高的值
        Array.Sort(temp, (a, b) => b[0] - a[0]); //temp子数组的第一元素
        for (var i = 0; i < temp.Length; i++)
        {
            if (i % 2 == 0)
            {
                a += temp[i][1];
            }
            else
            {
                b += temp[i][2];
            }
        }


        int t = 0;
        if (a > b) t = 1;
        if (a < b) t = -1;
        if (a == b) t = 0;
        return t;
    }
}