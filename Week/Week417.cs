using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Solution;

public class Week417
{
    public static char KthCharacter(int k)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('a');
        while (sb.Length < k)
        {
            var temp = sb.Length;
            for (var i = 0; i < temp; i++)
            {
                if (sb[i] == 'z')
                {
                    sb.Append('a');
                }
                else
                {
                    sb.Append((char)(sb[i] + 1));
                }
            }
        }

        return sb[k];
    }

    public static long CountOfSubstrings(string word, int k)
    {
        long ans = 0;
        int slow = 0, fast = 0, lens = word.Length, voewlCount = 0;
        Dictionary<char, int> vowelDic = new Dictionary<char, int>()
            { { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 } };
        int containingCount = 0;

        for (fast = 0; fast < lens; fast++)
        {
            if (vowelDic.ContainsKey(word[fast]))
            {
                if (vowelDic[word[fast]] == 0)
                {
                    voewlCount++;
                }

                vowelDic[word[fast]]++;
            }
            else
            {
                containingCount++;
            }

            while (containingCount > k)
            {
                if (vowelDic.ContainsKey(word[slow]))
                {
                    vowelDic[word[slow]]--;
                    if (vowelDic[word[slow]] == 0)
                    {
                        voewlCount--;
                    }
                }
                else
                {
                    containingCount--;
                }

                slow++;
            }
            if (voewlCount == 5 && containingCount == k)
            {
                if (vowelDic.ContainsKey(word[slow]))
                {
                    vowelDic[word[slow]]--;
                    if (vowelDic[word[slow]] == 0)
                    {
                        voewlCount--;
                    }
                }
                else
                {
                    containingCount--;
                }

                slow++;
            }
        }

        return ans;
    }
    public int MinSubArrayLen(int target, int[] nums)
    {
        int ans = int.MaxValue,slow=0,fast=0,lens=nums.Length;
        for (slow = 0; slow < lens; slow++)
        {
            int tempCount = 0;
            while (fast < lens && tempCount < target)
            {
                fast++;
                tempCount += nums[fast];
            }

            ans = Math.Max(ans, fast - slow);
            while (tempCount > 7)
            {
                tempCount -= nums[slow++];
            }
        }
        
        return ans;
    }
    // public static void Main(string[] args)
    // {
    //     Console.Write(CountOfSubstrings("iqeaouqi", 2));
    // }
}