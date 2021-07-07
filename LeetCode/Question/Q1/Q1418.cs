using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个数组 orders，表示客户在餐厅中完成的订单，确切地说， orders[i]=[customerNamei,tableNumberi,foodItemi] ，
	/// 其中 customerNamei 是客户的姓名，tableNumberi 是客户所在餐桌的桌号，而 foodItemi 是客户点的餐品名称。</para>
	/// <para>请你返回该餐厅的 点菜展示表 。在这张表中，表中第一行为标题，其第一列为餐桌桌号 “Table” ，
	/// 后面每一列都是按字母顺序排列的餐品名称。
	/// 接下来每一行中的项则表示每张餐桌订购的相应餐品数量，第一列应当填对应的桌号，后面依次填写下单的餐品数量。</para>
	/// <para>注意：客户姓名不是点菜展示表的一部分。此外，表中的数据行应该按餐桌桌号升序排列。</para>
	/// </summary>
	public class Q1418
	{
		public class StringComp : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				return string.CompareOrdinal(x, y);
			}
		}
		public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
		{
			SortedSet<string> foods = new SortedSet<string>(new StringComp());
			SortedDictionary<int, SortedDictionary<string, int>> dic = new SortedDictionary<int, SortedDictionary<string, int>>();
			foreach (var item in orders)
			{
				foods.Add(item[2]);
				int key = int.Parse(item[1]);
				SortedDictionary<string, int> table;
				if (dic.ContainsKey(key))
				{
					table = dic[key];
				}
				else
				{
					table = new SortedDictionary<string, int>();
					dic[key] = table;
				}
				if (table.ContainsKey(item[2]))
				{
					table[item[2]]++;
				}
				else
				{
					table.Add(item[2], 1);
				}
			}
			List<IList<string>> result = new List<IList<string>>();
			List<string> head = new List<string>();
			head.Add("Table");
			head.AddRange(foods);
			result.Add(head);
			foreach (var kv in dic)
			{
				List<string> item = new List<string>(head.Count);
				item.Add(kv.Key.ToString());
				foreach (var food in foods)
				{
					item.Add(kv.Value.GetValueOrDefault(food, 0).ToString());
				}
				result.Add(item);
			}
			return result;
		}
		public void Go()
		{
			Console.WriteLine(DisplayTable(Helper.GetArray(
			Helper.GetArray("David", "3", "Ceviche"),
			Helper.GetArray("Corina", "10", "Beef Burrito"),
			Helper.GetArray("David", "3", "Fried Chicken"),
			Helper.GetArray("Carla", "5", "Water"),
			Helper.GetArray("Carla", "5", "Ceviche"),
			Helper.GetArray("Rous", "3", "Ceviche"))).ToArrayString2(true));


			Console.WriteLine(DisplayTable(Helper.GetArray(
			Helper.GetArray("James", "12", "Fried Chicken"),
			Helper.GetArray("Ratesh", "12", "Fried Chicken"),
			Helper.GetArray("Amadeus", "12", "Fried Chicken"),
			Helper.GetArray("Adam", "1", "Canadian Waffles"),
			Helper.GetArray("Brianna", "1", "Canadian Waffles"))).ToArrayString2(true));


			Console.WriteLine(DisplayTable(Helper.GetArray(
			Helper.GetArray("pKKgO", "1", "qgGxK"),
			Helper.GetArray("ZgW", "3", "XfuBe"))).ToArrayString2(true));
		}
	}
}
