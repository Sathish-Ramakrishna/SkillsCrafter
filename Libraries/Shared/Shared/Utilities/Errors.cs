using System;

namespace SkillsCrafter.Shared.Utilities
{
	public sealed class Errors
	{
		#region Methods.Public

		public static String Extract(Exception ex)
		{
			return Errors.Extract(ex, true);
		}

		public static String Extract(Exception ex, bool trace)
		{
			String error = ex.Message;
			if (trace && !String.IsNullOrEmpty(ex.StackTrace))
				error = String.Format("{0}{1} Stack Trace: {2}", error, Environment.NewLine, ex.StackTrace);
			if (ex.InnerException != null)
				error = String.Format("{0}{1} Inner Exception: {2}", 
					error, Environment.NewLine, Errors.Extract(ex.InnerException, trace));
			//
			return error;
		}

		public static void Raise(string error)
		{
			throw new ApplicationException(error);
		}

		public static void Raise(string format, params object[] args)
		{
			Errors.Raise(String.Format(format, args));
		}

		#endregion
	}
}
