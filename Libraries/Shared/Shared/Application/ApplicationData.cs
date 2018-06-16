using System;
using System.Collections.Generic;

namespace SkillsCrafter.Shared.Application
{
	public class ApplicationData : Dictionary<String, Object>
	{
		#region Properties

		new public Object this[string key]
		{
			get
			{
				if (base.ContainsKey(key)) return base[key];
				else return null;
			}
			set
			{
				if (base.ContainsKey(key)) base[key] = value;
				else base.Add(key, value);
			}
		}

		#endregion

		#region Constructor

		public ApplicationData()
			: base()
		{
			//
		}

		#endregion

		#region Methods.Public

		new public void Add(string key, object value)
		{
			this[key] = value;
		}

		#endregion
	}
}
