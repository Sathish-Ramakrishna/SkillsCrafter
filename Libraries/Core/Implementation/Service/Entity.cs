using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class Entity
    {

        #region Fields.Protected

        protected DateTime _dateCreated;
        protected DateTime _dateModified;
        protected int? _id;
        protected int? _version;
        protected string _userCreated;
        protected string _userModified;
        
        #endregion

        #region Properties

        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
            }
        }

        public DateTime DateModified
        {
            get
            {
                return _dateModified;
            }
            set
            {
                _dateModified = value;
            }
        }

        public int? Id
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

        public int? Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        public string UserCreated
        {
            get
            {
                return _userCreated;
            }
            set
            {
                _userCreated = value;
            }
        }

        public string UserModified
        {
            get
            {
                return _userModified;
            }
            set
            {
                _userModified = value;
            }
        }
 
        #endregion

        #region Constructor

        public Entity()
        {
            //
        }

        public Entity(int id)
        {
            Id = id;
        }
        #endregion

    }
}
