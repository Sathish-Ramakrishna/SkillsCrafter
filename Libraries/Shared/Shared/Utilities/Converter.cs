using System;

namespace SkillsCrafter.Shared.Utilities
{
	public sealed class Converter
	{
		#region Methods.Public

		public static Boolean ToBoolean(object value)
		{
			if (value == null || value == DBNull.Value) return false;
			//
			if (value is String)
			{
				String upper = (value as String).Trim().ToUpper();
				if (String.IsNullOrEmpty(upper)) return false;
				else return "1|TRUE|YES".Contains(upper);
			}
			else
			{
				try { return Convert.ToBoolean(value); }
				catch { return false; }
			}
		}

		public static Char? ToChar(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			if (value is String)
			{
				String input = value as String;
				if (String.IsNullOrEmpty(input)) return null;
				else return input[0];
			}
			else
			{
				try { return Convert.ToChar(value); }
				catch { return null; }
			}
		}

		public static DateTime? ToDateTime(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToDateTime(value); }
			catch { return null; }
			/* Legacy
			if (value is String)
			{
				try { return Convert.ToDateTime(value); }
				catch // <-- yyyyMMdd[hhmm[ss]]
				{
					String input = value as String;
					//
					if (input.Length >= 8)
					{
						Int32 year = Converter.ToInt32(input.Substring(0, 4));
						Int32 month = Converter.ToInt32(input.Substring(4, 2));
						Int32 day = Converter.ToInt32(input.Substring(6, 2));
						//
						Int32 hour = 0, minute = 0, second = 0;
						if (input.Length >= 10)
						{
							hour = Converter.ToInt32(input.Substring(8, 2));
							minute = Converter.ToInt32(input.Substring(10, 2));
						}
						//
						if (input.Length >= 14) second = Converter.ToInt32(input.Substring(12, 2));
						//
						return new DateTime(year, month, day, hour, minute, second);
					}
					else return DateTime.MinValue;
				}
			}
			else
			{
				try { return Convert.ToDateTime(value); }
				catch { return null; }
			}*/
		}

		public static Decimal? ToDecimal(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToDecimal(value); }
			catch { return null; }
		}

		public static Double? ToDouble(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToDouble(value); }
			catch { return null; }
		}

		public static Int16? ToInt16(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToInt16(value); }
			catch { return null; }
		}

		public static Int32? ToInt32(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToInt32(value); }
			catch { return null; }
		}

		public static Int64? ToInt64(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToInt64(value); }
			catch { return null; }
		}

		public static Single? ToSingle(object value)
		{
			if (value == null || value == DBNull.Value) return null;
			//
			try { return Convert.ToSingle(value); }
			catch { return null; }
		}

		public static String ToString(object value)
		{
			if (value == null || value == DBNull.Value) return String.Empty;
			//
			try { return Convert.ToString(value); }
			catch { return String.Empty; }
		}

		#endregion
	}
}
