namespace LeetCode.Solution;

public partial class Solution
{
    public string DefangIPaddr(string address) {
        return address.Replace(".","[.]");
    }
}