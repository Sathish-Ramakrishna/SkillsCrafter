using SkillsCrafter.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class SelectClause : ISelectClause
    {
        #region Fields

        private string _columnName;
        private string _columnAlais;

        #endregion

        #region Properties

        public string ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                _columnName = value;
            }
        }

        public string ColumnAlais
        {
            get
            {
                return _columnAlais;
            }
            set
            {
                _columnAlais = value;
            }
        }

        #endregion

        #region Constructors

        public SelectClause()
        {
            //
        }

        public SelectClause(string columnName, string columnAlais)
        {
            _columnName = columnName;
            _columnAlais = columnAlais;
        }

        #endregion
    }
}
