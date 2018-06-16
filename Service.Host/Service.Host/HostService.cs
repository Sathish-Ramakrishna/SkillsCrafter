using System;
using System.ServiceProcess;

namespace SkillsCrafter.Service.Host
{
	public partial class HostService : ServiceBase
	{
		#region Fields

		private ServiceEngine _engine = null;

		#endregion

		#region Constructor

		public HostService()
		{
			InitializeComponent();
			//
			_engine = new ServiceEngine();
		}

		#endregion

		#region Overrides

		protected override void OnStart(string[] args)
		{
			_engine.Start();
		}

		protected override void OnStop()
		{
			_engine.Stop();
		}

		#endregion
	}
}
