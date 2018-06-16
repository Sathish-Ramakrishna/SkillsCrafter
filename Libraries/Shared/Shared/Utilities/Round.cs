using System;

namespace SkillsCrafter.Shared.Utilities
{
	public static class Round
	{
		#region Methods.Public

		public static Int32 Down(decimal value)
		{
			Decimal rounded = Math.Round(value);
			if ((rounded - value) > 0) --rounded;
			//
			return Convert.ToInt32(rounded);
		}

		public static Int32 Down(double value)
		{
			return Round.Down((Decimal)value);
		}

		public static Int32 Down(float value)
		{
			return Round.Down((Decimal)value);
		}

		public static Int32 Up(decimal value)
		{
			Decimal rounded = Math.Round(value);
			if ((rounded - value) < 0) ++rounded;
			//
			return Convert.ToInt32(rounded);
		}

		public static Int32 Up(double value)
		{
			return Round.Up((Decimal)value);
		}

		public static Int32 Up(float value)
		{
			return Round.Up((Decimal)value);
		}

		#endregion
	}
}
