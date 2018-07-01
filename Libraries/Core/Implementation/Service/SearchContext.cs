using SkillsCrafter.Core.Implementation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class SearchContext : ActionContext
    {

        #region Fields

        private int _currentPage = 1;
        private int _pageSize = 1;
        private int _rowCount = 0;
        private List<string> _columnNames = new List<string>();
        private List<FilterClause> _filterClause = new List<FilterClause>();
        private List<OrderByClause> _orderByClause = new List<OrderByClause>();
        private MethodInformation _methodInfo = new MethodInformation();
        private SearchMode _searchMode = SearchMode.First;

        #endregion

        #region Properties

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int RowCount
        {
            get
            {
                return _rowCount;
            }
            set
            {
                _rowCount = value;
            }
        }

        public List<string> ColumnNames
        {
            get
            {
                return _columnNames;
            }
            set
            {
                _columnNames = value;
            }
        }

        public List<FilterClause> FilterClause
        {
            get
            {
                return _filterClause;
            }
            set
            {
                _filterClause = value;
            }
        }

        public List<OrderByClause> OrderByClause
        {
            get
            {
                return _orderByClause;
            }
            set
            {
                _orderByClause = value;
            }
        }

        public MethodInformation MethodInformation
        {
            get
            {
                return _methodInfo;
            }
            set
            {
                _methodInfo = value;
            }
        }

        public SearchMode SearchMode
        {
            get
            {
                return _searchMode;
            }
            set
            {
                _searchMode = value;
            }
        }

        #endregion

        #region Constructor

        public SearchContext()
        {
            //
        }

        #endregion

    }
}
