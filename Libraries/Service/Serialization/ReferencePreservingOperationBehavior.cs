using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace SkillsCrafter.Serialize
{
    public class ReferencePreservingOperationBehavior : DataContractSerializerOperationBehavior
    {

        #region Constructors

        public ReferencePreservingOperationBehavior(OperationDescription operationDescription)
            : base(operationDescription)
        {
            //
        }

        public ReferencePreservingOperationBehavior(OperationDescription operationDescription,DataContractFormatAttribute dataContractFormatAttribute)
            :base(operationDescription,dataContractFormatAttribute)
        {
            //
        }

        #endregion

        #region Overrides

        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                Int32.MaxValue,
                false,
                true,
                null);
        }

        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                Int32.MaxValue,
                false,
                true,
                null);
        }

        #endregion

    }
}