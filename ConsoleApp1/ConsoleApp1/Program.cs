using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		//static void Main(string[] A)
		//{
		//	int[] AB = new int[] { 2, 3, 0, 4 };
		//	MainMethod(AB);
		//}
		//static int MainMethod(int[] A)
		//{
		//	// write your code in C# 6.0 with .NET 4.5 (Mono)
		//	return (A.Min() < 0 || A.Length > 100000) ? 0 : Convert.ToString(A.ToList().Sum(x => Convert.ToInt32(Math.Pow(2, x))), 2).ToCharArray().Where(x => x.Equals('1')).Count();
		//	if 
		//	{
		//		return 0;
		//	}
		//	else
		//	{
		//		return ;
		//	}
		//}
		static void Main(string[] A)
		{
			string AB = "AABAY";
			MainMethod(AB);
		}
		static int MainMethod(string S)
		{
			string vowelsValue = "aeiou";
			var stringCgar = S.ToLower().ToCharArray().Except("aeiou".ToCharArray()).ToList();
			var vowels = S.ToLower().ToCharArray().Where(a => (vowelsValue.ToCharArray()).Contains(a)).ToList();
			//List<string> newStringList = new List<string>();
			Random random = new Random();
			List<string> newStringList = new string(Enumerable.Repeat(S, S.Length).Select(s => s[random.Next(s.Length)]).ToArray());
			//	//char[] characters = S.ToArray();
			//newStringList.Add(new string(characters));
			//Array.Sort(S.ToCharArray());
			//for (int i = 0; i < stringCgar.Count; i++)
			//{
			//	newStringList.Add(string.Concat(S.OrderBy(c => c)));

			//}
			return 0;
		}

	}
}

