using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SkillsCrafter.Shared.Utilities
{
	public class NetworkConnection : IDisposable
	{
		#region Fields

		private readonly String _remoteName = null;

		#endregion

		#region Constructor

		public NetworkConnection(string path, string user, string password)
		{
			_remoteName = Path.GetDirectoryName(path);
			//
			NetResource resource = new NetResource
			{
				Scope = ResourceScope.GlobalNetwork,
				ResourceType = ResourceType.Disk,
				DisplayType = ResourceDisplaytype.Share,
				RemoteName = _remoteName,
			};
			//
			int result = NetworkConnection.WNetAddConnection2(resource, password, user, 0);
			if (result != 0) Errors.Raise("Error connecting to remote share ({0}).", _remoteName);
		}

		#endregion

		#region Destructor

		~NetworkConnection()
		{
			this.Dispose(false);
		}

		#endregion

		#region Methods.IDisposable

		public void Dispose()
		{
			this.Dispose(true);
			//
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			NetworkConnection.WNetCancelConnection2(_remoteName, 0, true);
		}

		#endregion

		#region Methods.External

		[DllImport("mpr.dll")]
		private static extern int WNetAddConnection2(NetResource resource, string password, string user, int flags);

		[DllImport("mpr.dll")]
		private static extern int WNetCancelConnection2(string name, int flags, bool force);

		#endregion
	}

	#region Enumerations

	public enum ResourceDisplaytype : int
	{
		Generic = 0x0,
		Domain = 0x01,
		Server = 0x02,
		Share = 0x03,
		File = 0x04,
		Group = 0x05,
		Network = 0x06,
		Root = 0x07,
		Shareadmin = 0x08,
		Directory = 0x09,
		Tree = 0x0a,
		Ndscontainer = 0x0b
	}

	public enum ResourceScope : int
	{
		Connected = 1,
		GlobalNetwork,
		Remembered,
		Recent,
		Context
	};

	public enum ResourceType : int
	{
		Any = 0,
		Disk = 1,
		Print = 2,
		Reserved = 8,
	}

	#endregion

	#region Classes.NetResource

	[StructLayout(LayoutKind.Sequential)]
	public class NetResource
	{
		public ResourceScope Scope;
		public ResourceType ResourceType;
		public ResourceDisplaytype DisplayType;
		public int Usage;
		public string LocalName;
		public string RemoteName;
		public string Comment;
		public string Provider;
	}

	#endregion
}
