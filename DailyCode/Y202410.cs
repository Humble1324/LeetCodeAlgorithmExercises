using System;
using System.Collections.Generic;

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
            }else{break;}

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
}