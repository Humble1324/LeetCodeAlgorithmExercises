namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public ListNode AddTwoNumbersII(ListNode l1, ListNode l2)
    {
        ReverseNode(l1);
        ReverseNode(l2);
        var carry = 0;
        ListNode head = null, cur = null;
        while (l1 != null || l2 != null)
        {
            var n1 = l1 == null ? 0 : l1.val;
            var n2 = l2 == null ? 0 : l2.val;
            var sum = n1 + n2 + carry;
            if (head == null)
            {
                head = cur = new ListNode(sum % 10);
            }
            else
            {
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
            }

            carry = sum / 10;
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        if (carry != 0) cur.next = new ListNode(carry);
        return head;
    }

    public ListNode ReverseNode(ListNode head)
    {
        var temp = head;
        ListNode pre = null;
        while (temp.next != null)
        {
            var tempnext = temp.next;
            temp.next = pre;
            pre.next = temp;
            temp = tempnext;
        }

        return pre;
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode pre = null;
        var temp = head;
        while (temp != null)
        {
            var tempnext = temp.next; //记录下一个节点的地址
            temp.next = pre; //使当前节点的next指向上一个节点
            pre = temp; //记录当前节点作为下次循环的上一个节点
            temp = tempnext; //向后遍历一个节点
        }

        return pre;
    }
}