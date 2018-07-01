using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.ADO
{
    public class SqlClientFactory : DbProviderFactory
    {
        #region Overrides

        #region Create SqlConnection
        public override DbConnection CreateConnection()
        {
            return new SqlConnection();
        }
        #endregion

        #region Create SqlCommand
        public override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        #endregion

        #region Create SqlDataAdapter
        public override DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        #endregion

        #region Create SqlCommandBuilder
        public override DbCommandBuilder CreateCommandBuilder()
        {
            return new SqlCommandBuilder();
        }
        #endregion

        #region Create SqlParameter
        public override DbParameter CreateParameter()
        {
            return new SqlParameter();
        }
        #endregion

        #region Create SqlConnectionStringBuilder
        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder();
        }
        #endregion 

        #endregion
    }
}
