using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。</para>
	/// <para>你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。</para>
	/// </summary>
	public class Q24 : IQuestion
	{
		public ListNode SwapPairs(ListNode head)
		{
			if (head == null)
				return null;
			if (head.next == null)
				return head;
			var root = head;
			ListNode current;
			current = root.next;
			root.next = root.next.next;
			current.next = root;
			root = current;
			current = root.next;
			while (current.next != null && current.next.next != null)
			{
				current.next = Change(current.next, current.next.next);
				current = current.next.next;
			}
			return root;
			ListNode Change(ListNode node1, ListNode node2)
			{
				var nextNext = node2.next;
				node2.next = node1;
				node1.next = nextNext;
				return node2;
			}
		}
		public void Go()
		{
			Console.WriteLine(SwapPairs(ListNode.FromNumber(4321)));
			Console.WriteLine(SwapPairs(null));
			Console.WriteLine(SwapPairs(ListNode.FromNumber(1)));
		}
	}
}
