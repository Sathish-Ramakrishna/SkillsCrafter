using SkillsCrafter.Core.Implementation.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Interfaces.Service
{
    public interface IDataTransaction : IDisposable
    {
        DataSet Search(ref SearchContext searchContext);
    }
}
