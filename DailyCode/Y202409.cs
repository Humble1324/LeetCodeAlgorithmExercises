using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.DailyCode;

public class Y202409
{
    public long MaxStrength(int[] nums)
    {
        long ans = 1;
        int negativeCount = 0, zeroCount = 0, positiveCount = 0;
        int temp = -9;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                negativeCount++;
                ans *= nums[i];
                temp = Math.Max(temp, nums[i]);
            }
            else if (nums[i] == 0)
            {
                zeroCount++;
            }
            else
            {
                ans *= nums[i];
                positiveCount++;
            }
        }

        if (negativeCount == 1 && zeroCount == 0 && positiveCount == 0)
        {
            return nums[0];
        }

        if (negativeCount <= 1 && positiveCount == 0)
        {
            return 0;
        }

        if (ans < 0)
        {
            return ans / temp;
        }
        else
        {
            return ans;
        }
    }

    public int CountWays(IList<int> nums)
    {
        int lens = nums.Count;
        int res = 0;
        ((List<int>)nums).Sort();
        for (int k = 0; k <= lens; k++)
        {
            //前半段小于k
            if (k > 0 && nums[k - 1] >= k)
            {
                continue;
            }

            //后半段大于k
            if (k < lens && nums[k] <= k)
            {
                continue;
            }

            res++;
        }

        return res;
    }

    // public static string ClearDigits(string s)
    // {
    //     int count = 0;
    //     foreach (var c in s)
    //     {
    //         if (c >= '0' && c <= '9')
    //         {
    //             count++;
    //         }
    //     }
    //     if (count == 0)
    //     {
    //         return s;
    //     }
    //     StringBuilder ans = new StringBuilder(s);
    //     int num = 0;
    //     while (num < s.Length && (s[num] < '0' || s[num] > '9'))
    //     {
    //         num++;
    //     }
    //     ans.Remove(num, 1);
    //     int left = num - 1;
    //     ans.Remove(left, 1);
    //     return ClearDigits(ans.ToString());
    // }
    public string ClearDigits(string s)
    {
        StringBuilder ans = new StringBuilder();

        int index = 0;
        foreach (var c in s)
        {
            if (Char.IsDigit(c))
            {
                ans.Remove(ans.Length - 1, 1);
            }
            else
            {
                ans.Append(c);
            }
        }

        return ans.ToString();
    }

    public DailyCode.ListNode MergeNodes(DailyCode.ListNode head)
    {
        var slowNode = head;
        var fastNode = head.next;
        while (fastNode != null)
        {
            int count = 0;
            while (fastNode.val != 0)
            {
                count += fastNode.val;
                fastNode = fastNode.next;
            }

            fastNode = fastNode.next;
            slowNode.next.val = count;
            slowNode = slowNode.next;
        }

        slowNode.next = null;
        
        //太久没做类似题目了 忘记可以跳过开头QAQ
        return head.next;
    }
    // public static void Main()
    // {
    //     Console.Write(MergeNodes("abc"));
    // }
}