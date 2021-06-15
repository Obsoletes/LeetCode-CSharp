using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给你一个链表数组，每个链表都已经按升序排列。

	请你将所有链表合并到一个升序链表中，返回合并后的链表。
	 */
	public class Q23 : IQuestion
	{
		public ListNode MergeKLists(ListNode[] lists)
		{
			var root = new ListNode();
			var current = root;
			while (Take(lists, out int val))
			{
				var t = new ListNode(val);
				current.next = t;
				current = t;
			}

			return root.next;
			static bool Take(ListNode[] listNodes, out int val)
			{
				var min = int.MaxValue;
				int minNode = 0;
				for (int i = 0; i < listNodes.Length; i++)
				{
					var item = listNodes[i];
					if (item != null)
					{
						if (item.val < min)
						{
							min = item.val;
							minNode = i;
						}
					}
				}
				if (min == int.MaxValue)
				{
					val = 0;
					return false;
				}
				val = min;
				listNodes[minNode] = listNodes[minNode].next;
				return true;
			}
		}
		public void Go()
		{
			Console.WriteLine(MergeKLists(Helper.GetArray(ListNode.FromNumber(541), ListNode.FromNumber(431), ListNode.FromNumber(62))));
			Console.WriteLine(MergeKLists(Helper.GetArray<ListNode>()));
			//Console.WriteLine(MergeKLists(Helper.GetArray(new ListNode())));
		}
	}
}
