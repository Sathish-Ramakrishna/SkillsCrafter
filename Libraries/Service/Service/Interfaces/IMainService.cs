using SkillsCrafter.Core.Implementation.Service;
using SkillsCrafter.Serialize;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using SkillsCrafter.Core;

namespace SkillsCrafter.Service.Interfaces
{
    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        [ReferencePreserving]
        DataSet Search(ref SearchContext searchContext);

        [OperationContract]
        [ReferencePreserving]
        string Invoke(ref SearchContext searchContext);
        //DataSet Invoke(ref string[] jsonContext, string[] jsonData);
    }
}
