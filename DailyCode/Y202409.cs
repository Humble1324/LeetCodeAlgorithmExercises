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

    public static int MaximizeWin(int[] prizePositions, int k)
    {
        int lens = prizePositions.Length;
        int ans = 0;
        int[] dp = new int[lens + 1];
        for (int left = 0, right = 0; right < lens; right++)
        {
            while (prizePositions[right] - prizePositions[left] > k)
            {
                left++;
            }

            ans = Math.Max(ans, right - left + 1 + dp[left]);
            dp[right + 1] = Math.Max(dp[right], right - left + 1);
        }

        return ans;
    }

    public int MaxSubArray(int[] nums)
    {
        int ans = int.MinValue;
        int lens = nums.Length + 1;
        int[] dp = new int[lens];
        for (int i = 1; i < lens; i++)
        {
            dp[i] = nums[i - 1];
            if (i > 1 && dp[i - 1] > 0)
            {
                dp[i] += dp[i - 1];
            }
        }

        for (int i = 1; i < lens; i++)
        {
            ans = Math.Max(ans, dp[i]);
        }

        return ans;
    }

    public static int MaxNumOfMarkedIndices(int[] nums)
    {
        int count = 0;
        Array.Sort(nums);
        int lens = nums.Length;
        if (lens == 1)
        {
            return 0;
        }

        int half = lens / 2;
        int firstKey = -1;
        int slow = 0, fast = half;
        while (fast < lens && slow < half)
        {
            while (nums[fast] < nums[slow] * 2 && fast < lens)
            {
                fast++;
            }

            if (fast < lens)
            {
                count += 2;
                fast++;
            }

            slow++;
        }

        return count;
    }

    public static int[] DivisibilityArray(string word, int m)
    {
        int[] ans = new int[word.Length];
        long temp = 0;
        for (var i = 0; i < word.Length; i++)
        {
            temp = (temp * 10 + int.Parse(word[i].ToString()));
            if (temp % m == 0)
            {
                ans[i] = 1;
            }
        }

        return ans.ToArray();
    }

    public int[] LeftRightDifference(int[] nums)
    {
        int lens = nums.Length;
        int[] ans = new int[lens];
        int sumR = nums.Sum();
        int sumL = nums[0];
        for (var i = 0; i < lens; i++)
        {
            if (i == 0)
            {
                ans[i] = sumR - nums[i];
                sumR -= nums[i];
            }
            else
            {
                ans[i] = Math.Abs(sumL + nums[i - 1] - sumR);
                sumR += nums[i];
                sumL -= nums[i];
            }
        }

        return ans;
    }

    public string RemoveStars(string s)
    {
        Stack<char> ans = new Stack<char>();

        foreach (var c in s)
        {
            if (c != '*')
            {
                ans.Push(c);
            }
            else
            {
                ans.Pop();
            }
        }

        char[] returnStars = new char[ans.Count];
        int index = ans.Count - 1;
        while (ans.Count > 0)
        {
            returnStars[index--] = ans.Pop();
        }


        return new string(returnStars);
    }

    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
        int pos = 0;
        int space = 0;
        Array.Sort(buses);
        Array.Sort(passengers);
        foreach (var bus in buses)
        {
            space = capacity;
            while (space > 0 && pos < passengers.Length && passengers[pos] <= bus)
            {
                space--;
                pos++;
            }
        }

        pos--;
        int lastCatchTime = space > 0 ? buses[buses.Length - 1] : passengers[pos];
        while (pos >= 0 && passengers[pos] == lastCatchTime)
        {
            pos--;
            lastCatchTime--;
        }

        return lastCatchTime;
    }

    public static int LongestContinuousSubstring(string s)
    {
        // int maxCount = 1;
        // int temp = s[0];
        // for (var i = 1; i < s.Length; i++)
        // {
        //     int tempCount = 1;
        //     temp = s[i];
        //     while(i < s.Length&&s[i] - 1 == temp)
        //     {
        //         tempCount++;
        //         temp = s[i];
        //         i++;
        //     }
        //     
        //     maxCount = Math.Max(maxCount, tempCount);
        // }
        // return maxCount;

        int ans = 1, count = 1;
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1] + 1)
            {
                count++;
                ans = Math.Max(ans, count);
            }
            else
            {
                count = 1;
            }
        }

        return ans;
    }

    public int MaxScoreSightseeingPair(int[] values)
    {
        int ans = 0;
        int max = values[0] + 0;
        for (var i = 1; i < values.Length; i++)
        {
            //找当前最大值
            ans = Math.Max(ans, max + values[i] - i);

            //对比左侧谁更大
            max = Math.Max(max, values[i] + i);
        }

        return ans;
    }

    public long MaximumSubsequenceCount(string text, string pattern)
    {
        //思路在最大子序列一定是两边接近一致的,所以给字符少的加一,体现在加一后再加一次对方全部数量
        long ans = 0;
        int countA = 0, countB = 0;
        for (var i = 0; i < text.Length; i++)
        {
            if (text[i] == pattern[1])
            {
                countB++;
                ans += countA;
            }
            if (text[i] == pattern[0])
            {
                countA++;
            }
        }

        return ans + Math.Max(countB, countA);
    }
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        int ans = 0;
        for (var i = 0; i < tickets.Length; i++)
        {
            if (i < k)
            {
                ans += tickets[i] > tickets[k] ? tickets[i] : tickets[k];
            }

            if (i > k)
            {
                ans += tickets[i] > tickets[k]-1 ? tickets[k]-1 : tickets[i];
            }
            if(i==k){
                ans+=tickets[k];
            }
        }

        return ans;
    }
    public bool ReportSpam(string[] message, string[] bannedWords)
    {
        int count = 0;
        HashSet<string> stringHash = new HashSet<string>();
        foreach (var bannedWord in bannedWords)
        {
            stringHash.Add(bannedWord);
        }
        foreach (var s in message)
        {
            if (stringHash.Contains(s))
            {
                count++;
                
            }
            if (count >= 2)
            {
                return true;
            }
        }

        return false;
    }
    public class SeatManager
    {
        private int[] seats;
        private int minSeat = int.MaxValue;
        public SeatManager(int n)
        {
            seats = new int[n + 1];
        }
    
        // public int Reserve()
        // {
        //     var t = FindMinReserve();
        //     seats[t - 1] = 1;
        //
        //     return -1;
        // }
    
        public void Unreserve(int seatNumber)
        {
            seats[seatNumber] = 0;
        }


    }

    // public static void Main()
    // {
    //     string t = "pcfftiovoygwwncfgews";
    //     foreach (var c in t)
    //     {
    //         Console.Write((int)c+" ");
    //     }
    //     Console.WriteLine(LongestContinuousSubstring("pcfftiovoygwwncfgews"));
    // }
}