using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    //[DataContract()]
    public class ActionContext
    {
        #region Fields

        protected List<ExecutableArea> _executableArea = new List<ExecutableArea>();
        protected List<string> _graph = new List<string>();
        protected string _errorMessage = string.Empty;
        protected string _sessionId = string.Empty;
        protected string _successMessage = string.Empty;
        protected string _warningMessage = string.Empty;
         

        #endregion

        #region Properties

        public List<ExecutableArea> ExecutableArea
        {
            get
            {
                return _executableArea;
            }
            set
            {
                _executableArea = value;
            }
        }

        public List<string> Graph
        {
            get
            {
                return _graph;
            }
            set
            {
                _graph = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }

        public string SessionId
        {
            get
            {
                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }

        public string SuccessMessage
        {
            get
            {
                return _successMessage;
            }
            set
            {
                _successMessage = value;
            }
        }

        public string WarningMessage
        {
            get
            {
                return _warningMessage;
            }
            set
            {
                _warningMessage = value;
            }
        }

        #endregion

        #region Constructor

        public ActionContext()
        {
            //
        } 

        #endregion

    }
}
