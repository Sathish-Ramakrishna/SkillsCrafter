using System;
using System.ServiceModel;

namespace SkillsCrafter.Service
{
	[ServiceContract(Namespace = "http://www.SkillsCrafter.com/service/")]
	public interface IMethodService
	{
		[OperationContract]
		String Invoke(ref string[] jsonContext, string[] jsonData);
	}
}
