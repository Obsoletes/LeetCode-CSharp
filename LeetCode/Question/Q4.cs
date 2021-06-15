using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	 给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。
	*/
	public class Q4 : IQuestion
	{
		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			ReadOnlySpan<int> span1 = nums1;
			ReadOnlySpan<int> span2 = nums2;
			bool isOdd = ((span1.Length + span2.Length) % 2) == 1;
			var k = 0;
			if (isOdd)
			{
				k = (span1.Length + span2.Length - 1) / 2;
			}
			else
			{
				k = (span1.Length + span2.Length - 2) / 2;
			}

			static int Take(ref ReadOnlySpan<int> span1, ref ReadOnlySpan<int> span2)
			{
				int num;
				if (span1.Length == 0)
				{
					num = span2[0];
					span2 = span2.Slice(1);
				}
				else if (span2.Length == 0)
				{
					num = span1[0];
					span1 = span1.Slice(1);
				}
				else if (span1[0] < span2[0])
				{
					num = span1[0];
					span1 = span1.Slice(1);
				}
				else
				{
					num = span2[0];
					span2 = span2.Slice(1);
				}
				return num;
			};
			for (int i = 0; i < k; i++)
			{
				Take(ref span1, ref span2);
			}
			if (isOdd)
			{
				return Take(ref span1, ref span2);
			}
			else
			{
				return ((double)(Take(ref span1, ref span2) + Take(ref span1, ref span2))) / 2;
			}
		}
		public void Go()
		{
			Console.WriteLine(FindMedianSortedArrays(Helper.GetArray(1, 3), Helper.GetArray(2)));
			Console.WriteLine(FindMedianSortedArrays(Helper.GetArray(1, 2), Helper.GetArray(3, 4)));
			Console.WriteLine(FindMedianSortedArrays(Helper.GetArray(0, 0), Helper.GetArray(0, 0)));
			Console.WriteLine(FindMedianSortedArrays(Helper.GetArray<int>(), Helper.GetArray(1)));
			Console.WriteLine(FindMedianSortedArrays(Helper.GetArray(2), Helper.GetArray<int>()));
		}
	}
}

