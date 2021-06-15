using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。
	/// <see cref="Q23"/>
	/// </summary>
	public class Q21 : IQuestion
	{
		public ListNode MergeTwoLists(ListNode l1, ListNode l2)
		{
			return new Q23().MergeKLists(new ListNode[] { l1, l2 });
		}
		public void Go()
		{
			Console.WriteLine(MergeTwoLists(ListNode.FromNumber(421), ListNode.FromNumber(431)));
			Console.WriteLine(MergeTwoLists(null, null));
			Console.WriteLine(MergeTwoLists(null, ListNode.FromNumber(0)));
		}
	}
}
