namespace LeetCode.DailyCode;

public partial class DailyCode
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = null,cur = null;
        int carry=0;
        while(l1!=null||l2!=null){
            int n1 = l1!=null?l1.val:0;
            int n2 = l2!=null?l2.val:0;
            int sum = n1+n2+carry;
            if(head==null){
                head = cur = new ListNode(sum%10);
            }else {
                cur.next = new ListNode(sum%10);
                cur = cur.next;
            }
            carry = sum/10;
            if(l1!=null){
                l1 =l1.next;
            }
            if(l2!=null){
                l2 =l2.next;
            }
        }
        if(carry!=0){
            cur.next = new ListNode(carry); 
        }
        return head;
    }

    public class ListNode {
         public int val;
             public ListNode next;
             public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
             }
     }
}