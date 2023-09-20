using System.Collections.Generic;

namespace LeetCode.DailyCode;

public partial class DailyCode
{
    // public int[] FullBloomFlowers(int[][] flowers, int[] people)
    // {
    //     //flowers[花期开始][花期结尾]
    //     Dictionary<int, int> FlowerDic = new Dictionary<int, int>();
    //     foreach (var flower in flowers)
    //     {
    //         for (int i = flower[0]; i <= flower[1]; i++)
    //         {
    //             if (!FlowerDic.ContainsKey(i))
    //             {
    //                 FlowerDic.Add(i,1);
    //             }
    //             else
    //             {
    //                 FlowerDic[i]++;
    //             }
    //         }
    //     }
    //     for (var i = 0; i < people.Length; i++)
    //     {
    //         people[i] = FlowerDic.ContainsKey(people[i]) ? FlowerDic[people[i]] : 0;
    //     }
    //     return people;
    // }
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        return people;
    }
}