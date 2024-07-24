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
            AddDic(moveTo[i],t);
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
        HashSet <int> ans= new HashSet<int>(nums);
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
    public void AddDic(int nums,int length=1)
    {
        numsDic.TryAdd(nums, 0);
        numsDic[nums]+=length;
    }
    // public static void Main()
    // {
    //     MinimumLevels(new int[] {0,1,0 });
    // }
}