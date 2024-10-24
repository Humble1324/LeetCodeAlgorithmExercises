using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.DailyCode;

public class Y202410
{
    public string DestCity(IList<IList<string>> paths)
    {
        HashSet<string> startingCities = new HashSet<string>();
        Dictionary<string, string> pathsMap = new Dictionary<string, string>();

        // 构建起始城市和路径映射
        foreach (var path in paths)
        {
            startingCities.Add(path[0]); // 记录所有起始城市
            pathsMap[path[0]] = path[1]; // 记录路径
        }

        // 遍历路径，找到不在起始城市集合中的终点城市
        foreach (var startCity in pathsMap.Keys)
        {
            var endCity = pathsMap[startCity];
            if (!startingCities.Contains(endCity)) // 检查终点城市是否为有效终点
            {
                return endCity; // 返回终点城市
            }
        }

        return string.Empty; // 理论上不会到达这里
    }

    public long NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        long ans = 0;
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        for (var index = 0; index < nums1.Length; index++)
        {
            if (nums1[index] % k != 0) continue;
            nums1[index] /= k;
            for (int d = 1; d * d <= nums1[index]; d++)
            {
                if (nums1[index] % d != 0)
                {
                    continue;
                }

                cnt[d]++;
                if (d * d < nums1[index])
                {
                    cnt[nums1[index] / d]++;
                }
            }
        }

        foreach (var i in nums2)
        {
            ans += cnt.ContainsKey(i) ? cnt[i] : 0;
        }

        return ans;
    }

    public int MaxHeightOfTriangle(int red, int blue)
    {
        int tempCount = 0;

        int tempRed = red;
        int tempBlue = blue;
        int tempA = 1;
        int tempB = 2;
        while (red >= 0 && blue >= 0)
        {
            if (red >= tempA)
            {
                red -= tempA;
                tempA += 2;
                tempCount++;
            }
            else
            {
                break;
            }

            if (blue >= tempB)
            {
                blue -= tempB;
                tempB += 2;
                tempCount++;
            }
            else
            {
                break;
            }
        }

        int tempCountB = 0;
        tempA = 2;
        tempB = 1;
        red = tempRed;
        blue = tempBlue;
        while (red >= 0 && blue >= 0)
        {
            if (blue >= tempB)
            {
                blue -= tempB;
                tempB += 2;
                tempCountB++;
            }
            else
            {
                break;
            }

            if (red >= tempA)
            {
                red -= tempA;
                tempA += 2;
                tempCountB++;
            }
            else
            {
                break;
            }
        }

        return Math.Max(tempCount, tempCountB);
    }

    public double MinimumAverage(int[] nums)
    {
        double ans = int.MaxValue;
        Array.Sort(nums);
        int lens = nums.Length, fast = lens - 1, slow = 0;
        while (fast > slow)
        {
            double temp = (nums[slow] + nums[fast]) / 2.0f;
            ans = Math.Min(temp, ans);
            slow++;
            fast--;
        }

        return ans;
    }

    public int MinOperations(int[] nums)
    {
        int ans = 0;
        int lens = nums.Length;
        for (var i = 0; i < lens; i++)
        {
            if (nums[i] == 0 && i < lens - 2)
            {
                nums[i] = nums[i] == 0 ? 1 : 0;
                nums[i + 1] = nums[i + 1] == 0 ? 1 : 0;
                nums[i + 2] = nums[i + 2] == 0 ? 1 : 0;
                ans++;
            }
        }

        if (nums.Any(t => t == 0))
        {
            return -1;
        }

        return ans > 0 ? ans : -1;
    }

    public int SmallestRangeI(int[] nums, int k)
    {
        int ans = 0;
        var min = nums.Min();
        var max = nums.Max();
        ans = (max - min) - 2 * k;
        return ans >= 0 ? ans : 0;
    }

    public int SmallestRangeII(int[] nums, int k)
    {
        Array.Sort(nums);
        int min = nums[0], max = nums[nums.Length - 1], ans = max - min;
        for (int i = 0; i < nums.Length; i++)
        {
            int a = nums[i];
            int b = nums[i + 1];
            ans = Math.Min(ans, Math.Max(max - k, a + k) - Math.Min(min + k, b - k));
        }

        return ans;
    }

    public static long CountCompleteDayPairs(int[] hours)
    {
        long ans = 0, lens = hours.Length;
        int[] cnt = new int[24];
        foreach (var hour in hours)
        {
            ans += cnt[(24 - hour % 24) % 24];
            cnt[hour % 24]++;
        }

        return ans;
    }

    public static int FindWinningPlayer(int[] skills, int k)
    {
        int maxIndex = 0, win = 0, lens = skills.Length;
        for (int i = 1; i < lens && win < k; i++)
        {
            if (skills[i] > skills[maxIndex])
            {
                maxIndex = i;
                win = 0;
            }

            win++;
        }

        return maxIndex;
    }

    public int GetWinner(int[] arr, int k)
    {
        int maxIndex = 0, win = 0, lens = arr.Length;
        for (int i = 1; i < lens && win < k; i++)
        {
            if (arr[i] > arr[maxIndex])
            {
                maxIndex = i;
                win = 0;
            }

            win++;
        }

        return arr[maxIndex];
    }

    // }    public static long CountCompleteDayPairs(int[] hours)
    // {
    //     long ans = 0, lens = hours.Length;
    //     Dictionary<int, int> dic = new();
    //     for (var i = 0; i < lens; i++)
    //     {
    //         var temp = (24 - (hours[i]) % 24);
    //         //单独处理0 12 24
    //         if (hours[i] % 24 == 0)
    //         {
    //             if (dic.TryGetValue(0, out var value))
    //             {
    //                 ans += value;
    //             }
    //         }
    //         //如果前面有对应的就加
    //         else if (dic.TryGetValue(temp, out var value1))
    //         {
    //             ans += value1;
    //         }
    //         
    //         //没有就把当前这个加进匹配库
    //         if (dic.ContainsKey(hours[i] % 24))
    //         {
    //             dic[hours[i] % 24]++;
    //         }
    //         else
    //         {
    //             dic.Add(hours[i] % 24, 1);
    //         }
    //     }
    //     return ans;
    // }

    public static void Main(string[] args)
    {
        FindWinningPlayer(new int[] { 7, 11 }, 2);
    }
}