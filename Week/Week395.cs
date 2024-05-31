using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solution;

public class Week395
{
    public int AddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        return nums2[0] - nums1[0];
    }

    public int MinimumAddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        List<int> tNums2 = new List<int>();
        for (var i = 1; i < nums2.Length; i++)
        {
            tNums2.Add(nums2[i - 1] - nums2[i]);
        }

        List<int> tNums1 = new List<int>();
        for (var i = 1; i < nums1.Length; i++)
        {
            tNums1.Add(nums1[i - 1] - nums1[i]);
        }

        int j = 0;
        List<int> Temp = new List<int>();
        for (var i = 0; i < tNums2.Count; i++)
        {
            if (tNums1[j] == tNums2[i])
            {
                j++;
                continue;
            }
            else
            {
                Temp.Add(tNums1[j]);
                j += 2;
            }
        }

        if (Temp.Count == 1)
        {
            return nums2[1] - nums1[0];
        }
        if(Temp.Count == 0)


    }

    public long MinEnd(int n, int x)
    {
        // long[] nums = new long[n];
        // long pre = 0;
        // for (int i = 0; i < n; i++)
        // {
        //     long t = pre + 1;
        //     while(t&x==)
        // }
    }

    public long BitWiseAnd(int a, int b)
    {
        return a & b;
    }
}