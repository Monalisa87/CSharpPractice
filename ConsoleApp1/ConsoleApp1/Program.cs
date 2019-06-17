using System;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] A)
		{
			int[] array = new int[] { 2, 3, 0, 4 };
			MainMethod(array);
		}
		static int MainMethod(int[] A)
		{
			return (A.Min() < 0 || A.Length > 100000) ? 0 : Convert.ToString(A.ToList().Sum(x => Convert.ToInt32(Math.Pow(2, x))), 2).ToCharArray().Where(x => x.Equals('1')).Count();
		}
		
	}
}

