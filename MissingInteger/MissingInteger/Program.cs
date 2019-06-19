using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingInteger
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arrayValue = new int[] { 3, 4, 7, 6 };
			Console.WriteLine(FindMinimumIntegerMissing(arrayValue));
			Console.ReadLine();
		}
		static int FindMinimumIntegerMissing(int[] arrayInt)
		{
			var arrayMin = arrayInt.Min();
			var arrayMax = arrayInt.Max();

			for (int value = arrayMin; value < arrayMax; value++)
			{
				if (!arrayInt.OrderByDescending(a => a).Contains(value))
				{
					return value;
				}

			}
			return arrayMax + 1;

		}
	}
}
