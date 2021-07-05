using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。</para>
	/// <para>此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。</para>
	/// </summary>
	public class Q75 : IQuestion
	{
		public void SortColors(int[] nums)
		{
			int begin = 0, end = nums.Length - 1;
			for (int i = 0; i <= end; i++)
			{
				switch (nums[i])
				{
					case 0:
						nums[i] = nums[begin];
						nums[begin] = 0;
						begin++;
						break;
					case 2:
						nums[i] = nums[end];
						nums[end] = 2;
						end--;
						if (nums[i] != 1)
							i--;
						break;
				}
			}
		}
		public void Go()
		{
			var arr = Helper.GetArray(2, 0, 2, 1, 1, 0);
			SortColors(arr);
			Console.WriteLine(arr.ToArrayString());
			/*arr = Helper.GetArray(2, 0, 1);
			SortColors(arr);
			Console.WriteLine(arr.ToArrayString());
			arr = Helper.GetArray(0);
			SortColors(arr);
			Console.WriteLine(arr.ToArrayString());
			arr = Helper.GetArray(1);
			SortColors(arr);
			Console.WriteLine(arr.ToArrayString());*/
		}
	}
}
