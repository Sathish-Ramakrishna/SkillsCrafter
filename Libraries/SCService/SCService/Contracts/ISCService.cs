using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SkillsCrafter.SCProxy;

namespace SkillsCrafter.SCService.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        int Login(ref ActionContext actionContext, String username, byte[] password);
    }

    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        DataTable getSkillsDefinitions(ref ActionContext actionContext, String product);
    }
}
