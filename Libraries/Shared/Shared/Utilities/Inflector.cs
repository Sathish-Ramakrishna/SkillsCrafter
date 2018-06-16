using System;
using System.Text.RegularExpressions;

namespace SkillsCrafter.Shared.Utilities
{
	public static class Inflector
	{
		#region Fields

		private static String[] _pluralPattern = new String[]
		{
			@"(quiz)zes$",
			@"(matr)ices$",
			@"(vert|ind)ices$",
			@"^(ox)en",
			@"(alias|status)$",
			@"(alias|status)es$",
			@"(octop|vir)(i|us)$",
			@"(cris|ax|test)es$",
			@"(shoe)s$",
			@"(o|bus)es$",
			@"([m|l])ice$",
			@"([a-zA-Z]+)?(us|is|sus|sis)$",
			@"(x|ch|ss|sh)es$",
			@"([a-zA-Z]+)?ses$",
			@"(m)ovies$",
			@"(s)eries$",
			@"([a-zA-Z]+)?xies$",
			@"([^aeiouy]|qu)ies$",
			@"([lr])ves$",
			@"(tive)s$",
			@"(hive)s$",
			@"(ave)s$",
			@"([^f])ves$",
			@"((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$",
			@"([ti])a$",
			@"(n)ews$",
			@"([a-zA-Z]+)?men$",
			@"s$"
		};
		private static String[] _pluralReplacement = new String[]
		{
			@"$1",
			@"$1ix",
			@"$1ex",
			@"$1",
			@"$1",
			@"$1",
			@"$1us",
			@"$1is",
			@"$1",
			@"$1",
			@"$1ouse",
			@"$1$2",
			@"$1",
			@"$1sis",
			@"$1ovie",
			@"$1eries",
			@"$1xi",
			@"$1y",
			@"$1f",
			@"$1",
			@"$1",
			@"$1",
			@"$1fe",
			@"$1$2sis",
			@"$1um",
			@"$1ews",
			@"$1man",
			@""
		};
		private static String[] _singularPattern = new String[]
		{
			@"(quiz)$",
			@"([a-zA-Z]+)?man$",
			@"^(oxen)$",
			@"^(ox)$",
			@"^([m|l])ice$",
			@"([m|l])ouse$",
			@"(vertex|ind)ex$",
			@"(matr)ix$",
			@"(x|ch|ss|sh)$",
			@"([^aeiouy]|qu)y$",
			@"(hive)$",
			@"(?:([^f])fe|([lr])f)$",
			@"sis$",
			@"([ti])a$",
			@"([ti])um$",
			@"(buffal|tomat)o$",
			@"(bu)s$",
			@"(alias|status)$",
			@"(octop|vir)i$",
			@"(octop|vir)us$",
			@"(ax|test)is$",
			@"xi$",
			@"s$",
			@"$"
		};
		private static String[] _singularReplacement = new String[]
		{
			@"$1zes",
			@"$1men",
			@"$1",
			@"$1en",
			@"$1ice",
			@"$1ice",
			@"$1ices",
			@"$1ices",
			@"$1es",
			@"$1ies",
			@"$1s",
			@"$1$2ves",
			@"ses",
			@"$1a",
			@"$1a",
			@"$1oes",
			@"$1ses",
			@"$1es",
			@"$1i",
			@"$1i",
			@"$1es",
			@"xies",
			@"s",
			@"s"
		};

		#endregion

		#region Methods.Public

		public static String Pluralize(string input)
		{
			for (int i = 0; i < _singularPattern.Length; i++)
			{
				Regex expression = new Regex(_singularPattern[i], RegexOptions.IgnoreCase);
				if (expression.IsMatch(input)) return expression.Replace(input, _singularReplacement[i]);
			}
			//
			return input;
		}

		public static String Singularize(string input)
		{
			for (int i = 0; i < _pluralPattern.Length; i++)
			{
				Regex expression = new Regex(_pluralPattern[i], RegexOptions.IgnoreCase);
				if (expression.IsMatch(input)) return expression.Replace(input, _pluralReplacement[i]);
			}
			//
			return input;
		}

		#endregion
	}
}
