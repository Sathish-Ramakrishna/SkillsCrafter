using System;

namespace SkillsCrafter.Shared.Application
{
	public class Setting
	{
		#region Fields

		private String _key = String.Empty;
		private String _value = String.Empty;

		#endregion

		#region Properties

		public String Key
		{
			get { return _key; }
			set { _key = value; }
		}

		public String Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion

		#region Constructors

		public Setting()
		{
			//
		}

		public Setting(string key, string value)
		{
			_key = key;
			_value = value;
		}

		#endregion
	}
}
