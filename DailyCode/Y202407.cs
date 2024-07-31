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

        if (indexFR < lens - 1 && sortNum[indexFR] == '5')
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

        if (indexZR < lens - 1 && sortNum[indexZR] == '0')
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
            else if (sortNum[indexZR] == '0')
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

    public int FindValueOfPartition(int[] nums)
    {
        int lens = nums.Length;
        var sortedNums = new int[lens];
        sortedNums = nums;
        Array.Sort(sortedNums);
        int left = 0, right = 1;
        int ans = int.MaxValue;
        while (left < right && right < lens)
        {
            ans = Math.Min(ans, (sortedNums[right++] - sortedNums[left++]));
        }

        return ans;
    }

    public static int CalPoints(string[] operations)
    {
        int ans = 0;
        Stack<int> ops = new();
        int index = 0;
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case "C":
                    ops.Pop();
                    index -= 2;
                    break;
                case "D":
                    ops.Push(ops.Peek() * 2);
                    break;
                case "+":
                    var t = ops.Pop();
                    var tt = t + ops.Peek();
                    ops.Push(t);
                    ops.Push(tt);
                    break;
                default:
                    var c = int.Parse(operation);
                    ops.Push(c);
                    break;
            }

            index++;
        }

        foreach (var op in ops)
        {
            ans += op;
        }

        return ans;
    }

    public IList<int> GetGoodIndices(int[][] variables, int target)
    {
        int lens = variables.Length;
        List<int> ans = new List<int>();
        for (var i = 0; i < lens; i++)
        {
            var t = variables[i];
            if (pow(pow(t[0], t[1], 10), t[2], t[3]) == target)
            {
                ans.Add(i);
            }
        }

        return ans;
    }

    public int pow(int x, int n, int mod)
    {
        int res = 1;
        while (n > 0)
        {
            if (n % 2 > 0)
            {
                res *= x % mod;
            }

            x = x * x % mod;
            n /= 2;
        }

        return res;
    }

    public static int MinRectanglesToCoverPoints(int[][] points, int w)
    {
        int ans = 0;
        //按照x坐标排序,再根据w宽度进行分组,在w内的为一个长方形,超出就加一个
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
        int lens = points.Length;
        for (var i = 0; i < lens;)
        {
            int index = i;
            int temp = points[index][0];
            while (index < lens && temp == points[index][0])index++;//无视一列的
            while (index < lens && points[index][0] - temp <= w) index++;
            ans++;
            i = index;
        }

        return ans;
    }
     // public static void Main()
     // {
     //     MinRectanglesToCoverPoints(new int[][] { new int[] { 2,1},new int[]{1,0},new int[]{1,4},new int[]{1,8},new int[]{3,5},new int[]{4,6}}, 1);
     // }
}