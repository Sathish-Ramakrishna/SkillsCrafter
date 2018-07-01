using SkillsCrafter.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class DataTransaction : IDataTransaction
    {
        #region Constructor

        public DataTransaction()
        {
            //
        }

        #endregion

        public void Dispose()
        {
            //
        }

        public DataSet Search(ref SearchContext searchContext)
        {
            DataSet dataSet = new DataSet();
            //
            dataSet = this.Search(ref searchContext);
            //
            return dataSet;
        }
    }
}
