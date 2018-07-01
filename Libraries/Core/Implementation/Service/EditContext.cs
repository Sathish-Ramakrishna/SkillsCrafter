using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class EditContext : ActionContext
    {

        #region Fields

        private int _id = -1;

        #endregion

        #region Properties

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        #endregion

        #region Constructor

        public EditContext()
        {
            //
        }

        #endregion

    }
}
