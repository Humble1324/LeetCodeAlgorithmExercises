using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202407
{
    public static int MinimumLevels(int[] possible)
    {
        int maxScore = 0;
        int lens = possible.Length;
        for (var i = 0; i < lens; i++)
        {
            if (possible[i] == 0)
            {
                maxScore--;
            }
            else
            {
                maxScore++;
            }
        }

        int leftIndex = 1;
        int leftScore = possible[0] == 0 ? -1 : 1;

        while (leftScore <= (maxScore - leftScore) && leftIndex <= lens - 2)
        {
            if (possible[leftIndex] == 0)
            {
                leftScore--;
            }
            else
            {
                leftScore++;
            }

            leftIndex++;
        }

        if (leftScore > (maxScore - leftScore))
        {
            return leftIndex;
        }

        return -1;
    }

    public Dictionary<int, int> numsDic = new Dictionary<int, int>();

    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
    {
        List<int> ans = new List<int>();
        foreach (var num in nums)
        {
            AddDic(num);
        }

        int lens = moveFrom.Length;
        for (int i = 0; i < lens; i++)
        {
            int t = numsDic[moveFrom[i]];
            numsDic[moveFrom[i]] -= t;
            AddDic(moveTo[i], t);
        }

        foreach (var keyValuePair in numsDic)
        {
            int upper = keyValuePair.Value;
            if (upper > 0)
            {
                ans.Add(keyValuePair.Key);
            }
        }

        ans.Sort();
        return ans;
    }

    public IList<int> RelocateMarblesV2(int[] nums, int[] moveFrom, int[] moveTo)
    {
        HashSet<int> ans = new HashSet<int>(nums);
        int lens = moveFrom.Length;
        for (int i = 0; i < lens; i++)
        {
            ans.Remove(moveFrom[i]);
            ans.Add(moveTo[i]);
        }

        var s = ans.ToArray();
        Array.Sort(s);
        return s;
    }

    public void AddDic(int nums, int length = 1)
    {
        numsDic.TryAdd(nums, 0);
        numsDic[nums] += length;
    }

    public static int MinimumOperations(string num)
    {
        int lens = num.Length;
        char[] sortNum = num.ToCharArray();
        sortNum = sortNum.Reverse().ToArray();
        int count = 0, indexFR = 0, indexFL = 0, indexZL = 0, indexZR = 0;
        int F = int.MaxValue;
        while (indexFR < lens - 2 && sortNum[indexFR] != '5')
        {
            indexFR++;
        }

        if (indexFR < lens - 1&& sortNum[indexFR] == '5')
        {
            indexFL = indexFR + 1;
            while (indexFL < lens - 1 && sortNum[indexFL] != '2' && sortNum[indexFL] != '7')
            {
                indexFL++;
            }

            if (sortNum[indexFL] == '2' || sortNum[indexFL] == '7')
            {
                F = int.Min(F, Math.Abs(indexFL - indexFR) + indexFR - 1);
            }
        }

        
        
        int Z = int.MaxValue;
        while (indexZR < lens - 2 && sortNum[indexZR] != '0')
        {
            indexZR++;
        }

        if (indexZR < lens - 1&& sortNum[indexZR] == '0')
        {
            indexZL = indexZR + 1;
            while (indexZL < lens - 1 && sortNum[indexZL] != '5' && sortNum[indexZL] != '0')
            {
                indexZL++;
            }

            if (sortNum[indexZL] == '5' || sortNum[indexZL] == '0')
            {
                    Z = Math.Min(Math.Abs(indexZL - indexZR) + indexZR - 1, Z);
            }
            else if(sortNum[indexZR]=='0')
            {
                Z = lens - 1;
            }
        }

        count = Math.Min(F, Z);
        if (count == int.MaxValue)
        {
            if (sortNum[indexZL] != '0')
                count = lens;
            else
            {
                count = lens - 1;
            }
        }

        return count;
    }

    // public static void Main()
    // {
    //     MinimumOperations("20");
    // }
}