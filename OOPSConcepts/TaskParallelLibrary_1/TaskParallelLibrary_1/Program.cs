using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary_1
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = Enumerable.Range(0, 1000000).ToArray();
			long total = 0;
			long total1 = 0;

			///Using For loop
			
			// Use type parameter to make subtotal a long, not an int
			Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
			{
				subtotal += nums[j];
				return subtotal;
			},
				(x) => Interlocked.Add(ref total, x)
			);

			///Using Foreach Loop 

			Parallel.ForEach<int, long>(nums, () => 0, (j, loop, subtotal) =>
				 {
					 subtotal += j;
					 return subtotal;
				 },
			(x) => Interlocked.Add(ref total1, x)

			);

			Console.WriteLine("The total is {0:N0}", total);
			Console.WriteLine("The total is {0:N0}", total1);
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
