using SkillsCrafter.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillsCrafter.Core.Implementation.Service;
using System.Data;
using SkillsCrafter.Shared.Utilities;
using SkillsCrafter.Core.Interfaces.Service;
using SkillsCrafter.Service.Utilities;
using System.Reflection;
using Newtonsoft.Json;

namespace SkillsCrafter.Service.Implementations
{
    partial class Service : IMainService
    {
        #region Method.Public

        #region Method.Public.Invoke

        public string Invoke(ref SearchContext searchContext)
        {
            string result = string.Empty;
            try
            {
                /* Session Logic must be inserted here. (Need new table creation)*/
                if (searchContext.MethodInformation != null)
                {
                    Object[] data = null;
                    Object resultData = null;
                    Type type = ObjectResolver.Resolve(searchContext.MethodInformation.ObjectName, false);
                    //
                    using (IDataTransaction dataTransaction = Activator.CreateInstance(type) as IDataTransaction)
                    {
                        MethodInfo method = this.FindMethod(type, searchContext.MethodInformation.MethodName);
                        //
                        data = this.FindParameters(searchContext, method);
                        //
                        resultData = method.Invoke(dataTransaction, data);
                        result = Json.Serialize(resultData);
                    }
                }
                else
                    throw new ArgumentException("Missing Method Information.");
            }
            catch (Exception exception)
            {
                Errors.Extract(exception);
            }
            //
            return result;
        }

        #endregion
        #region Method.Public.Search

        public DataSet Search(ref SearchContext searchContext)
        {
            DataSet dataSet = new DataSet();
            try
            {
                /* Session Logic must be inserted here. (Need new table creation)*/
                if (searchContext.MethodInformation != null)
                {
                    Object[] data = null;
                    Type type = ObjectResolver.Resolve(searchContext.MethodInformation.ObjectName, false);
                    //
                    using (IDataTransaction dataTransaction = Activator.CreateInstance(type) as IDataTransaction)
                    {
                        MethodInfo method = this.FindMethod(type, searchContext.MethodInformation.MethodName);
                        //
                        data = this.FindParameters(searchContext, method);
                        //
                        dataSet = method.Invoke(dataTransaction, data) as DataSet;
                    }
                }
                else
                {
                    using (IDataTransaction dataTransaction = Activator.CreateInstance(ObjectResolver.Resolve(searchContext)) as IDataTransaction)
                        dataSet = dataTransaction.Search(ref searchContext);
                }

            }
            catch (Exception exception)
            {
                searchContext.ErrorMessage = Errors.Extract(exception);
            }
            //
            return dataSet;
        }

        #endregion

        #endregion
        #region Method.Private

        #region Method.Private.FindParameters

        private Object[] FindParameters(SearchContext searchContext, MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters != null && searchContext.MethodInformation.MethodParameters != null &&
                parameters.Count() == searchContext.MethodInformation.MethodParameters.Count)
            {
                Object[] data = new Object[parameters.Count()];
                for (int i = 0; i < parameters.Count(); i++)
                {
                    data[i] = Json.Deserialize(searchContext.MethodInformation.MethodParameters[i], parameters[i].GetType());
                }
                return data;
            }
            else if (parameters == null && searchContext.MethodInformation.MethodParameters == null)
                return new Object[] { };
            else
                throw new ArgumentException("Incorrect number of jsonData elements.");
        }

        #endregion

        #region Method.Private.FindMethod

        private MethodInfo FindMethod(Type type, string methodName)
        {
            MethodInfo method = type.GetMethod(methodName);
            if (method == null)
                throw new ArgumentException($"Unable to find {type.Name}.{methodName}");
            //
            return method;
        }

        #endregion

        #endregion
    }
}
