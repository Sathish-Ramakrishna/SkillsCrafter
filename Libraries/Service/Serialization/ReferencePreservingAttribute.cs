using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Serialize
{
    public class ReferencePreservingAttribute : Attribute, IOperationBehavior
    {
        #region Methods.IOperationBehavior

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            //
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            IOperationBehavior operationBehavior = new ReferencePreservingOperationBehavior(operationDescription);
            operationBehavior.ApplyClientBehavior(operationDescription, clientOperation);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            IOperationBehavior operationBehavior = new ReferencePreservingOperationBehavior(operationDescription);
            operationBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }

        public void Validate(OperationDescription operationDescription)
        {
            //
        } 

        #endregion
    }
}
