using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DailyCode;

public class Y202408
{
    public int MaxmiumScore(int[] cards, int cnt)
    {
        Array.Sort(cards);

        int ans = 0;
        int tmp = 0;
        int odd = -1, even = -1;
        int end = cards.Length - cnt;
        for (int i = cards.Length - 1; i >= end; i--)
        {
            tmp += cards[i];
            if ((cards[i] & 1) != 0)
            {
                odd = cards[i];
            }
            else
            {
                even = cards[i];
            }
        }

        if ((tmp & 1) == 0)
        {
            return tmp;
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) != 0)
            {
                if (even != -1)
                {
                    ans = Math.Max(ans, tmp - even + cards[i]);
                    break;
                }
            }
        }

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) == 0)
            {
                if (odd != -1)
                {
                    ans = Math.Max(ans, tmp - odd + cards[i]);
                    break;
                }
            }
        }

        return ans;
    }

    public static long NumberOfRightTriangles(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] col = new int[n];
        long ans = 0;
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                col[j] += grid[i][j];
            }
        }

        for (var i = 0; i < m; i++)
        {
            int row = grid[i].Sum();
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    ans += ((row - 1) * (col[j] - 1));
                }
            }
        }

        return ans;
    }

    public class MagicDictionary
    {
        public HashSet<string> magicHash;

        public MagicDictionary()
        {
            magicHash = new HashSet<string>();
        }

        public void BuildDict(string[] dictionary)
        {
            foreach (var s in dictionary)
            {
                magicHash.Add(s);
            }
        }

        public bool Search(string searchWord)
        {
            var lens = searchWord.Length;
            foreach (var s in magicHash)
            {
                if (s.Length != lens)
                {
                    continue;
                }

                int temp = 0;
                for (int index = 0; index < lens;)
                {
                    while (index < lens && s[index] == searchWord[index])
                    {
                        index++;
                    }


                    if (index < lens && s[index] != searchWord[index])
                    {
                        temp++;
                        index++;
                    }

                    if (index == lens && temp == 1)
                    {
                        return true;
                    }

                    if (index >= lens || temp != 1)
                    {
                        break;
                    }
                }
            }

            return false;
        }

        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            List<bool> ans = new List<bool>();
            List<bool> numsBool = new();
            if (nums.Length == 1)
            {
                numsBool.Add(true);
            }

            else
            {
                for (var i = 1; i < nums.Length; i++)
                {
                    numsBool.Add(nums[i - 1] % 2 != nums[i] % 2);
                }
            }

            foreach (var query in queries)
            {
                int left = query[0];
                int right = query[1];
                if (left == right)
                {
                    ans.Add(true);
                }
                else
                {
                    while (left < right - 1 && numsBool[left])
                    {
                        left++;
                    }

                    ans.Add(numsBool[left]);
                }
            }

            return ans.ToArray();
        }
    }

    public static bool CheckRecord(string s)
    {
        int absentCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'A')
            {
                absentCount++;
                if (absentCount > 1)
                {
                    return false;
                }
            }

            int lateCount = 0;
            if (i < s.Length && s[i] == 'L')
            {
                while (i < s.Length && s[i] == 'L')
                {
                    lateCount++;
                    i++;
                    if (lateCount >= 3)
                    {
                        return false;
                    }
                }

                i--;
            }
        }

        return true;
    }

//
// public static bool IsLegal(int x, int y, int val)
// {
//     if (m == 0 || n == 0)
//     {
//         return false;
//     }
//
//     return x < n && y < m && x >= 0 && y >= 0 && val == 1;
// }
    // public static void Main()
    // {
    //     Console.WriteLine(CheckRecord("ALLAPPL"));
    // }

    public int GetImportance(IList<Employee> employees, int id)
    {
        int count = 0;
        Stack<Employee> stack = new Stack<Employee>();
        stack.Push(GetEmployeeID(employees, id));

        while (stack.Count > 0)
        {
            var temp = stack.Pop();
            var subordinatesList = temp.subordinates;
            foreach (var i in subordinatesList)
            {
                stack.Push(GetEmployeeID(employees, i));
            }

            count += temp.importance;
        }

        return count;
    }

    public Employee GetEmployeeID(IList<Employee> employees, int id)
    {
        foreach (var employee in employees)
        {
            if (employee.id == id)
            {
                return employee;
            }
        }

        return null;
    }

    public bool SatisfiesConditions(int[][] grid)
    {
        int x = grid[0].Length;
        int y = grid.Length;

        for (var i = 0; i < y; i++)
        {
            for (var j = 0; j < x; j++)
            {
                if (i + 1 < y)
                {
                    if (grid[i][j] != grid[i + 1][j])
                    {
                        return false;
                    }
                }

                if (j + 1 < x)
                {
                    if (grid[i][j] == grid[i][j + 1])
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public static long SumDigitDifferences(int[] nums)
    {
        long ans = 0;
        int length = nums[0].ToString().Length;
        int[,] cnt = new int[length, 10];
        for (int i = 0; i < nums.Length; i++)
        {
            int x = nums[i];
            for (int j = 0; x > 0; x /= 10, j++)
            {
                ans += i - cnt[j, x % 10]++;
            }
        }
        return ans;
    }

    // public static void Main()
    // {
    //     Console.WriteLine(SumDigitDifferences(new []{37,71,56,36,96,35,37,65,50,55}));
    // }
}

public class Employee
{
    public int id;
    public int importance;
    public IList<int> subordinates;
}