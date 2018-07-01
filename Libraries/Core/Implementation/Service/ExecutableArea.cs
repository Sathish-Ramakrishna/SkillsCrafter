using Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class ExecutableArea : IExecutableArea
    {
        #region Fields
        private string _name = string.Empty;
        private string _value = string.Empty;
        #endregion

        #region Properties
        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Executable Name doesn't match the format.");
                else
                    _name = value;
            }
            get
            {
                return _name;
            }
        }

        public string Value
        {
            set
            {
                _value = value;
            }
            get
            {
                return _value;
            }
        }
        #endregion

        #region Constructors

        public ExecutableArea()
        {
            //
        }

        public ExecutableArea(string name, string value)
        {
            Name = name;
            Value = value;
        }

        #endregion
    }
}
