using System.Collections.Generic;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class MethodInformation 
    {

        #region Fields

        private List<string> _methodParameters = new List<string>();//Serialize - de-serialize data
        private List<string> _methodOutput = new List<string>();
        private string _objectName = string.Empty;
        private string _methodName = string.Empty;

        #endregion

        #region Properties

        public List<string> MethodParameters
        {
            get
            {
                return _methodParameters;
            }
            set
            {
                _methodParameters = value;
            }
        }

        public List<string> MethodOutput
        {
            get
            {
                return _methodOutput;
            }
            set
            {
                _methodOutput = value;
            }
        }

        public string ObjectName
        {
            get
            {
                return _objectName;
            }
            set
            {
                _objectName = value;
            }
        }

        public string MethodName
        {
            get
            {
                return _methodName;
            }
            set
            {
                _methodName = value;
            }
        }      

        #endregion

        #region Constructors

        public MethodInformation()
        {
            //
        }

        public MethodInformation(string objectName, string methodName)
        {

        } 

        #endregion
    }
}