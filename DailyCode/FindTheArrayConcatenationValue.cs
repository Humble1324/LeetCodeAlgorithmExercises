namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public long FindTheArrayConcVal(int[] nums)
    {
        long temp = 0;
        int lens = nums.Length;
        for (int i = 0; i <lens / 2; i++)
        {
            temp += long.Parse(nums[i].ToString() + nums[lens-i-1]);
        }

        if (lens % 2 != 0) temp += nums[lens / 2];
        return temp;
    }
}