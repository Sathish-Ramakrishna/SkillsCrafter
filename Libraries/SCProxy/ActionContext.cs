using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SkillsCrafter.SCProxy
{
    [XmlType(Namespace = "http://www.upp.com/irms/core/data/")]
    public class ActionContext
    {
        #region Fields
        private String _error;
        private String _message;
        private String _process;
        private String _sessionId;

        #endregion

        #region Properties

        public String Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public String Process
        {
            get { return _process; }
            set { _process = value; }
        }

        public String SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        #endregion
    }
}
