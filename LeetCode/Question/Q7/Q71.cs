using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Question
{
	/// <summary>
	/// <para>给你一个字符串 path ，表示指向某一文件或目录的 Unix 风格 绝对路径 （以 '/' 开头），请你将其转化为更加简洁的规范路径。</para>
	/// <para>在 Unix 风格的文件系统中，一个点（.）表示当前目录本身；
	/// 此外，两个点 （..） 表示将目录切换到上一级（指向父目录）；
	/// 两者都可以是复杂相对路径的组成部分。
	/// 任意多个连续的斜杠（即，'//'）都被视为单个斜杠 '/' 。 
	/// 对于此问题，任何其他格式的点（例如，'...'）均被视为文件/目录名称。</para>
	/// <para>请注意，返回的 规范路径 必须遵循下述格式：</para>
	/// <list type="bullet">
	/// <item>始终以斜杠 '/' 开头。</item>
	/// <item>两个目录名之间必须只有一个斜杠 '/' 。</item>
	/// <item>最后一个目录名（如果存在）不能 以 '/' 结尾。</item>
	/// <item>此外，路径仅包含从根目录到目标文件或目录的路径上的目录（即，不含 '.' 或 '..'）。</item>
	/// </list>
	/// <para>返回简化后得到的 规范路径 。</para>
	/// </summary>
	public class Q71 : IQuestion
	{
		public string SimplifyPath(string path)
		{
			Stack<string> stack = new Stack<string>();
			var paths = path.Split('/');
			foreach (var item in paths)
			{
				if (!string.IsNullOrEmpty(item))
				{
					if (item == "..")
					{
						if (stack.Count != 0) stack.Pop();
					}
					else if (item == ".") { }
					else
					{
						stack.Push(item);
					}
				}
			}
			return $"/{string.Join('/', stack.Reverse())}";
		}
		public void Go()
		{
			Console.WriteLine(SimplifyPath("/home/"));
			Console.WriteLine(SimplifyPath("/../"));
			Console.WriteLine(SimplifyPath("/.../"));
			Console.WriteLine(SimplifyPath("/home//foo/"));
			Console.WriteLine(SimplifyPath("/a/./b/../../c/"));
		}
	}
}
