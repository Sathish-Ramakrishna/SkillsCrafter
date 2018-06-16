using SkillsCrafter.Shared.Utilities;
using System;
using System.ServiceModel;
using System.Threading;

namespace SkillsCrafter.Service.Host
{
	public class ServiceEngine
	{
		#region Fields

		private ServiceHost _host = null;

		#endregion

		#region Methods

		public void Start()
		{
			Log.WriteEntry("Starting {0}...", Program.Name);
			//
			try
			{
				_host = new ServiceHost(typeof(MethodService));
				_host.Open();
				//
				if (Program.Daemon) while (true) Thread.Sleep(100);
				else Log.WriteEntry("{0} has started successfully.", Program.Name);
			}
			catch (Exception ex)
			{
				if (_host != null && _host.State == CommunicationState.Faulted) _host.Abort();
				Log.WriteError(Errors.Extract(ex));
			}
		}

		public void Stop()
		{
			Log.WriteEntry("Stopping {0}...", Program.Name);
			if (_host != null) _host.Close();
		}

		#endregion
	}
}
