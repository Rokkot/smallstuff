using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
	public static class StringUtils
	{
		public static string RemoveWhiteSpace(this string input)
		{
			return new string(input.ToCharArray()
				 .Where(c => !Char.IsWhiteSpace(c))
				 .ToArray());
		}
	}
}
