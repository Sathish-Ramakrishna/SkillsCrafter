using SkillsCrafter.Core.Implementation.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SkillsCrafter.Service.Utilities
{
    public static class ObjectResolver
    {
        #region Method.Public

        public static Type Resolve(ActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentException("Unspecified (null) context object.");
            //
            if (actionContext.Graph == null || actionContext.Graph.Count == 0)
                throw new ArgumentException("Missing or Empty entity graphs list.");
            //
            return ObjectResolver.GetTransactionType(actionContext.Graph[0].Split('.')[0]);
        }

        public static Type Resolve(string objectName, bool isTransactionObject = true)
        {
            return ObjectResolver.GetTransactionType(objectName, isTransactionObject);
        }

        public static Type Resolve(IList entity)
        {
            if (entity == null || entity.Count == 0)
                throw new ArgumentException("Missing or Empty entity graphs list.");
            //
            return ObjectResolver.GetTransactionType(entity.GetType().Name);

        }

        #endregion

        #region Method.Private

        private static Type GetTransactionType(string graphName, bool isTransaction = true)
        {
            if(string.IsNullOrWhiteSpace(graphName))
                throw new ArgumentException("Missing or Empty entity graphs list.");

            if (isTransaction)
            {
                var types = from Type type in AssemblyProvider.Assembly.GetTypes()
                            where type.FullName.EndsWith(string.Format($"{graphName}Transaction"))
                            select type;

                if (types.Count() != 1)
                    throw new ArgumentException($"Unable to resolve Transaction type for {graphName}");
                return types.First(); 
            }
            else
            {
                var types = from Type type in AssemblyProvider.Assembly.GetTypes()
                            where type.FullName.EndsWith(graphName)
                            select type;

                if (types.Count() != 1)
                    throw new ArgumentException($"Unable to Access {graphName}");
                return types.First();
            }
        }

        #endregion
    }
}
