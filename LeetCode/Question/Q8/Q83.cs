using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>存在一个按升序排列的链表，给你这个链表的头节点 head ，请你删除链表中所有存在数字重复情况的节点，只保留原始链表中 没有重复出现 的数字。</para>
	/// <para>返回同样按升序排列的结果链表。</para>
	/// </summary>
	public class Q83 : IQuestion
	{
		public ListNode DeleteDuplicates(ListNode head)
		{
			if (head == null || head.next == null)
				return head;
			var root = new ListNode { next = head };
			ListNode currentNode = root;
			while (currentNode.next != null && currentNode.next.next != null)
			{
				if (currentNode.next.val == currentNode.next.next.val)
				{
					currentNode = currentNode.next; ;
					int x = currentNode.next.val;
					while (currentNode.next != null && currentNode.next.val == x)
						currentNode.next = currentNode.next.next;
				}
				else
					currentNode = currentNode.next;
			}
			return root.next;
		}
		public void Go()
		{
			Console.WriteLine(DeleteDuplicates(ListNode.FromNumber(211)));
			Console.WriteLine(DeleteDuplicates(ListNode.FromNumber(33211)));
			Console.WriteLine(DeleteDuplicates(ListNode.FromNumber(5443321)));
			Console.WriteLine(DeleteDuplicates(ListNode.FromNumber(32111)));
		}
	}
}
