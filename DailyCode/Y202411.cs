using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202411
{
    public bool JudgeSquareSum(int c)
    {
        for (int a = 0; a * a <= c / 2; a++)
        {
            int b = (int)Math.Sqrt(c - a * a);
            if (a * a + b * b == c)
            {
                return true;
            }
        }

        return false;
    }

    public string LosingPlayer(int x, int y)
    {
        bool flag = false;
        while (x > 0 && y > 4)
        {
            x -= 1;
            y -= 4;
            flag = !flag;
        }

        return flag ? "Alice" : "Bob";
    }

    public static int[] ResultsArray(int[] nums, int k)
    {
        int[] ans = new int[nums.Length - k + 1];
        Array.Fill(ans, -1);
        int cnt = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            cnt = i == 0 || nums[i] == nums[i - 1] + 1 ? cnt + 1 : 1;

            //当前格子符合连续上升时,连续值+1,不符合则重置,当连续值超过k时,代表前k个符合连续上升,因为连续上升所以nums[i]就是最大值,存入ans
            if (cnt >= k)
            {
                ans[i - k + 1] = nums[i];
            }
        }

        return ans;
    }

    public int MaxSubArray(int[] nums)
    {
        int ans = int.MinValue;
        int[] dp = new int[nums.Length + 1];
        for (int i = 1; i < nums.Length + 1; i++)
        {
            dp[i] = nums[i - 1];
            if (i > 1 && dp[i - 1] > 0)
            {
                dp[i] += dp[i - 1];
            }
        }

        for (var index = 1; index < dp.Length; index++)
        {
            var t = dp[index];
            ans = Math.Max(ans, t);
        }

        return ans;
    }

    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1) return intervals;
        List<int[]> ans = new List<int[]>();

        //Array.Sort(intervals, (a, b)=>a[0].CompareTo(b[0]));
        intervals = intervals.OrderBy(a => a[0]).ToArray();
        ans.Add(intervals[0]);
        int cnt = 0;
        for (var i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= ans[cnt][1])
            {
                ans[cnt][1] = Math.Max(intervals[i][1], ans[cnt][1]);
            }
            else
            {
                cnt++;
                ans.Add(intervals[i]);
            }
        }

        return ans.ToArray();
    }

    public static void Rotate(int[] nums, int k)
    {
        int lens = nums.Length;
        // 避免k超出数组长度
        k = k % lens;
        // 创建一个临时数组
        int[] temp = new int[lens];

        // 将数组的后k个元素移到前面
        for (int i = 0; i < lens; i++)
        {
            temp[(i + k) % lens] = nums[i]; // 计算新的位置
        }

        nums = temp;
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int lens = nums.Length, pre = 1;
        int[] suf = new int[lens];
        suf[lens - 1] = 1;
        for (int i = lens - 2; i >= 0; i--)
        {
            suf[i] = suf[i + 1] * nums[i + 1];
        }

        for (int i = 0; i < lens; i++)
        {
            suf[i] = pre * suf[i];
            pre *= nums[i];
        }

        return suf;
    }

    public void SetZeroes(int[][] matrix)
    {
        bool isFirstRowHasZero = false;
        bool isFirstColumnHasZero = false;
        for (int row = 0; row < matrix.Length; row++)
        {
            if (matrix[row][0] == 0)
            {
                isFirstColumnHasZero = true;
            }
        }

        for (int col = 0; col < matrix[0].Length; col++)
        {
            if (matrix[0][col] == 0)
            {
                isFirstRowHasZero = true;
            }
        }

        for (int row = 1; row < matrix.Length; row++)
        {
            for (int col = 1; col < matrix[0].Length; col++)
            {
                if (matrix[row][col] != 0) continue;
                matrix[row][0] = 0;
                matrix[0][col] = 0;
            }
        }

        for (int row = 1; row < matrix.Length; row++)
        {
            for (int col = 1; col < matrix[0].Length; col++)
            {
                if (matrix[row][0] == 0 || matrix[0][col] == 0)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        if (isFirstColumnHasZero) SetLineZeroes(matrix, false, 0);
        if (isFirstRowHasZero) SetLineZeroes(matrix, true, 0);
    }

    private void SetLineZeroes(int[][] matrix, bool isRow, int lineIndex, int statIndex = 0)
    {
        if (isRow)
        {
            for (int j = statIndex; j < matrix[0].Length; j++)
            {
                matrix[lineIndex][j] = 0;
            }
        }
        else
        {
            for (int i = statIndex; i < matrix.Length; i++)
            {
                matrix[i][lineIndex] = 0;
            }
        }
    }

    public DailyCode.ListNode GetIntersectionNode(DailyCode.ListNode headA, DailyCode.ListNode headB)
    {
        var headANode = headA;
        var headBNode = headB;
        int lensA = 0, lensB = 0;
        while (headANode != null)
        {
            lensA++;
            headANode = headANode.next;
        }

        while (headBNode != null)
        {
            lensB++;
            headBNode = headBNode.next;
        }

        if (lensA > lensB)
        {
            for (var i = 0; i < lensA - lensB; i++)
            {
                headA = headA.next;
            }
        }
        else if (lensB > lensA)
        {
            for (var i = 0; i < lensB - lensA; i++)
            {
                headB = headB.next;
            }
        }

        while (headA != null && headB != null)
        {
            if (headA == headB)
            {
                return headA;
            }

            headA = headA.next;
            headB = headB.next;
        }

        return null;
    }

    List<int> result = new List<int>();

    public IList<int> InorderTraversal(TreeNode root)
    {
        if (root == null) return result;
        InorderTraversal(root.left);
        result.Add(root.val);
        InorderTraversal(root.right);
        return result;
    }

    public int CountKConstraintSubstrings(string s, int k)
    {
        int cnt = 0, index = 0, lens = s.Length;
        while (index < lens)
        {
            int tempIndex = index;
            int tempCntA = 0, tempCntB = 0;
            while (tempIndex < lens && (tempCntA <= k || tempCntB <= k))
            {
                if (s[tempIndex] == '0')
                {
                    tempCntA++;
                }
                else
                {
                    tempCntB++;
                }

                cnt++;
                tempIndex++;
            }
        }

        return cnt;
    }

    public int[][] ImageSmoother(int[][] img)
    {
        int m = img.Length, n = img[0].Length;
        int[][] ret = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ret[i] = new int[n];
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int temp = 0;
                int count = 0;
                for (int x = -1; x < 1; x++)
                {
                    for (int y = -1; y < 1; y++)
                    {
                        if (i + x < 0 || i + x > m || j + y < 0 || j + y > m)
                        {
                            continue;
                        }

                        count++;
                        temp += img[x + i][y + j];
                    }
                }

                ret[i][j] = (int)Math.Floor(temp / count * 1.0f);
            }
        }

        return ret;
    }

    public int FinalPositionOfSnake(int n, IList<string> commands)
    {
        int[] ans = new[] { 0, 0 };
        foreach (var command in commands)
        {
            switch (command)
            {
                case "UP":
                    ans[0]--;
                    break;
                case "DOWN":
                    ans[0]++;
                    break;
                case "LEFT":
                    ans[1]--;
                    break;
                case "RIGHT":
                    ans[1]++;
                    break;
            }
        }

        int result = ans[0] * n + ans[1] % n;

        return result;
    }

    public int NumberOfAlternatingGroups(int[] colors)
    {
        int ans = 0;
        int lens = colors.Length;
        for (var i = 0; i < lens; i++)
        {
            int pre = 0;
            int next = 0;
            if (i == 0)
            {
                pre = colors[lens - 1];
                next = colors[i + 1];
            }
            else if (i == lens - 1)
            {
                pre = colors[i - 1];
                next = colors[0];
            }
            else
            {
                pre = colors[i - 1];
                next = colors[i + 1];
            }

            if (pre == next && pre != colors[i])
            {
                ans++;
            }
        }

        return ans;
    }
    // public IList<IList<int>> Permute(int[] nums)
    // {
    //     List<IList<int>> ans = new List<IList<int>>();
    //     
    //     return ans;
    // }
    // private 
    // public static void Main(string[] args)
    // {
    //     SetZeroes(new int[][] { new int[] { 0, 1, 2, 0 }, new int[] { 3, 4, 5, 2 }, new int[] { 1, 3, 1, 5 } });
    // }
}