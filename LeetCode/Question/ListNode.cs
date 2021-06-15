using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
		public override string ToString()
		{
			StringBuilder @string = new StringBuilder();
			var node = this;
			while (node != null && node.next != null)
			{
				@string.Append(node.val);
				@string.Append(',');
				node = node.next;
			}
			if (node != null)
			{
				@string.Append(node.val);
			}
			return @string.ToString();
		}
		public static ListNode FromNumber(int i)
		{
			ListNode root = new();
			var current = root;
			if (i == 0)
				return root;
			while (i != 0)
			{
				current.next = new ListNode();
				current = current.next;
				current.val = i % 10;
				i /= 10;
			}
			return root.next;
		}
	}
}
