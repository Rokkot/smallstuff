using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

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

        public static string StripHTML(this string HTMLText, bool decode = true)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            var stripped = reg.Replace(HTMLText, "");
            return decode ? HttpUtility.HtmlDecode(stripped) : stripped;
        }
    }
}
