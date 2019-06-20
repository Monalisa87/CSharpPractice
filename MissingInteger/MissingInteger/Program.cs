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
			for (int value = arrayInt.Min(); value < arrayInt.Max(); value++)
			{
				if (!arrayInt.OrderBy(a => a).Contains(value))
				{
					return value;
				}

			}
			return arrayInt.Max() + 1;

		}
	}
}
