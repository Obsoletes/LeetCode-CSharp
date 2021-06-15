using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
	/// </summary>
	/// <remarks>你能尝试使用一趟扫描实现吗？</remarks>
	public class Q19 : IQuestion
	{
		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			Queue<ListNode> queue = new Queue<ListNode>(n);
			var root = head;
			while (head != null)
			{
				if (queue.Count == n + 1)
					queue.Dequeue();
				queue.Enqueue(head);
				head = head.next;
			}
			var prev = queue.Dequeue();
			if (queue.Count + 1 <= n && prev == root)
				return root.next;
			if (prev.next != null)
				prev.next = prev.next.next;
			return root;
		}
		public void Go()
		{

			Console.WriteLine(RemoveNthFromEnd(ListNode.FromNumber(21), 1));
			Console.WriteLine(RemoveNthFromEnd(ListNode.FromNumber(321), 3));
			Console.WriteLine(RemoveNthFromEnd(ListNode.FromNumber(321), 3));
			Console.WriteLine(RemoveNthFromEnd(ListNode.FromNumber(54321), 2));
			Console.WriteLine(RemoveNthFromEnd(ListNode.FromNumber(1), 1));

		}
	}
}
