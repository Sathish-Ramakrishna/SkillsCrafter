using System;

namespace SkillsCrafter.Shared.Extensions
{
	public static class ObjectExtensions
	{
		#region Methods.Public

		public static Object GetPropertyValue(this object entity, string property)
		{
			try { return entity.GetType().GetProperty(property).GetValue(entity, null); }
			catch { return null; }
		}

		public static Boolean HasProperty(this object entity, string property)
		{
			try { return (entity.GetType().GetProperty(property) != null); }
			catch { return false; }
		}

		public static void InvokeMethod(this object entity, string method)
		{
			try { entity.GetType().GetMethod(method).Invoke(entity, null); }
			catch { }
		}

		public static void InvokeMethod(this object entity, string method, object[] parameters)
		{
			try { entity.GetType().GetMethod(method).Invoke(entity, parameters); }
			catch { }
		}

		public static void SetPropertyValue(this object entity, string property, object value)
		{
			try { entity.GetType().GetProperty(property).SetValue(entity, value, null); }
			catch { }
		}

		#endregion
	}
}
