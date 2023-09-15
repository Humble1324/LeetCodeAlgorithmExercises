namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int SubtractProductAndSum(int n)
    {
        var product = 1;
        var sum = 0;
        while (n > 0)
        {
            var temp = n % 10;
            product *= temp;
            sum += temp;
            n /= 10;
        }

        return product - sum;
    }
}