using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// 给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。
	/// 回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是。
	/// </summary>
	public class Q9 : IQuestion
	{
		public bool IsPalindrome(int x)
		{
			if (x < 0)
				return false;
			var y = 0;
			var t = x;
			while (t != 0)
			{
				y = y * 10 + t % 10;
				t /= 10;
			}
			return x == y;
		}
		public void Go()
		{
			Console.WriteLine(IsPalindrome(121));
			Console.WriteLine(IsPalindrome(-121));
			Console.WriteLine(IsPalindrome(10));
			Console.WriteLine(IsPalindrome(-101));
		}
	}
}
