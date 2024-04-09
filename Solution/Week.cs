using System;
using System.Text;

namespace LeetCode.Solution;

public class Week
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int lens = nums.Length;
        if (lens == 1) return 1;
        int tempAddMax = 0;
        int tempSubMax = 0;
        for (int i = 1; i < lens; i++)
        {
            int temp = 1;
            while (i < lens && nums[i] > nums[i - 1])
            {
                i++;
                temp++;
            }

            tempAddMax = Math.Max(temp, tempAddMax);
        }

        for (int i = 1; i < lens; i++)
        {
            int temp = 1;
            while (i < lens && nums[i] < nums[i - 1])
            {
                i++;
                temp++;
            }

            tempSubMax = Math.Max(temp, tempSubMax);
        }

        return Math.Max(tempSubMax, tempAddMax);
    }

    public static string GetSmallestString(string s, int k)
    {
        //distance(s1,s2)衡量两个字符串的距离
        //s1+s2=s
        StringBuilder sb = new StringBuilder(s);
        for (int i = 0; i < sb.Length; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                if (Distance(sb[i].ToString(), ((char)((char)'a' + j)).ToString()) <= k)
                {
                    var t = Distance(sb[i].ToString(), ((char)((char)'a' + j)).ToString());
                    k -= t;
                    sb[i] = (char)('a' + j);
                    break;
                }
            }
        }

        return sb.ToString();
    }

    public static int Distance(string s1, string s2)
    {
        if (s1.Length != s2.Length) return -1;
        int lens = s1.Length;
        int count = 0;
        int offSet = (char)'a';
        for (var i = 0; i < lens; i++)
        {
            var t = Math.Abs((char)(s1[i] - offSet) - (char)(s2[i] - offSet));
            if (t > 13)
            {
                t = Math.Abs(26 - t);
            }

            count += t;
        }

        return Math.Abs(count);
    }

    public long MinOperationsToMakeMedianK(int[] nums, int k)
    {
        int count = 0;
        int[] t = nums;
        int mid = nums.Length / 2;
        Array.Sort(t);
        while (!isMid(t, k))
        {
            count++;
            if (t[mid] > k)
            {
                --t[mid];
            }
            else
            {
                ++t[mid];
            }
        }

        return count;
    }

    public bool isMid(int[] nums, int k)
    {
        Array.Sort(nums);
        int mid = nums.Length / 2;
        if (nums.Length % 2 == 0)
        {
            int temp = Math.Max(nums[mid - 1], nums[mid]);
            return temp == k;
        }

        return nums[mid] == k;
    }

    // public static void Main()
    // {
    //     Console.WriteLine(GetSmallestString("xaxcd", 4));
    // }
}