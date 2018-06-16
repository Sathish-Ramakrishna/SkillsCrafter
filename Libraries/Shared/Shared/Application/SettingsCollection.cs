using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SkillsCrafter.Shared.Application
{
	public class SettingsCollection : ReadOnlyCollection<Setting>
	{
		#region Properties

		public String this[string key]
		{
			get
			{
				Setting match = base.Items
					.Where(s => s.Key.Equals(key))
					.FirstOrDefault();
				return (match == null) ? null : match.Value;
			}
			set
			{
				Setting match = base.Items
					.Where(s => s.Key.Equals(key))
					.FirstOrDefault();
				if (match != null) match.Value = value;
				else base.Items.Add(new Setting(key, value));
			}
		}

		#endregion

		#region Constructor

		public SettingsCollection(IList<Setting> list)
			: base(list)
		{
			//
		}

		#endregion
	}
}
