using Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class FilterClause : IFilterClause
    {
        #region Fields
        private string _filterName = string.Empty;
        private string _filterValue = string.Empty; 
        #endregion


        #region Properties
        public string FilterName
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("@"))
                    throw new ArgumentException("Filter Name doesn't match the format.");
                else
                    _filterName = value;
            }
            get
            {
                return _filterName;
            }
        }

        public string FilterValue
        {
            set
            {
                _filterValue = value;
            }
            get
            {
                return _filterValue;
            }
        }
        #endregion

        #region Constructors

        public FilterClause()
        {
            //
        }

        public FilterClause(string filterName, string filterValue)
        {
            FilterName = filterName;
            FilterValue = FilterValue;
        }

        #endregion
    }
}
