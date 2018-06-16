using System;
using System.Collections.Generic;
#if !NETCF && !SL
using System.Configuration;
#endif
using System.IO;
using System.Linq;
using System.Reflection;
#if !SL
using System.Xml;
#endif

using SkillsCrafter.Shared.Utilities;

namespace SkillsCrafter.Shared.Application
{
	public sealed class Configuration
	{
		#region Fields

		private static readonly ApplicationData _data = null;
#if !SL
		private static SettingsCollection _settings = null;
#endif
		#endregion

		#region Properties

		public static ApplicationData Data
		{
			get { return _data; }
		}
#if !SL
		public static SettingsCollection Settings
		{
			get { return _settings; }
		}
#endif
		#endregion

		#region Constructor

		static Configuration()
		{
			_data = new ApplicationData();
		}

		#endregion
#if !SL
		#region Methods.Public

		public static void Load()
		{
			if (_settings != null) return;
			//
			List<Setting> settings = new List<Setting>();
			//
			try
			{
#if !NETCF && !SL
				if (ConfigurationManager.AppSettings != null)
					foreach (String key in ConfigurationManager.AppSettings.AllKeys)
						settings.Add(new Setting(key, ConfigurationManager.AppSettings[key]));
#endif
				String location = Assembly.GetExecutingAssembly().GetName().CodeBase;
				if (location.StartsWith("file:///")) location = location.Replace("file:///", String.Empty);
				if (location.StartsWith(@"file:\")) location = location.Replace(@"file:\", String.Empty);
				//
				DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(location));
				FileInfo[] afi = di.GetFiles("Config*.xml");
				if (afi.Length == 0) afi = di.GetFiles("Config*.txt");
				if (afi.Length == 0) throw new Exception("No configuration file found.");
				//
				XmlDocument xml = new XmlDocument();
				xml.Load(afi[0].FullName);
				//
				IEnumerable<XmlNode> nodes = xml["Settings"].ChildNodes.Cast<XmlNode>()
					.Where(n => n.Attributes != null)
					.Where(n => "add".Equals(n.Name));
				foreach (XmlNode node in nodes)
				{
					XmlElement element = node as XmlElement;
					try { settings.Add(new Setting(element.GetAttribute("key"), element.GetAttribute("value"))); }
					catch { }
				}
			}
			catch (Exception ex)
			{
				Log.WriteError(Errors.Extract(ex), "Configuration.Load()");
			}
			finally
			{
				_settings = new SettingsCollection(settings);
			}
		}

		#endregion
#endif
	}
}
