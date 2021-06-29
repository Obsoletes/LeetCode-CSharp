using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。</para>
	/// <para>最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。</para>
	/// <para>你可以假设除了整数 0 之外，这个整数不会以零开头。</para>
	/// </summary>
	public class Q66 : IQuestion
	{
		public int[] PlusOne(int[] digits)
		{
			bool up = false;
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				if (digits[i] == 9)
				{
					up = true;
					digits[i] = 0;
				}
				else
				{
					digits[i]++;
					up = false;
					break; ;
				}
			}
			if (up)
			{
				var res = new List<int> { 1 };
				res.AddRange(digits);
				return res.ToArray();
			}
			return digits;
		}
		public void Go()
		{
			Console.WriteLine($"[{string.Join(',', PlusOne(Helper.GetArray(1, 2, 3)))}]");
			Console.WriteLine($"[{string.Join(',', PlusOne(Helper.GetArray(4, 3, 2, 1)))}]");
			Console.WriteLine($"[{string.Join(',', PlusOne(Helper.GetArray(0)))}]");
			Console.WriteLine($"[{string.Join(',', PlusOne(Helper.GetArray(9)))}]");
		}
	}
}
