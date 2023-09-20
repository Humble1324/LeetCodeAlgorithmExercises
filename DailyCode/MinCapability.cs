using System.Linq;

public partial class DailyCode
{
    public class Solution {
        public int MinCapability(int[] nums, int k) {
            int lower = nums.Min();
            int upper = nums.Max();
            while (lower <= upper) {
                int middle = (lower + upper) / 2;
                int count = 0;
                bool visited = false;
                foreach (int x in nums) {
                    if (x <= middle && !visited) {
                        count++;
                        visited = true;
                    } else {
                        visited = false;
                    }
                }
                if (count >= k) {
                    upper = middle - 1;
                } else {
                    lower = middle + 1;
                }
            }
            return lower;
        }
    }

}