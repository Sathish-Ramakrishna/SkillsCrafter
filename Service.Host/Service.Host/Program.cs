using System;
using System.Collections;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;
using SkillsCrafter.Shared.Utilities;
using SkillsCrafter.Shared.Application;

namespace SkillsCrafter.Service.Host
{
	static class Program
	{
		#region Fields

		private static Boolean _daemon = false;
		private static String _name = null;

		#endregion

		#region Properties

		public static Boolean Daemon
		{
			get { return _daemon; }
		}

		public static String Name
		{
			get
			{
				if (String.IsNullOrEmpty(_name))
				{
					_name = Configuration.Settings["Name"];
					if (String.IsNullOrEmpty(_name)) _name = typeof(ServiceEngine).Assembly.GetName().Name;
				}
				//
				return _name;
			}
		}

		#endregion

		#region Methods

		static void Install()
		{
			try
			{
				using (AssemblyInstaller installer = new AssemblyInstaller(typeof(ServiceEngine).Assembly, null))
				{
					IDictionary state = new Hashtable();
					try
					{
						installer.UseNewContext = true;
						installer.Install(state);
						installer.Commit(state);
					}
					catch (Exception ex)
					{
						Console.WriteLine(Errors.Extract(ex));
						//
						try { installer.Rollback(state); }
						catch { }
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(Errors.Extract(ex));
			}
			//
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(false);
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			Configuration.Load();
			//
			String path = Configuration.Settings["Log"];
			if (!String.IsNullOrEmpty(path))
			{
				if (!path.Contains(@"\"))
				{
					String folder = Path.GetDirectoryName(typeof(ServiceEngine).Assembly.Location);
					path = String.Format(@"{0}\{1}", folder, path);
				}
				Log.Activate(path);
			}
			Log.Create(Program.Name);

#if DEBUG
			args = new String[] { "d" };
#endif
			if (args.Length == 0)
			{
				ServiceBase[] services = new ServiceBase[] { new HostService() };
				ServiceBase.Run(services);
			}
			else if (args.Length == 1)
			{
				String argument = args[0];
				if (argument.Length > 1) argument = argument.Substring(1);
				//
				if (argument.Equals("d"))
				{
					_daemon = true;
					//
					ServiceEngine engine = new ServiceEngine();
					engine.Start();
				}
				else if (argument.StartsWith("i")) Program.Install();
				else if (argument.StartsWith("u")) Program.Uninstall();
				else Console.WriteLine("Unrecognized command line parameter.");
			}
			else Console.WriteLine("Invalid number of command line parameters.");
		}

		static void Uninstall()
		{
			try
			{
				using (AssemblyInstaller installer = new AssemblyInstaller(typeof(ServiceEngine).Assembly, null))
				{
					IDictionary state = new Hashtable();
					try
					{
						installer.UseNewContext = true;
						installer.Uninstall(state);
					}
					catch (Exception ex)
					{
						Console.WriteLine(Errors.Extract(ex));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(Errors.Extract(ex));
			}
			//
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(false);
		}

		#endregion
	}
}
