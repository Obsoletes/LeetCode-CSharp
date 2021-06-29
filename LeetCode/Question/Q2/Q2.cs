using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。</para>
	/// <para>请你将两个数相加，并以相同形式返回一个表示和的链表。</para>
	/// </summary>
	/// <remarks>你可以假设除了数字 0 之外，这两个数都不会以 0 开头。</remarks>
	public class Q2 : IQuestion
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			var root = new ListNode();
			var currentNode = root;
			int current = l1.val + l2.val;
			root.val = current % 10;
			bool isUp = current >= 10;
			l1 = l1.next;
			l2 = l2.next;
			while (l1 != null && l2 != null)
			{
				var newNode = new ListNode();
				currentNode.next = newNode;

				current = l1.val + l2.val + (isUp ? 1 : 0);
				newNode.val = current % 10;
				isUp = current >= 10;
				currentNode = currentNode.next;
				l1 = l1.next;
				l2 = l2.next;
			}
			if (l1 != null)
			{
				while (l1 != null)
				{
					var newNode = new ListNode();
					currentNode.next = newNode;
					current = l1.val + (isUp ? 1 : 0);
					newNode.val = current % 10;
					isUp = current >= 10;
					currentNode = currentNode.next;
					l1 = l1.next;
				}
			}
			if (l2 != null)
			{
				while (l2 != null)
				{
					var newNode = new ListNode();
					currentNode.next = newNode;
					current = l2.val + (isUp ? 1 : 0);
					newNode.val = current % 10;
					isUp = current >= 10;
					currentNode = currentNode.next;
					l2 = l2.next;
				}
			}
			if (isUp)
			{
				var newNode = new ListNode(1);
				currentNode.next = newNode;
			}
			return root;
		}
		public void Go()
		{
			Console.WriteLine(AddTwoNumbers(ListNode.FromNumber(342), ListNode.FromNumber(456)));
			Console.WriteLine(AddTwoNumbers(ListNode.FromNumber(0), ListNode.FromNumber(0)));
			Console.WriteLine(AddTwoNumbers(ListNode.FromNumber(9999999), ListNode.FromNumber(9999)));
		}
	}
}
