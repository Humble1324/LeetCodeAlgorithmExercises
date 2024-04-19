namespace LeetCode.DailyCode;

public partial class DailyCode 
{
    public int FindChampion(int[][] grid)
    {
        int ans = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            //如果可以打赢当前的，就接着看有没有人可以打赢他，没有则就是他
            if (grid[i][ans] == 1)
            {
                ans = i;
            }
        }
        return ans;
    }
}