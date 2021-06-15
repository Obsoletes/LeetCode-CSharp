using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/*
	符合下列属性的数组 arr 称为 山脉数组 ：
	arr.length >= 3
	存在 i（0 < i < arr.length - 1）使得：
	arr[0] < arr[1] < ... arr[i-1] < arr[i]
	arr[i] > arr[i+1] > ... > arr[arr.length - 1]
	给你由整数组成的山脉数组 arr ，返回任何满足 arr[0] < arr[1] < ... arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 1] 的下标 i 。
	 */
	public class Q852 : IQuestion
	{
		public int PeakIndexInMountainArray(ReadOnlySpan<int> span, int start)
		{
			if (span.Length < 3)
				throw new Exception();
			var mid = span.Length / 2;
			if (span[mid] > span[mid - 1])
			{
				if (span[mid] > span[mid + 1])
				{
					return mid + start;
				}
				else
				{
					return PeakIndexInMountainArray(span.Slice(mid), start + mid);
				}
			}
			else
			{
				return PeakIndexInMountainArray(span.Slice(0, mid + 1), start);
			}
		}
		public int PeakIndexInMountainArray(int[] arr)
		{
			return PeakIndexInMountainArray(new ReadOnlySpan<int>(arr), 0);
		}
		public void Go()
		{
			Console.WriteLine(PeakIndexInMountainArray(Helper.GetArray(0, 1, 0)));
			Console.WriteLine(PeakIndexInMountainArray(Helper.GetArray(0, 2, 1, 0)));
			Console.WriteLine(PeakIndexInMountainArray(Helper.GetArray(0, 10, 5, 2)));
			Console.WriteLine(PeakIndexInMountainArray(Helper.GetArray(3, 4, 5, 1)));
			Console.WriteLine(PeakIndexInMountainArray(Helper.GetArray(24, 69, 100, 99, 79, 78, 67, 36, 26, 19)));
		}
	}
}
