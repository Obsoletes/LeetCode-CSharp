using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。</para>
	/// <para>k 是一个正整数，它的值小于或等于链表的长度。</para>
	/// <para>如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。</para>
	/// </summary>
	/// <remarks>
	/// <para>你可以设计一个只使用常数额外空间的算法来解决此问题吗？</para>
	/// <para>你不能只是单纯的改变节点内部的值，而是需要实际进行节点交换。</para>
	/// </remarks>
	public class Q25 : IQuestion
	{
		public ListNode ReverseKGroup2(ListNode head, int k)
		{
			if (k == 1)
				return head;
			var arr = new ListNode[k];
			var guard = new ListNode(next: head);
			var pre = guard;
			ListNode current;
			while (true)
			{
				current = pre.next;
				int i;
				for (i = 0; i < k && current != null; i++)
				{
					arr[i] = current;
					current = current.next;
				}
				if (i != k)
				{
					break;
				}
				var next = arr[k - 1].next;
				pre.next = Change(arr);
				arr[k - 1].next = next;
				pre = arr[k - 1];
			}
			return guard.next;
			ListNode Change(ListNode[] arr)
			{
				Stack<ListNode> stack = new Stack<ListNode>(arr);
				for (int i = 0; i < arr.Length; i++)
				{
					arr[i] = stack.Pop();
					if (i != 0)
					{
						arr[i - 1].next = arr[i];
					}
				}
				return arr[0];
			}
		}


		public ListNode ReverseKGroup(ListNode head, int k)
		{
			if (k == 1)
				return head;
			var guard = new ListNode(next: head);
			var pre = guard;
			ListNode current, start, end;
			int i;

			while (true)
			{
				current = pre.next;
				start = current;
				for (i = 0; i < k - 1 && current != null; i++)
				{
					current = current.next;
				}
				if (i != k - 1 || current == null)
				{
					break;
				}
				end = current;
				var next = end.next;
				Change(start, end);
				pre.next = end;
				start.next = next;
				pre = start;
			}
			return guard.next;
			void Change(ListNode start, ListNode end)
			{
				ListNode pre = null;
				var current = start;
				while (pre != end)
				{
					var next = current.next;
					current.next = pre;
					pre = current;
					current = next;
				}
			}
		}
		public void Go()
		{
			Console.WriteLine(ReverseKGroup(ListNode.FromNumber(54321), 2));
			Console.WriteLine(ReverseKGroup(ListNode.FromNumber(54321), 3));
			Console.WriteLine(ReverseKGroup(ListNode.FromNumber(54321), 1));
			Console.WriteLine(ReverseKGroup(ListNode.FromNumber(1), 1));
		}
	}
}
