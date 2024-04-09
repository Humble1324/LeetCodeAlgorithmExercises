namespace LeetCode.Tools;

public class Tools
{
    public int Search(int[] nums, int target)
    {
        int end = nums.Length - 1;
        int start = 0;
        while (start <= end)
        {
            var temp = start + (end - start) / 2;
            if (nums[temp] > target)
            {
                end = temp - 1;
            }
            else if (nums[temp] < target)
            {
                start = temp + 1;
            }
            else return temp;
        }

        return -1;
    }
}