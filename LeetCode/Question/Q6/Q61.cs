using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个链表的头节点 head ，旋转链表，将链表每个节点向右移动 k 个位置。
	/// </summary>
	public class Q61 : IQuestion
	{
		public ListNode RotateRight(ListNode head, int k)
		{
			if (head == null)
				return head;
			int length = 0;
			var node = head;
			while (node.next != null)
			{
				node = node.next;
				length++;
			}
			node.next = head;
			length++;
			k %= length;
			k = length - k;
			while (k-- > 0)
			{
				node = node.next;
			}
			var next = node.next;
			node.next = null;
			return next;
		}
		public void Go()
		{
			Console.WriteLine(RotateRight(ListNode.FromNumber(54321), 2));
			Console.WriteLine(RotateRight(ListNode.FromNumber(210), 4));
		}
	}
}
