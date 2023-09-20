namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int MinCount(int[] coins)
    {
        int sum = 0;
        foreach (int coin in coins)
        {
            if (coin % 2 == 0)
            {
                sum += coin / 2;
            }
            else
            {
                sum += ((coin + 1 )/ 2);
            }
        }

        return sum;
    }
}