using SkillsCrafter.Shared.Application;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace SkillsCrafter.Service.Host
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : Installer
	{
		#region Fields

		private readonly ServiceInstaller _installer = new ServiceInstaller();
		private readonly ServiceProcessInstaller _processInstaller = new ServiceProcessInstaller();

		#endregion

		#region Constructor

		public ProjectInstaller()
		{
			InitializeComponent();
		}

		#endregion

		#region Overrides

		protected override void OnBeforeInstall(IDictionary savedState)
		{
			base.OnBeforeInstall(savedState);
			//
			this.ConfigureInstallers();
		}

		protected override void OnBeforeUninstall(IDictionary savedState)
		{
			base.OnBeforeUninstall(savedState);
			//
			this.ConfigureInstallers();
		}

		#endregion

		#region Methods.Private

		private void ConfigureInstallers()
		{
			if (!String.IsNullOrEmpty(Configuration.Settings["Name"]))
			{
				_installer.Description =
				_installer.DisplayName =
				_installer.ServiceName = Configuration.Settings["Name"];
				_installer.StartType = ServiceStartMode.Manual;
				//
				_processInstaller.Account = ServiceAccount.LocalSystem;
				//
				this.Installers.Add(_installer);
				this.Installers.Add(_processInstaller);
			}
			else throw new Exception("Undefined service name.");
		}

		#endregion
	}
}
