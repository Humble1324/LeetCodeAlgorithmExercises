namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public int SubtractProductAndSum(int n)
    {
        int product = 1;
        int sum = 0;
        while (n>0)
        {
            int temp = n % 10;
            product *= temp;
            sum += temp;
            n /= 10;
        }
        return product-sum;
    }
}