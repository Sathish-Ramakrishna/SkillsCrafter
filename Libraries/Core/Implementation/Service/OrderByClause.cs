using Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.Service
{
    public class OrderByClause : IOrderByClause
    {

        #region Fields
        private string _orderByName = string.Empty;
        private string _orderByValue = string.Empty;
        #endregion


        #region Properties
        public string OrderByName
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("@"))
                    throw new ArgumentException("OrderBy Name doesn't match the format.");
                else
                    _orderByName = value;
            }
            get
            {
                return _orderByName;
            }
        }

        public string OrderByValue
        {
            set
            {
                _orderByValue = value;
            }
            get
            {
                return _orderByValue;
            }
        }
        #endregion

        #region Constructors

        public OrderByClause()
        {
            //
        }

        public OrderByClause(string orderByName, string orderByValue)
        {
            OrderByName = orderByName;
            OrderByValue = orderByValue;
        }

        #endregion
    }
}
