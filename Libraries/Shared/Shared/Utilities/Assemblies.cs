using System;
using System.Collections.Generic;
using System.Reflection;

namespace SkillsCrafter.Shared.Utilities
{
	public class Assemblies
	{
		#region Properties.Static

		public static List<String> AssemblyList
		{
			get
			{
				List<String> results = new List<String>();
				foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					results.Add(assembly.FullName);
				//
				return results;
			}
		}

		#endregion

		#region Methods.Public

		public static Assembly GetAssembly(string name)
		{
			Assembly result = null;
			//
			/* After each rebuild, Visual Studio adds 
			 * freshly built copies of project assemblies to the AppDomain. 
			 * If we're looking for a specific assembly, 
			 * it is important to load _the_last_loaded_instance_ of it.
			 * Hence, the following voodoo.
			 * - mk-9.25.9 */
			Int32 instance = 0;
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				if (assembly.GetName().Name == name) ++instance;
			//
			Int32 count = 0;
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				if (assembly.GetName().Name != name) continue;
				if (++count != instance) continue;
				//
				result = assembly;
				break;
			}
			//
			if (result == null)
			{
				result = Assembly.Load(name);
				if (result != null) AppDomain.CurrentDomain.Load(result.GetName());
			}
			//
			return result;
		}

		#endregion
	}
}