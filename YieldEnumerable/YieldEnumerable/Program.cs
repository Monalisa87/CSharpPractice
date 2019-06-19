using System;
using System.Collections.Generic;

namespace YieldEnumerable
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Galaxy");
			ShowGalaxies();
			Console.WriteLine("\n");
			Console.WriteLine("Power");
			// Display powers of 2 up to the exponent of 8:
			foreach (int i in Power(2, 8))
			{
				Console.Write("{0} ", i);
			}
			Console.ReadLine();
		}
		public static IEnumerable<int> Power(int number, int exponent)
		{
			int result = 1;

			for (int i = 0; i < exponent; i++)
			{
				result = result * number;
				yield return result;
			}
		}

		public static void ShowGalaxies()
		{
			var theGalaxies = new Galaxies();
			foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
			{
				Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
			}
		}

		public class Galaxies
		{

			public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
			{
				get
				{
					yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
					yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
					yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
					yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
				}
			}

		}

		public class Galaxy
		{
			public String Name { get; set; }
			public int MegaLightYears { get; set; }
		}
	}



}
