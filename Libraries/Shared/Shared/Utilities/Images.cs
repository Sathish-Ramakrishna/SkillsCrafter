using System;
using System.Drawing;
using System.Reflection;

namespace Upp.Shared.Utilities
{
	public static class Images
	{
		#region Methods.Public

		public static Bitmap GetImage(Assembly assembly, string name)
		{
			try
			{
				return new Bitmap(assembly.GetManifestResourceStream(name));
			}
			catch (Exception ex)
			{
				if (Log.Instance != null)
				{
					string error = String.Format("Unable to find '{0}': {1}{2}", name, Errors.GetError(ex), Environment.NewLine);
					Log.Instance.WriteError(error, "Images.GetImage()");
				}
				return null;
			}
		}

		#endregion
	}
}
