using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace SkillsCrafter.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MethodService : IMethodService, IDisposable
    {
        #region Constructor

        public MethodService()
        {
            //
        }

        #endregion

        #region Methods.IDisposable

        public void Dispose()
        {
            //
        }
        #endregion

        #region Methods.IMethodService
        public string Invoke(ref string[] jsonContext, string[] jsonData)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
