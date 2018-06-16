using System;
using System.Diagnostics; 
using System.Globalization;
using System.IO;

namespace SkillsCrafter.Shared.Utilities
{
	public sealed class Log
	{
		#region Fields
#if !NETCF
		private static EventLog _log = null; 
#endif
		private static EventLogEntryType _verbosity = EventLogEntryType.Information;
		private static String _location = null;

		#endregion

		#region Properties

		public static EventLogEntryType Verbosity
		{
			get { return _verbosity; }
			set { _verbosity = value; }
		}

		public static String Location
		{
			get { return _location; }
		}

		#endregion

		#region Constructor

		static Log()
		{
			//
		}

		#endregion

		#region Methods.Private

		internal static void Write(string entry, EventLogEntryType type)
		{
			if (!String.IsNullOrEmpty(_location))
				try
				{
					FileMode mode = File.Exists(_location) ? FileMode.Append : FileMode.Create;
					//
					using (FileStream fs = new FileStream(_location, mode, FileAccess.Write))
					using (StreamWriter sw = new StreamWriter(fs))
						sw.WriteLine(String.Format(CultureInfo.InvariantCulture, "[ {0} ] {1} : {2}", type, DateTime.Now, entry));
				}
				catch
				{
					// Nothing we can do.
				}
#if !NETCF
			if (_log != null)
				try
				{
					_log.WriteEntry(entry, type);
				}
				catch
				{
					// Nothing we can do.
				} 
#endif
		}

		#endregion

		#region Methods.Public

		public static void Activate(string location)
		{
			_location = location;
		}
#if !NETCF
		public static void Create(string source)
		{
			try
			{
				_log = new EventLog();
				_log.Source = source;
			}
			catch
			{
				_log = null;
			}
		} 
#endif
		public static void WriteEntry(string entry)
		{
			Log.Write(entry, EventLogEntryType.Information);
		}

		public static void WriteEntry(string format, params object[] args)
		{
			Log.Write(String.Format(format, args), EventLogEntryType.Information);
		}

		public static void WriteError(string error)
		{
			Log.Write(error, EventLogEntryType.Error);
		}

		public static void WriteError(string format, params object[] args)
		{
			Log.Write(String.Format(format, args), EventLogEntryType.Error);
		}

		public static void WriteMessage(string message)
		{
			if (_verbosity == EventLogEntryType.Information) Log.Write(message, EventLogEntryType.Information);
		}

		public static void WriteMessage(string format, params object[] args)
		{
			Log.WriteMessage(String.Format(format, args));
		}

		public static void WriteWarning(string warning)
		{
			if (_verbosity != EventLogEntryType.Error) Log.Write(warning, EventLogEntryType.Warning);
		}

		public static void WriteWarning(string format, params object[] args)
		{
			Log.Write(String.Format(format, args), EventLogEntryType.Warning);
		}

		#endregion
	}
}
