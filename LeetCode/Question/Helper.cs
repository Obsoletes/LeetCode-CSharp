using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	public static class Helper
	{
		static public T[] GetArray<T>(params T[] array)
		{
			return array;
		}
		static public string ToArrayString<T>(this IEnumerable<T> list)
		{
			return $"[{string.Join(',', list)}]";
		}
		static public string ToArrayString2<T>(this IEnumerable<IEnumerable<T>> list)
		{
			return list.Select(l => l.ToArrayString()).ToArrayString();
		}
	}
}
