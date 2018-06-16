using System;
using System.Globalization;

namespace SkillsCrafter.Shared.Extensions
{
	public static class DateTimeExtensions
	{
		#region Methods.Public

		public static DateTime ToInvariantDate(this DateTime dateTime)
		{
			DateTime value = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
			String invariant = value.ToString(CultureInfo.InvariantCulture);
			return DateTime.Parse(invariant, CultureInfo.InvariantCulture);
		}

		public static DateTime ToInvariantDateTime(this DateTime dateTime)
		{
			DateTime value = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
			String invariant = value.ToString(CultureInfo.InvariantCulture);
			return DateTime.Parse(invariant, CultureInfo.InvariantCulture);
		}

		#endregion
	}
}
