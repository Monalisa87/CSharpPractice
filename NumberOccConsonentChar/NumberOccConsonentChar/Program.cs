using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOccConsonentChar
{
	class Program
	{
		static void Main(string[] args)
		{
			string strValue = "BAREQ";
			NumberOccStartsWithConsonent(strValue);
			//Console.WriteLine(value);
			//Console.ReadLine();
		}
		static int factorial(int n)
		{
			return (n == 1 || n == 0) ? 1 : factorial(n - 1) * n;
		}
		// Function to check if a  
		// character is a vowel  
		static bool isVowel(char c)
		{
			c = char.ToLower(c);
			if (c == 'a' || c == 'e' || c == 'i'
						|| c == 'o' || c == 'u')
			{
				return true;
			}
			return false;
		}
		static int NumberOccStartsWithConsonent(string str)
		{
			var result = GetPermutations(str, str.Length).ToList().Select(a => string.Join("", a)).ToList();
			var alternateConsonant = result.Select(item => item.Select((charvalue, index) =>
											   new
											   {
												   isConsonant = (index % 2 == 0 && !isVowel(charvalue)),
												   isVowel = (index % 2 != 0 && isVowel(charvalue)),
												   item
											   }).ToList()
								).ToList();
			return alternateConsonant.Select(item => item.Where(a => a.isConsonant == true).Count() >= ((str.Length + 1) / 2)).ToList().Where(c => c.Equals(true)).Count();
		}
		static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
		{
			if (length == 1) return list.Select(t => new T[] { t });

			return GetPermutations(list, length - 1)
				.SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));

		}


	}
}
