using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.OneHundredHotProblems;

public class OneHundredHashProblems
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //同源 ascii码相加不够准确,按照字典序重新排序?
        Dictionary<string, List<string>> groupDic = new();
        foreach (var str in strs)
        {
            var t = SortByDic(str);
            if (groupDic.ContainsKey(t))
            {
                groupDic[t].Add(str);
            }
            else
            {
                groupDic.Add(t, new List<string>() { str });
            }
        }

        var ans = new List<IList<string>>();
        foreach (var kvp in groupDic)
        {
            var temp = new List<string>();
            foreach (var s in kvp.Value)
            {
                temp.Add(s);
            }

            ans.Add(temp);
        }

        return ans;
    }

    private string SortByDic(string text)
    {
        List<char> temp = new List<char>(text);
        temp.Sort();
        string s = "";
        foreach (var c in temp)
        {
            s += c;
        }

        return s;
    }

    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> num_set = new HashSet<int>();
        foreach (var num in nums)
        {
            num_set.Add(num);
        }

        int longestStreak = 0;
        foreach (var num in num_set)
        {
            if (!num_set.Contains(num - 1))
            {
                int currentNum = num;
                int currentCount = 1;
                while (num_set.Contains(currentNum + 1))
                {
                    currentCount++;
                    currentNum++;
                }

                longestStreak = Math.Max(longestStreak, currentCount);
            }
        }


        return longestStreak;
    }

    public void MoveZeroes(int[] nums)
    {
        // int fast = 0,slow=0,lens=nums.Length;
        // while (fast < lens)
        // {
        //     if (nums[fast] == 0)
        //     {
        //         slow = fast;
        //         while (fast < lens && nums[fast] == 0)
        //         {
        //             fast++;
        //         }
        //
        //         if (fast < lens)
        //         {
        //             nums[slow] = nums[fast];
        //             nums[fast] = 0;
        //         }
        //     }
        //
        //     fast++;
        // }
        //

        // int zeroCount = 0,lens = nums.Length;
        // for (var i = 0; i < lens; i++)
        // {
        //     if (nums[i] == 0)
        //     {
        //         zeroCount++;
        //     }else if (zeroCount > 0)
        //     {
        //         nums[i - zeroCount] = nums[i];
        //         nums[i] = 0;
        //     }
        // }
        int slow = 0, fast = 0, lens = nums.Length;
        while (fast < lens)
        {
            if (nums[fast] != 0)
            {
                nums[slow] = nums[fast];
                slow++;
            }

            fast++;
        }

        while (slow < lens)
        {
            nums[slow++] = 0;
        }
    }

    public int MaxArea(int[] height)
    {
        int lens = height.Length - 1;
        int left = 0, right = lens;
        int maxArea = 0;
        while (right > left)
        {
            int tempArea = Math.Min(height[left], height[right]) * (right - left);
            maxArea = Math.Max(maxArea, tempArea);
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }

    public static int Trap(int[] height)
    {
        //会超时
        // int ans = 0;
        // int high = height.Max();
        // int weight = height.Length;
        // for (var i = 1; i <= high; i++)
        // {
        //
        //     int temp = -1;
        //     for (var j = 0; j < weight; j++)
        //     {
        //         if (height[j] < i && temp!=-1)
        //         {
        //             temp++;
        //         }
        //
        //         if (height[j] >= i && temp == -1)
        //         {
        //             temp = 0;
        //         }
        //
        //         if (height[j] >= i && temp > 0)
        //         {
        //             ans += temp;
        //             temp = 0;
        //         }
        //     }
        // }
        //
        // return ans;
        int sum = 0;
        int lens = height.Length;
        int[] max_left = new int[lens];
        int[] max_right = new int[lens];
        for (var i = 1; i < lens - 1; i++)
        {
            max_left[i] = Math.Max(max_left[i - 1], height[i]);
        }

        for (var i = lens - 2; i >= 0; i--)
        {
            max_right[i] = Math.Max(max_right[i + 1], height[i]);
        }

        for (var i = 1; i < lens - 1; i++)
        {
            int min = Math.Min(max_left[i], max_right[i]);
            if (min > height[i])
            {
                sum += (min - height[i]);
            }
        }

        return sum;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        int ans = 0;
        HashSet<char> subHash = new HashSet<char>();
        int left = 0, right = 0, lens = s.Length;
        while (right < lens)
        {
            while (subHash.Contains(s[right]))
            {
                subHash.Remove(s[left]);
                left++;
            }
            subHash.Add(s[right]);
            ans = Math.Max(ans, right-left+1);
            right++;
        }

        return ans;
    }

     //
     // public static void Main(string[] args)
     // {
     //     Console.Write(LengthOfLongestSubstring("abcabcbb"));
     // }
}