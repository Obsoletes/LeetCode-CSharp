using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，
	/// 影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。</para>
	/// <para>给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。</para>
	/// </summary>
	public class Q198 : IQuestion
	{
		public int Rob(int[] nums)
		{
			if (nums.Length == 1)
				return nums[0];
			int[] dp = new int[nums.Length];
			dp[0] = nums[0];
			dp[1] = Math.Max(nums[1], nums[0]);
			for (int i = 2; i < nums.Length; i++)
			{
				dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
			}
			return dp[^1];
		}
		public void Go()
		{
			Console.WriteLine(Rob(Helper.GetArray(1, 25)));
			Console.WriteLine(Rob(Helper.GetArray(1, 2, 3, 1)));
			Console.WriteLine(Rob(Helper.GetArray(2, 7, 9, 3, 1)));
		}
	}
}
