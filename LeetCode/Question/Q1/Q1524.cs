using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个整数数组 arr 。请你返回和为 奇数 的子数组数目。</para>
	/// <para>由于答案可能会很大，请你将结果对 10^9 + 7 取余后返回。</para>
	/// </summary>
	public class Q1524 : IQuestion
	{
		public int NumOfSubarrays(int[] arr)
		{
			int odd, even, sum;
			odd = 1;
			even = 0;
			sum = 0;
			long result = 0;
			foreach (int i in arr)
			{
				sum += i;
				if (sum % 2 == 1)
				{
					even++;
					result += odd;
				}
				else
				{
					odd++;
					result += even;
				}
			}
			return (int)(result % 1000000007);
		}
		public void Go()
		{
			Console.WriteLine(NumOfSubarrays(Helper.GetArray(1, 3, 5)));
			Console.WriteLine(NumOfSubarrays(Helper.GetArray(2, 4, 6)));
			Console.WriteLine(NumOfSubarrays(Helper.GetArray(1, 2, 3, 4, 5, 6, 7)));
			Console.WriteLine(NumOfSubarrays(Helper.GetArray(100, 100, 99, 99)));
			Console.WriteLine(NumOfSubarrays(Helper.GetArray(7)));
		}
	}
}
