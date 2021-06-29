using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个数组 routes ，表示一系列公交线路，其中每个 routes[i] 表示一条公交线路，第 i 辆公交车将会在上面循环行驶。</para> 
	/// <para>例如，路线 routes[0] = [1, 5, 7] 表示第 0 辆公交车会一直按序列 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... 这样的车站路线行驶。</para> 
	/// <para>现在从 source 车站出发（初始时不在公交车上），要前往 target 车站。 期间仅可乘坐公交车。</para> 
	/// <para>求出 最少乘坐的公交车数量 。如果不可能到达终点车站，返回 -1 。</para> 
	/// </summary>
	public class Q815 : IQuestion
	{
		public int NumBusesToDestination(int[][] routes, int source, int target)
		{
			if (source == target)
			{
				return 0;
			}

			int n = routes.Length;
			bool[,] edge = new bool[n, n];
			Dictionary<int, List<int>> rec = new Dictionary<int, List<int>>();
			for (int i = 0; i < n; i++)
			{
				foreach (int site in routes[i])
				{
					List<int> list = new List<int>();
					if (rec.ContainsKey(site))
					{
						list = rec[site];
						foreach (int j in list)
						{
							edge[i, j] = edge[j, i] = true;
						}
						rec[site].Add(i);
					}
					else
					{
						list.Add(i);
						rec.Add(site, list);
					}
				}
			}

			int[] distance = new int[n];
			Array.Fill(distance, -1);
			Queue<int> queue = new Queue<int>();
			if (rec.ContainsKey(source))
			{
				foreach (int bus in rec[source])
				{
					distance[bus] = 1;
					queue.Enqueue(bus);
				}
			}
			while (queue.Count > 0)
			{
				int x = queue.Dequeue();
				for (int y = 0; y < n; y++)
				{
					if (edge[x, y] && distance[y] == -1)
					{
						distance[y] = distance[x] + 1;
						queue.Enqueue(y);
					}
				}
			}

			int res = int.MaxValue;
			if (rec.ContainsKey(target))
			{
				foreach (int bus in rec[target])
				{
					if (distance[bus] != -1)
					{
						res = Math.Min(res, distance[bus]);
					}
				}
			}
			return res == int.MaxValue ? -1 : res;
		}

		public void Go()
		{
			Console.WriteLine(NumBusesToDestination(Helper.GetArray(Helper.GetArray(1, 2, 7), Helper.GetArray(3, 6, 7)), 1, 6));
			Console.WriteLine(NumBusesToDestination(Helper.GetArray(Helper.GetArray(7, 12), Helper.GetArray(4, 5, 15), Helper.GetArray(6), Helper.GetArray(15, 19), Helper.GetArray(9, 12, 13)), 15, 12));
			/*
			 [[25,33],
			 [3,5,13,22,23,29,37,45,49],
			 [15,16,41,47],
			 [5,11,17,23,33],
			 [10,11,12,29,30,39,45],
			 [2,5,23,24,33],
			 [1,2,9,19,20,21,23,32,34,44],
			 [7,18,23,24],
			 [1,2,7,27,36,44],
			 [7,14,33]]
7
47
			 */
			/*
			 * 
			 * [[10,13,22,28,32,35,43],
			 * [2,11,15,25,27],
			 * [6,13,18,25,42],
			 * [5,6,20,27,37,47],
			 * [7,11,19,23,35],
			 * [7,11,17,25,31,43,46,48],
			 * [1,4,10,16,25,26,46],
			 * [7,11],
			 * [3,9,19,20,21,24,32,45,46,49],
			 * [11,41]]
37
43

			 */
			Console.WriteLine(NumBusesToDestination(Helper.GetArray(
		   Helper.GetArray(10, 13, 22, 28, 32, 35, 43),
		   Helper.GetArray(2, 11, 15, 25, 27),
		   Helper.GetArray(6, 13, 18, 25, 42),
		   Helper.GetArray(5, 6, 20, 27, 37, 47),
		   Helper.GetArray(7, 11, 19, 23, 35),
		   Helper.GetArray(7, 11, 17, 25, 31, 43, 46, 48),
		   Helper.GetArray(1, 4, 10, 16, 25, 26, 46),
		   Helper.GetArray(7, 11),
		   Helper.GetArray(3, 9, 19, 20, 21, 24, 32, 45, 46, 49),
		   Helper.GetArray(11, 41)
		   ), 37, 43));
			Console.WriteLine(NumBusesToDestination(Helper.GetArray(
			Helper.GetArray(25, 33),
			Helper.GetArray(3, 5, 13, 22, 23, 29, 37, 45, 49),
			Helper.GetArray(15, 16, 41, 47),
			Helper.GetArray(5, 11, 17, 23, 33),
			Helper.GetArray(10, 11, 12, 29, 30, 39, 45),
			Helper.GetArray(2, 5, 23, 24, 33),
			Helper.GetArray(1, 2, 9, 19, 20, 21, 23, 32, 34, 44),
			Helper.GetArray(7, 18, 23, 24),
			Helper.GetArray(1, 2, 7, 27, 36, 44),
			Helper.GetArray(7, 14, 33)
			), 7, 47));
		}
	}
}
