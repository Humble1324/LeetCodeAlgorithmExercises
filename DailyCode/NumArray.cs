namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public class NumArray
    {
        int[] numarray;

        public NumArray(int[] nums)
        {
            numarray = nums;
        }

        public int SumRange(int left, int right)
        {
            int temp = 0;
            for (int i = left; i <= right; i++)
            {
                temp += numarray[i];
            }

            return temp;
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(left,right);
     */
}