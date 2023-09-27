using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//資料型態是ListNode
//直接在節點(ListNode)上做處理，所以新建的ListNode會做好排序
namespace QuizSolution.Easy
{
    public class SolutionMergeTwoLists
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x, ListNode next = null)
            {
                val = x;
                this.next = next;
            }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
        public string MergeTwoListRecall(int[] List1, int[] List2)
        {
            ListNode Result = null; ListNode node = null; ListNode node2 = null;
            int LengthAandB = List1.Length + List2.Length; int[] ReturnResult = new int[LengthAandB];
            int j = 0;
            for (int i = 0; i < List1.Length; i++)
            {
                if (i <= List1.Length - 1 && List1.Length != 0)
                {
                    node = new ListNode(List1[i]);
                }
                if (i <= List2.Length - 1 && List2.Length != 0)
                {
                    node2 = new ListNode(List2[i]);
                }
                if (node != null && node2 != null)
                {
                    if (node.val <= node2.val)
                    {
                        node.next = MergeTwoLists(node.next, node2);
                        if (j != 0)
                        {
                            if (ReturnResult[j - 1] > node.val)
                            {
                                ReturnResult[j] = ReturnResult[j - 1];
                                ReturnResult[j - 1] = node.val;
                                ReturnResult[j + 1] = node2.val;
                            }
                            else
                            {
                                ReturnResult[j] = node.val;
                                ReturnResult[j + 1] = node2.val;
                            }
                        }
                        else
                        {
                            ReturnResult[j] = node.val;
                            ReturnResult[j + 1] = node.next.val;
                        }
                        j += 2;
                    }
                    else
                    {
                        node2.next = MergeTwoLists(node, node2.next);
                        if (j != 0)
                        {
                            if (ReturnResult[j - 1] > node.val)
                            {
                                ReturnResult[j] = ReturnResult[j - 1];
                                ReturnResult[j - 1] = node2.val;
                                ReturnResult[j + 1] = node.val;
                            }
                            else
                            {
                                ReturnResult[j] = node2.val;
                                ReturnResult[j + 1] = node.val;
                            }
                        }
                        else
                        {
                            ReturnResult[j] = node.val;
                            ReturnResult[j + 1] = node.next.val;
                        }
                        j += 2;
                    }
                }
            }
            if (ReturnResult != null)
            {
                string ReturnResultStr = "[";
                ReturnResultStr = ReturnResultStr + string.Join(",", ReturnResult);
                ReturnResultStr = ReturnResultStr + "]";
                return ReturnResultStr;
            }
            return null;
        }
    }
}
